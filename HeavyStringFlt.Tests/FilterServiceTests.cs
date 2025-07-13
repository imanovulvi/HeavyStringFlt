using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeavyStringFlt.API.Business.Concret;

namespace HeavyStringFlt.Tests
{
    public class FilterServiceTests
    {
        [Fact]
        public void Filter_Removes_Similar_Words()
        {
        
            var filterWords = new List<string> { "hacker", "virus" };
            var service = new StringFilter(filterWords, 0.8);

            string input = "he is a haker and not a virus";

          
            var result = service.Filter(input);

          
            Assert.Equal("he is a and not a", result);
        }

    }
}
