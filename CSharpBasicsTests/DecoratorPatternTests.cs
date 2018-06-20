
using CsharpBasics.DesignPatterns;
using Shouldly;
using Xunit;

namespace CSharpBasicsTests
{
    public class DecoratorPatternTests
    {
        [Fact]
        public void book_pool_side_Non_smoking_Executive_Room()
        {
            IRoomComponent roomComponent = new ExceutiveSuiteRoom();
            roomComponent =new PoolSideRoom(new NonSmokingRoom(roomComponent));

            roomComponent.Description.ShouldBe("Executive Non Smoking Pool Side");
            roomComponent.Cost().ShouldBe(1900);

        }

        [Fact]
        public void book__Premier_Smoking_PoolSide_GardenView_OceanView_Room()
        {
            IRoomComponent roomComponent = new PremierRoom();
            roomComponent = new OceanViewRoom(new GardenViewRoom(new PoolSideRoom(new SmokingRoom(roomComponent))));
            roomComponent.Description.ShouldBe("Premier Smoking Pool Side Garden View Ocean View");
            roomComponent.Cost().ShouldBe(3100);

        }
    }
}
