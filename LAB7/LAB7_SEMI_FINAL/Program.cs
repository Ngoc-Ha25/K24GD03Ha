using Firebase.Database;
using Firebase.Database.Query;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LAB7_SEMI_FINAL.Program;

namespace LAB7_SEMI_FINAL
{
    internal class Program
    {
        static FirebaseClient firebase = new FirebaseClient("https://project-1-d4f90-default-rtdb.asia-southeast1.firebasedatabase.app/");
        static Player player;

        public class Player
        {
            public string PlayerID { get; set; }
            public string Name { get; set; }
            public int Gold { get; set; }
            public int Score { get; set; }
        }

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Đang khởi tạo Firebase Admin SDK...");

            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile("C:\\Dev\\K24GD03Ha\\serviceAccountKey.json")
            });

            Console.WriteLine("Firebase Admin SDK đã được khởi tạo thành công!");

            await MenuPlayer();
        }

        static async Task MenuPlayer()
        {
            while (true)
            {
                Console.WriteLine("\n== MENU ==");
                Console.WriteLine("1. Nhập thông tin player");
                Console.WriteLine("2. Ghi player vào Firebase");
                Console.WriteLine("3. Xem danh sách player");
                Console.WriteLine("4. Cập nhật Gold hoặc Score");
                Console.WriteLine("5. Xoá player theo PlayerID");
                Console.WriteLine("6. Ghi & lưu TOP5 Gold vào Firebase");
                Console.WriteLine("7. Ghi & lưu TOP5 Score vào Firebase");
                Console.WriteLine("8.Thoát");
                Console.Write("Chọn chức năng: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    continue;
                }

                switch (choice)
                {
                    case 1: NhapPlayer(); break;
                    case 2: await GhiPlayer(); break;
                    case 3: await XemDanhSachPlayer(); break;
                    case 4: await CapNhatPlayer(); break;
                    case 5: await XoaPlayer(); break;
                    case 6: await GhiTop5Gold(); break;
                    case 7: await GhiTop5Score(); break;
                    case 8: return;
                    default: Console.WriteLine("Lựa chọn không hợp lệ."); break;
                }
            }
        }

        static void NhapPlayer()
        {
            player = new Player();
            Console.Write("PlayerID: "); player.PlayerID = Console.ReadLine();
            Console.Write("Tên: "); player.Name = Console.ReadLine();
            Console.Write("Gold: "); int.TryParse(Console.ReadLine(), out int gold); player.Gold = gold;
            Console.Write("Score: "); int.TryParse(Console.ReadLine(), out int score); player.Score = score;
        }

        static async Task GhiPlayer()
        {
            if (player == null)
            {
                Console.WriteLine("Vui lòng nhập dữ liệu trước.");
                return;
            }

            await firebase.Child("Players").Child(player.PlayerID).PutAsync(player);
            Console.WriteLine("Dữ liệu đã ghi thành công.");
        }

        static async Task XemDanhSachPlayer()
        {
            var danhSach = await firebase.Child("Players").OnceAsync<Player>();

            
            var sorted = danhSach
                .Select(p => p.Object)
                .OrderBy(p => p.PlayerID)
                .ToList();

            Console.WriteLine("\n--- DANH SÁCH PLAYER (THEO ID) ---");
            int stt = 1;
            foreach (var p in sorted)
            {
                Console.WriteLine($"{stt++}.ID: {p.PlayerID} | Tên: {p.Name} | Gold: {p.Gold} | Score: {p.Score}");
            }
        }

        static async Task CapNhatPlayer()
        {
            Console.Write("Nhập PlayerID cần cập nhật: ");
            string id = Console.ReadLine();

            var ds = await firebase.Child("Players").OnceAsync<Player>();
            var pUpdate = ds.FirstOrDefault(p => p.Object.PlayerID == id);

            if (pUpdate != null)
            {
                Console.Write("Gold mới (bỏ trống nếu không đổi): ");
                string goldStr = Console.ReadLine();
                if (int.TryParse(goldStr, out int g)) pUpdate.Object.Gold = g;

                Console.Write("Score mới (bỏ trống nếu không đổi): ");
                string scoreStr = Console.ReadLine();
                if (int.TryParse(scoreStr, out int s)) pUpdate.Object.Score = s;

                await firebase.Child("Players").Child(pUpdate.Key).PutAsync(pUpdate.Object);
                Console.WriteLine("Đã cập nhật thành công.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy Player.");
            }
        }

        static async Task XoaPlayer()
        {
            Console.Write("Nhập PlayerID cần xoá: ");
            string id = Console.ReadLine();

            var ds = await firebase.Child("Players").OnceAsync<Player>();
            var pDelete = ds.FirstOrDefault(p => p.Object.PlayerID == id);

            if (pDelete != null)
            {
                await firebase.Child("Players").Child(pDelete.Key).DeleteAsync();
                Console.WriteLine("Đã xoá thành công.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy Player.");
            }
        }

        static async Task GhiTop5Gold()
        {
            var danhSach = await firebase.Child("Players").OnceAsync<Player>();

            var top5 = danhSach.Select(p => p.Object)
                               .OrderByDescending(p => p.Gold)
                               .Take(5)
                               .ToList();

            Console.WriteLine("\n--- TOP 5 NGƯỜI CHƠI CÓ GOLD CAO NHẤT ---");

            for (int i = 0; i < top5.Count; i++)
            {
                Console.WriteLine($"{i + 1}. ID: {top5[i].PlayerID} | Name: {top5[i].Name} | Gold: {top5[i].Gold}");

                await firebase
                    .Child("TopGold")
                    .Child((i + 1).ToString())  
                    .PutAsync(top5[i]);
            }

            Console.WriteLine(">> Top 5 đã được lưu vào Firebase tại node 'TopGold'.");
        }

        static async Task GhiTop5Score()
        {
            var danhSach = await firebase.Child("Players").OnceAsync<Player>();

            var top5 = danhSach.Select(p => p.Object)
                               .OrderByDescending(p => p.Score)
                               .Take(5)
                               .ToList();

            Console.WriteLine("\n--- TOP 5 NGƯỜI CHƠI CÓ SCORE CAO NHẤT ---");

            for (int i = 0; i < top5.Count; i++)
            {
                Console.WriteLine($"{i + 1}. ID: {top5[i].PlayerID} | Name: {top5[i].Name} | Score: {top5[i].Score}");

                await firebase
                    .Child("TopScore")
                    .Child((i + 1).ToString())  
                    .PutAsync(top5[i]);
            }

            Console.WriteLine(">> Danh sách TopScore đã được ghi thành công vào Firebase.");
        }
    }
}
