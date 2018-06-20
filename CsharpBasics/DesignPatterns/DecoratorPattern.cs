
namespace CsharpBasics.DesignPatterns
{

    /*
     * DecoratorPattern :
     * It gives a object different flavors without using inheritance.
     * It encourages composition over inheritance.
     * Using Decorator pattern we can add fucntionality to the objects at runtime.
     * with inheritance we might end up creating multiple classes for each combination of chracteristics
     * Decorator pattern allows a flexible way to extend  functionality without inheritance
     *
     * Implementing Decorator Pattern:
     * Decorator have same super type as the objects they decorate, so we can pass the decorated object in place of original object
     *Decorator can add its own behavior to the object before delegating to the object it decorates
     *Objects can be decorated at runtime with as many decorators as we like.
     *
     * 1. When to use the pattern? 
     *    Use this pattern if we have to add behavior to object at runtime.
     *    Use this when we have mutiple funcitonalities , but we donot know what combination or permutation of these functionalities to be used.
     *
     * 2.  How to migrate code to and from this pattern?
     *       Converting code from this pattern : create classes for each behavior by using inheritance
     *       Coverting to this pattern : If we have to create multiple classes using inheritance for each combination of behaviors ,
     *       create a decorator and add the behaviors as wrapper to the object.
     * 3.  What are the tradeoffs of using the pattern (strengths and weaknesses)?
     *       Strengths:
     *           Provides an alternative for subclassing to extend fucntionality - Prevents exploding class hierarchy
     *           Allows behavior modification at runtime.
     *           Supports Open for Extension, Closed for Modification principle
     *           Different permutations of behaviors can be applied to a object
     *           New behavior can be added without modifying the existing code
     *           Can add the same behavior multiple times with this pattern "Eg: Double Mocha with whip - Mocha added twice in the coffee"
     *           Can add or remove any behavior at runtime.
     *    DrawBacks:
     *           Decorators result in many small objects in our design, overuse can be complex
     *           Decorators can cause issues if the client relies heavily on concrete components.
     *           complex process of instantiating an object with many wrappers.
     * 4. What are the maintenance concerns with utilizing this pattern, both during development and when reading the code?
     *   Decorators can lead to a application with lots of small objects. It would be difficult for the programmer
     *   to understand and maintain the code.
     */
    public interface IRoomComponent
    {
        string Description { get;}
        double Cost();
    }

    public class ExceutiveSuiteRoom : IRoomComponent
    {
        public string Description { get;} = "Executive";
        public double Cost()
        {
            return 1000;
        }

    }

    public class PremierRoom : IRoomComponent
    {
        public string Description { get;} = "Premier";
        public double Cost()
        {
            return 1500;
        }
    }

    public abstract class RoomDecorator : IRoomComponent
    {
        private IRoomComponent _component;
        public RoomDecorator(IRoomComponent component)
        {
            _component = component;
        }
        public abstract string Description { get;}
        public abstract double Cost();
    }

    public class NonSmokingRoom : RoomDecorator
    {
        private IRoomComponent _component;
        public NonSmokingRoom(IRoomComponent component) : base(component)
        {
            _component = component;
            Description = _component.Description + " Non Smoking";
        }

        public override string Description { get; }
        public override double Cost()
        {
            return _component.Cost() + 400;
        }
    }

    public class SmokingRoom : RoomDecorator
    {
        private IRoomComponent _component;
        public SmokingRoom(IRoomComponent component) : base(component)
        {
            _component = component;
            Description = _component.Description + " Smoking";
        }

        public override string Description { get; }
        public override double Cost()
        {
            return _component.Cost() + 200;
        }
    }

    public class PoolSideRoom : RoomDecorator
    {
        private IRoomComponent _component;

        public PoolSideRoom(IRoomComponent component) : base(component)
        {
            _component = component;
            Description = _component.Description + " Pool Side";
        }

        public override string Description { get; }
        public override double Cost()
        {
            return _component.Cost() + 500;
        }
    }

    public class GardenViewRoom : RoomDecorator
    {
        private IRoomComponent _component;
        public GardenViewRoom(IRoomComponent component) : base(component)
        {
            _component = component;
            Description = _component.Description + " Garden View";
        }

        public override string Description { get; }
        public override double Cost()
        {
            return _component.Cost() + 200;
        }
    }

    public class OceanViewRoom : RoomDecorator
    {
        private IRoomComponent _component;
        public OceanViewRoom(IRoomComponent component) : base(component)
        {
            _component = component;
            Description = _component.Description + " Ocean View";
        }

        public override string Description { get; }
        public override double Cost()
        {
            return _component.Cost() + 700;
        }
    }
}
