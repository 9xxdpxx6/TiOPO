using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiOPO_4
{
    public class StringMergerTests
    {

        private readonly StringMerger _merger = new StringMerger();
                public void TestBothEmpty()
        {
            string result = _merger.MergeStrings("", "");
            Console.WriteLine($"TestBothEmpty: '{result}'");
        }

        
        public void TestFirstEmpty()
        {
            string result = _merger.MergeStrings("", "123");
            Console.WriteLine($"TestFirstEmpty: '{result}'");
        }

        
        public void TestSecondEmpty()
        {
            string result = _merger.MergeStrings("abc", "");
            Console.WriteLine($"TestSecondEmpty: '{result}'");
        }
                
        public void TestEqualLength()
        {
            string result = _merger.MergeStrings("abc", "123");
            Console.WriteLine($"TestEqualLength: '{result}'");
        }

        public void TestFirstLonger()
        {
            string result = _merger.MergeStrings("abcd", "12");
            Console.WriteLine($"TestFirstLonger: '{result}'");
        }

        public void TestSecondLonger()
        {
            string result = _merger.MergeStrings("ab", "1234");
            Console.WriteLine($"TestSecondLonger: '{result}'");
        }

        public void TestWithNull()
        {
            string result1 = _merger.MergeStrings(null, "test");
            string result2 = _merger.MergeStrings("test", null);
            string result3 = _merger.MergeStrings(null, null);
            Console.WriteLine($"TestWithNull: '{result1}', '{result2}', '{result3}'");
        }
    }
}
