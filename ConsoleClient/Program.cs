using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {

        static void Main(string[] args)
        {

            HttpClient _client = new HttpClient();

            int number = GetNumber("Enter a number (0 for stop): ");
            while (number != 0)
            {
                DateTime start = DateTime.Now;

                Task<HttpResponseMessage> response = _client.GetAsync("https://localhost:5003/numbers/" + number);

                String result = (response.Result.Content.ReadAsStringAsync().Result);

                WriteToFile("Result: " + result + " between " + start.ToLongTimeString() + " - " + DateTime.Now.ToLongTimeString());

                
                number = GetNumber("Enter a number (0 for stop): ");
            }
            Console.WriteLine("Done...");
        }

        private static int GetNumber(String text)
        {
            Console.WriteLine(text);
            return int.Parse(Console.ReadLine());
        }

        private static void WriteToFile(string s)
        {
            string path = @"fromclient.txt";

            StreamWriter sw = File.AppendText(path);

            sw.WriteLine(s);

            sw.Flush();
        }
    }
}
