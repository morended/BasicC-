using System.Threading;
using System.Threading.Tasks;

namespace CsharpBasics.basics
{
   public class AsyncDemo
    {
        public int result { get; set; }

        public Task getAsyncResult()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(2000);
                result = 1000;
            });
        }
    }
}
