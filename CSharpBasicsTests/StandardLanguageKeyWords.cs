using CsharpBasics.basics;
using Shouldly;
using Xunit;

namespace CSharpBasicsTests
{
    public enum state
    {
        on =0,
        off =1
    }
    public class StandardLanguageKeyWords
    {

        public  readonly string testreadonly ="test1";

       public StandardLanguageKeyWords()
        {
            testreadonly = "test2";
        }

        const int i = 12;
        [Fact]
        public void test_default_keyword()
        {
            int i=1;
            switch (i)
            {
                default:
                    i = 4;
                    break;
            }
           
            i.ShouldBe(4);
            default(string).ShouldBeNull();
            default(char).ShouldBe('\0');
            default(int?).ShouldBe(null);
            default(int).ShouldBe(0);
            default(state).ShouldBe(state.on);

            default(Subject).ShouldBe(new Subject(0,null));
        }

        [Fact]
        public void test_const_readonly_keyword()
        {
            StandardLanguageKeyWords.i.ShouldBe(12); // const is static by default

            testreadonly.ShouldBe("test2");
            StandardLanguageKeyWords t = new StandardLanguageKeyWords();
            t.testreadonly.ShouldBe("test2");
        }

        public int paramMethod(params int[] marks)
        {
            var total = 0;
            for (int i = 0; i < marks.Length; i++)
            {
                total += marks[i];
            }

            return total;

        }
        [Fact]
        public void test_params_keyword()
        {
            paramMethod(50, 60, 70, 80, 90, 100).ShouldBe(450);
            paramMethod(new int[] {50, 60, 70, 80, 90, 100}).ShouldBe(450);
            paramMethod().ShouldBe(0);

        }
    }

}
