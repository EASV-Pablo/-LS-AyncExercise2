using System;
namespace ServerAPI.Controllers
{
    public class ServerLogic
    {

        /* Return [amount] random numbers between [min] and [max] inclusive */
        public int[] GetNumbers(int amount, int min, int max)
        {
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
    }
}
