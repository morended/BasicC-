using CsharpBasics.basics;
using Shouldly;
using Xunit;

namespace CSharpBasicsTests
{
    public class InterfaceTests
    {
        [Fact]
        public void schedule_service_using_interface()
        {
            IService facial = new Facial("abc","A1BeautySalon","4:30 PM");
            IService hairCut = new HairCut("def","A2HairSalon","6:30 PM");
            IService massage = new Massage("ghi" , "A3MassageCenter","5:40 PM");

            facial.ScheduleService().ShouldBe($"scheduled {facial.ServiceType} at {facial.Place} for {facial.Name} at {facial.Time}");
            hairCut.ScheduleService().ShouldBe($"scheduled {hairCut.ServiceType} at {hairCut.Place} for {hairCut.Name} at {hairCut.Time}");
            massage.ScheduleService().ShouldBe($"scheduled {massage.ServiceType} at {massage.Place} for {massage.Name} at {massage.Time}");
        }

        [Fact]

        public void test_explicit_interface()
        {
            FourWheeler fourWheeler = new Volvo();
            Car car = new Volvo();

            car.Type().ShouldBe("car");
            fourWheeler.Type.ShouldBe("fourwheeler");

            car.Drive().ShouldBe("driving a car");
            fourWheeler.Drive().ShouldBe("driving a four wheeler");

            Volvo volvo = new Volvo();

            volvo.Type().ShouldBe("car");

            //drive method is not available for the  derived class
            //volvo.Drive()

        }
    }
}
