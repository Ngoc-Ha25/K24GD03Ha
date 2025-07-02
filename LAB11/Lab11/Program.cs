using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;

namespace Lab11
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

    class Program
    {
        static async Task Main(string[] args)
        {
            string dataUrl = "https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/main/simple_players.json";
            string firebaseUrl = "https://project-1-d4f90-default-rtdb.asia-southeast1.firebasedatabase.app/"; 
            var client = new HttpClient();
            var firebase = new FirebaseClient(firebaseUrl);

            string json = await client.GetStringAsync(dataUrl);
            List<Player> players = JsonConvert.DeserializeObject<List<Player>>(json);

     
            var richPlayers =
                (from p in players
                 where p.Gold > 1000 && p.Coins > 100
                 orderby p.Gold descending
                 select new { p.Name, p.Gold, p.Coins }).ToList();

            Console.WriteLine("== NGUOI CHOI GIAU CO==");
            richPlayers.ForEach(p => Console.WriteLine($"Ten: {p.Name}, Gold: {p.Gold}, Coins: {p.Coins}"));

            await firebase.Child("quiz_bai1_richPlayers").PutAsync(richPlayers);

            
            DateTime now = new DateTime(2025, 6, 30, 0, 0, 0);

            int totalVIP = (from p in players where p.VipLevel > 0 select p).Count();
            Console.WriteLine($"\n== TONG SO NGUOI CHOI VIP: {totalVIP}");

            var vipByRegion =
                from p in players
                where p.VipLevel > 0
                group p by p.Region into g
                select new { Region = g.Key, Count = g.Count() };

            Console.WriteLine("\n== VIP THEO KHU VUC ==");
            vipByRegion.ToList().ForEach(g => Console.WriteLine($"{g.Region}: {g.Count} VIP"));

            var recentVIP =
                (from p in players
                 where p.VipLevel > 0 && (now - p.LastLogin).TotalDays <= 2
                 select new { p.Name, p.VipLevel, p.LastLogin }).ToList();

            Console.WriteLine("\n== VIP DANG NHAP GAN DAY ==");
            recentVIP.ForEach(p => Console.WriteLine($"{p.Name} - VIP {p.VipLevel} - Login: {p.LastLogin}"));

            await firebase.Child("quiz_bai2_recentVipPlayers").PutAsync(recentVIP);
            Console.ReadLine();
        }
    }
}