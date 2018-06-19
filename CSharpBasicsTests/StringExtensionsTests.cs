using CsharpBasics.basics;
using Shouldly;
using Xunit;

namespace CSharpBasicsTests
{
    public class StringExtensionTests
    {

        [Fact]
        public void test_extension_method_returns_count_of_vowels_in_a_string()
        {
            string s = "abcgefghyio";
            s.CountVowels().ShouldBe(4);
        }
    }
}
