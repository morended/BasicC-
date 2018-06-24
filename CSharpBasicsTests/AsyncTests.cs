using System.Threading.Tasks;
using CsharpBasics.basics;
using Shouldly;
using Xunit;

namespace CSharpBasicsTests
{
    public class AsyncTests
    {
        private AsyncDemo ClassUnderTest = null;
       public AsyncTests()
        {
            ClassUnderTest = new AsyncDemo();
        }

        [Fact]
        public void runs_methods_synchromously()
        {
            Task.Run(() =>  ClassUnderTest.getAsyncResult()).GetAwaiter().GetResult();
            ClassUnderTest.result.ShouldBe(1000);
        }

        [Fact]
        //The async task tests are supoorted by all the frameworks. always use async task. 
        public async Task runs_method_asynchronously()
        {
            await ClassUnderTest.getAsyncResult();
            ClassUnderTest.result.ShouldBe(1000);
        }

        //Xunit supports void async tests. It provides its own synchornizationcontext in which the unit tests are executed.
        //It changes the environment in wihich the tests run.
        //async void unit tests are complicated for frameworks to support, require changes in test execution environment, and bring no benefit over async task tests.
        //With async void unit tests , it is difficult for the caller to know when it is completed. Creating custom synchornizationContext for async void methods to notfiy when they start and finish is a complex solution

        public async void Will_run_asynchronously_in_synchronization_context()
        {
            await ClassUnderTest.getAsyncResult();
            ClassUnderTest.result.ShouldBe(1000);
        }
    }
}
