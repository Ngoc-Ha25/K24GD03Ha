using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

namespace LAB5
{
    internal class Program
    {
        static FirebaseClient firebase = new FirebaseClient("https://project-1-d4f90-default-rtdb.asia-southeast1.firebasedatabase.app/");
        static SinhVien sv;

        public class SinhVien
        {
            public string HoTen { get; set; }
            public string MSSV { get; set; }
            public string Email { get; set; }
            public string Lop { get; set; }
        }

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Dang khoi tao Firebase Admin SDK...");

            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile("C:\\Dev\\K24GD03Ha\\serviceAccountKey.json")
            });

            Console.WriteLine("Firebase Admin SDK đã được khởi tạo thành công!");

            await MenuSinhVien();
        }

        static async Task MenuSinhVien()
        {
            while (true)
            {
                Console.WriteLine("\n== MENU ==");
                Console.WriteLine("1. Nhập dữ liệu sinh viên");
                Console.WriteLine("2. Ghi dữ liệu sinh viên vào Firebase");
                Console.WriteLine("3. Lấy dữ liệu sinh viên từ Firebase");
                Console.WriteLine("4. Cập nhật dữ liệu sinh viên");
                Console.WriteLine("5. Xóa dữ liệu sinh viên");
                Console.WriteLine("6. Thoát");
                Console.Write("Chọn chức năng: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        NhapSinhVien();
                        break;
                    case 2:
                        await GhiSinhVien();
                        break;
                    case 3:
                        await LaySinhVien();
                        break;
                    case 4:
                        await CapNhatSinhVien();
                        break;
                    case 5:
                        await XoaSinhVien();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            }
        }

        static void NhapSinhVien()
        {
            sv = new SinhVien();
            Console.Write("Họ tên: ");
            sv.HoTen = Console.ReadLine();
            Console.Write("MSSV: ");
            sv.MSSV = Console.ReadLine();
            Console.Write("Email: ");
            sv.Email = Console.ReadLine();
            Console.Write("Lớp: ");
            sv.Lop = Console.ReadLine();
        }

        static async Task GhiSinhVien()
        {
            if (sv == null)
            {
                Console.WriteLine("Vui lòng nhập dữ liệu sinh viên trước.");
                return;
            }

            await firebase.Child("SinhVien").PostAsync(sv);
            Console.WriteLine("Dữ liệu đã được ghi thành công.");
        }

        static async Task LaySinhVien()
        {
            var sinhVienList = await firebase.Child("SinhVien").OnceAsync<SinhVien>();
            Console.WriteLine("\n--- DANH SÁCH SINH VIÊN ---");
            foreach (var item in sinhVienList)
            {
                var s = item.Object;
                Console.WriteLine($"MSSV: {s.MSSV} | Họ tên: {s.HoTen} | Email: {s.Email} | Lớp: {s.Lop}");
            }
        }

        static async Task CapNhatSinhVien()
        {
            Console.Write("Nhập MSSV cần cập nhật: ");
            string mssv = Console.ReadLine();

            var sinhVienList = await firebase.Child("SinhVien").OnceAsync<SinhVien>();
            var svToUpdate = sinhVienList.FirstOrDefault(s => s.Object.MSSV == mssv);

            if (svToUpdate != null)
            {
                Console.Write("Nhập Email mới: ");
                svToUpdate.Object.Email = Console.ReadLine();
                await firebase.Child("SinhVien").Child(svToUpdate.Key).PutAsync(svToUpdate.Object);
                Console.WriteLine("Cập nhật thành công.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy sinh viên.");
            }
        }

        static async Task XoaSinhVien()
        {
            Console.Write("Nhập MSSV cần xóa: ");
            string mssv = Console.ReadLine();

            var sinhVienList = await firebase.Child("SinhVien").OnceAsync<SinhVien>();
            var svToDelete = sinhVienList.FirstOrDefault(s => s.Object.MSSV == mssv);

            if (svToDelete != null)
            {
                await firebase.Child("SinhVien").Child(svToDelete.Key).DeleteAsync();
                Console.WriteLine("Xóa thành công.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy sinh viên.");
            }
        }
    }
}