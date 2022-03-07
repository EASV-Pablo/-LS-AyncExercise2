using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace ConsoleClient
{
    class Program : ICallback
    {

        static void Main(string[] args)
        {
            Program p = new Program();
            p.run();
        }

        public void run()
        {
            HttpClient _client = new HttpClient();

            int number = ReadNumber("Enter a number (0 for stop): ");
            while (number != 0)
            {
                var t = new Thread(() => doTheCall(number, _client, this));
                t.Start();


                number = ReadNumber("Enter a number (0 for stop): ");
            }
            Console.WriteLine("Done...");

        }

        private void doTheCall(int number, HttpClient _client, ICallback cb)
        {
            DateTime start = DateTime.Now;
            Task<HttpResponseMessage> response = _client.GetAsync("https://localhost:5003/numbers/" + number);
            String result = (response.Result.Content.ReadAsStringAsync().Result);
            result = "Result: " + result + " between " + start.ToLongTimeString() + " - " + DateTime.Now.ToLongTimeString();
            cb.WhenResultReceived(result);

        }

        private static int ReadNumber(String text)
        {
            Console.WriteLine(text);
            return int.Parse(Console.ReadLine());
        }

        private static void WriteToFile(string s)
        {
            string path = @"fromclient.txt";

            StreamWriter sw = File.AppendText(path);

            sw.WriteLine(s);

            sw.Close();
        }

        void ICallback.WhenResultReceived(string result)
        {
            WriteToFile(result);
        }
    }
}
