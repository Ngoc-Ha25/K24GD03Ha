using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;


namespace FINAL_EXAM
{
    internal class Program
    {
        public class Player
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Level { get; set; }
            public int Gold { get; set; }
            public int Coins { get; set; }
            public bool IsActive { get; set; }
            public int VipLevel { get; set; }
            public string Region { get; set; }
            public DateTime LastLogin { get; set; }

        }
        static async Task Main(string[] args)
        {
            string url = "https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/refs/heads/main/lab12_players.json";
            DateTime now = new DateTime(2025, 06, 30, 0, 0, 0, DateTimeKind.Utc);

            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(url);
            List<Player> players = JsonConvert.DeserializeObject<List<Player>>(json);

            var firebaseClient = new FirebaseClient("https://project-1-d4f90-default-rtdb.asia-southeast1.firebasedatabase.app/");

            // Bai 1
            var inactivePlayers = players.Where(p => !p.IsActive || (now - p.LastLogin).TotalDays > 5).ToList();
            Console.WriteLine("---1.1. DANH SACH NGUOI CHOI KHONG HOAT DONG GAN DAY---");
            foreach (var p in inactivePlayers)
            {
                Console.WriteLine($"{p.Name} | {p.IsActive} | {p.LastLogin:dd/MM/yyyy HH:mm:ss}Z");
            }

            await firebaseClient.Child("final_exam_bai1_inactive_players").DeleteAsync();
            int id1 = 1;
            foreach (var p in inactivePlayers)
            {
                await firebaseClient.Child("final_exam_bai1_inactive_players").Child(id1++.ToString()).PutAsync(new
                {
                    p.Name,
                    p.IsActive,
                    LastLogin = p.LastLogin.ToString("yyyy-MM-ddTHH:mm:ssZ")
                });
            }

            //Bai 1.2: Nguoi choi cap thap
            
            var lowLevelPlayers = players.Where(p => p.Level < 10).ToList();
            Console.WriteLine("\n---1.2. DANH SACH NGUOI CHOI CAP THAP---");
            Console.WriteLine("TEN NGUOI CHOI | LEVEL | GOLD HIEN TAI");
            foreach (var p in lowLevelPlayers) 
            {
                Console.WriteLine($"{p.Name} | {p.Level} | {p.Gold}");
            }

            await firebaseClient.Child("final_exam_bai1_low_level_players").DeleteAsync();
            int id2 = 1;
            foreach (var p in lowLevelPlayers)
            {
                await firebaseClient.Child("final_exam_bai1_low_level_players").Child(id2++.ToString()).PutAsync(new
                {
                    p.Name,
                    p.Level,
                    Gold = p.Gold
                });
            }

            //Bai 2: Trao thuong nguoi choi VIP
            int totalVIP = (from p in players where p.VipLevel > 0 select p).Count();
            Console.WriteLine($"\n== TONG SO NGUOI CHOI VIP: {totalVIP}");

            var vipPlayers = players.Where(p => p.VipLevel > 0).ToList();

            Console.WriteLine("\n--- DANH SACH NGUOI CHOI VIP ---");
            Console.WriteLine("TEN | LEVEL | VIP LEVEL | GOLD | COINS ");

            foreach (var p in vipPlayers)
            {
                Console.WriteLine($"{p.Name} | {p.Level} | {p.VipLevel} | {p.Gold} | {p.Coins} ");
            }
            var top3VIP = players
            .Where(p => p.VipLevel > 0)
            .OrderByDescending(p => p.Level)
            .Take(3)
            .Select((p, index) =>
            {
                int rank = index + 1; 
                int bonusGold = 0;
                if (rank == 1) bonusGold = 2000;
                else if (rank == 2) bonusGold = 1500;
                else if (rank == 3) bonusGold = 1000;

                return new
                {
                    Name = p.Name,
                    VipLevel = p.VipLevel,
                    Level = p.Level,
                    Gold = p.Gold,
                    BonusGold = bonusGold
                };
            })
            .ToList();
            Console.WriteLine("\n--- 2. DANH SACH TOP 3 VIP---");
            Console.WriteLine("\nTEN NGUOI CHOI | HANG VIP | LEVEL | GOLD HIEN TAI | GOLD SE DUOC THUONG");
            foreach (var p in top3VIP)
            {
                Console.WriteLine($"{p.Name} | VIP: {p.VipLevel} | Level: {p.Level} | Gold: {p.Gold} | +Bonus: {p.BonusGold}");
            }

            await firebaseClient.Child("final_exam_bai2_top3_vip_awards").DeleteAsync();
            int id3 = 1;
            foreach (var p in top3VIP)
            {
                await firebaseClient.Child("final_exam_bai2_top3_vip_awards").Child(id3++.ToString()).PutAsync(p);
            }
            Console.ReadLine();
        }
    }
}
