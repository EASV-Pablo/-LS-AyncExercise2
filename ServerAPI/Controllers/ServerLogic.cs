using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerAPI.Controllers
{
    public class ServerLogic
    {

        /* Return [amount] random numbers between [min] and [max] inclusive */
        public int[] GetNumbers(int amount, int min, int max)
        {
            Thread.Sleep(2000);
            int[] res = new int[amount];
            Random r = new Random();
            int count = 0;
            while (count < amount)
            {
                int x = r.Next(max - min + 1) + min;
                res[count++] = x;
            }
            return res;
        }

        public int[] work(int amount, int min, int max)
        {
            Thread.Sleep(2000);
            return GetNumbers(amount, min, max);
        }

        public Task<int[]> GetNumbersAsync(int amount, int min, int max)
        {
            var res = Task.Run(() => GetNumbers(amount, min, max));
            return res;
        }
    }
}
