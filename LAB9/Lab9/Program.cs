using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lab9
{
    internal class Program
    {
        static async Task<string> GetWebContent(string url)
        {
            string html = "";
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/4.0");
                HttpResponseMessage httpResponse = await httpClient.GetAsync(url);
                html = await httpResponse.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            return html;
        }

        static void VD01_GetWebContent(string url)
        {
            Console.WriteLine("=========== VD01_GetWebContent Load: " + url);
            var taskLoadWeb = GetWebContent(url);
            taskLoadWeb.Wait(); // Gọi đồng bộ
            var html = taskLoadWeb.Result;
            Console.WriteLine("VD01_GetWebContent:\n" + html);
        }

        static void Main(string[] args)
        {

            string url = "https://www.example.com"; // Thay đổi thành URL bạn muốn test
            VD01_GetWebContent(url);
            Console.ReadLine();
        }
    }
}

        
    
