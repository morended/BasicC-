using Xunit;
using CsharpBasics.basics;
using Shouldly;

namespace CSharpBasicsTests
{
   public class StructTests
    {
        [Fact]
        public void test_struct_usage()
        {
          Total.GetMarks("english").ShouldBe(90);
          Total.GetMarks("maths").ShouldBe(100);


        }
    }
}
