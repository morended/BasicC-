using CsharpBasics.basics;
using Shouldly;
using Xunit;

namespace CSharpBasicsTests
{
    public class EnumTests
    {
        [Fact]
        public void test_enum_returns_color_code()
        {
            BasicEnum.TestColor((Color)0xFF0000).ShouldBe("red color");
            BasicEnum.TestColor(Color.Black).ShouldBe(null);
            BasicEnum.TestColor(Color.Blue).ShouldNotBe("green");
        }
    }
}
