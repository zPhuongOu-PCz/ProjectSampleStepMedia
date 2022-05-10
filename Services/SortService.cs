using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Services
{
    public interface ISortService
    {
        string SortArrayWithMaxNumberToMiddle(string arrayString, int numberMax);
    }

    public class SortService : ISortService
    {
        public string SortArrayWithMaxNumberToMiddle(string arrayString, int numberMax)
        {
            //! Check valid request
            if (string.IsNullOrEmpty(arrayString))
                return null;
            if (numberMax <= 0)
                return null;
            var listNumber = arrayString.Split(',').Select(z => Convert.ToInt16(z)).ToList();
            if (numberMax > listNumber.Count())
                return null;
            var listMaxNumber = new List<short>();

            //! Get value & index max record on list
            for (var j = 0; j < numberMax; j++)
            {
                var (number, index) = listNumber.Select((n, i) => (n, i)).Max();
                listMaxNumber.Add(number);
                listNumber.RemoveAt(index);
            }
            listMaxNumber.Sort();
            listNumber.InsertRange(listNumber.Count() / 2, listMaxNumber);

            //! return response
            var result = listNumber.Aggregate(string.Empty, (current, item) => current + item + ",");
            var resultFinal = result.Remove(result.Length - 1);
            return resultFinal;
        }
    }
}