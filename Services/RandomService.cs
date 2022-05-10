using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Services
{
    public interface IRandomService
    {
        string RandomListArrayNumber(int number);
    }

    public class RandomService : IRandomService
    {
        public string RandomListArrayNumber(int number)
        {
            Random random = new Random();
            var listNumber = new List<int>();
            for (var i = 0; i < number; i++)
            {
                int value = random.Next(0, 100);
                listNumber.Add(value);
            }

            var result = listNumber.Aggregate(string.Empty, (current, item) => current + item + ",");
            var resultFinal = result.Remove(result.Length - 1);
            return resultFinal;
        }
    }
}
