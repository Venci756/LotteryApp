using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Helpers
{
    public class GenerateNumbersHelper
    {
        private Random _rnd = new Random();
        public string GenerateNumbers(int numLimit, int numAmount)
        {

            return string.Join(",",
                Enumerable
                    .Range(1, numLimit)
                    .OrderBy(x => _rnd.Next())
                    .Take(numAmount));
        }
    }
}
