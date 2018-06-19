
namespace CsharpBasics.basics
{
    //Interface acts as a contract for classes that inherit from it.
    //properties and methods of an interface are by default public.
    //Interface cannot be instantiated directly
    //we can implement multiple interfaces
    public interface IService
    {
        string Name { get; set; }
        string Place { get; set; }
        string Time { get; set; }
        string ServiceType { get; set; }
        string ScheduleService();
    }

    public class HairCut : IService
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public string Time { get; set; }
        public string ServiceType { get; set; } = "haircut";

        public HairCut(string name, string place, string time)
        {
            Name = name;
            Place = place;
            Time = time;
        }
        public string ScheduleService()
        {
            return $"scheduled {ServiceType} at {Place} for {Name} at {Time}";
        }
    }

    public class Facial : IService
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public string Time { get; set; }
        public string ServiceType { get; set; } = "facial";
        public Facial(string name, string place, string time)
        {
            Name = name;
            Place = place;
            Time = time;
        }
        public string ScheduleService()
        {
            return $"scheduled {ServiceType} at {Place} for {Name} at {Time}";
        }
    }

    public class Massage : IService
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public string Time { get; set; }
        public string ServiceType { get; set; } = "massage";

        public Massage(string name, string place, string time)
        {
            Name = name;
            Place = place;
            Time = time;
        }
        public string ScheduleService()
        {
            return $"scheduled {ServiceType} at {Place} for {Name} at {Time}";
        }
    }

    // Explicit Interface
    // When a child class is inherited from two interfaces which have same method but differ in functionality,
    // to create the method specific to a interface we use explicit interface implementation.
    // These methods are only accessible by the respective interfaces and cannot be accessed by the derived class
    public interface FourWheeler
    {
        string Type { get;}
        string Drive();
    }

    public interface Car
    {
        string Drive();
        string Type();

    }

    public class Volvo : Car, FourWheeler
    {
        //This method is accessible only to FourWheeler Interface
        string FourWheeler.Type { get; } = "fourwheeler";
        string FourWheeler.Drive()
        {
            return "driving a four wheeler";
        }

        public string Type()
        {
            return "car";
        }

        //This method is accessible only to Car Interface
        string Car.Drive()
        {
            return "driving a car";
        }

    }
}

