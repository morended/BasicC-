

namespace CsharpBasics.DesignPatterns
{

    /* Factory Patterns encapsulate the object creation. 
     *  Factory method pattern defines an inerface for creating object, encapsulates object creation by allowing subclasses to decide on which product to create.
     * Factory method lets a class defer instantiation to subclasses.
     * Creator class do not have knowledge about the prodcusts that will be created.
     *  It can be implemeneted using abstract class with some fucntions and an abstract create method or a virtual create method with default object creation
     *
     * Terminology
     * Creator: IT is a class that contains implementations for all of the methods to manipulate the products, except factory method used  for the object creation 
     * ConcreteCreator: These classes implement the factory method which has logic to create the family of products.
     * Product: Factory methods are used to create the products
     * ConcreteProduct : ConcreProducts implement the Product and have there own  personal flavor added.
     *
     *
     * 1) When to use the pattern? When not to?
     * When there are several family of prodcuts the Creator needs to create objects based on the input parameter passed.
     * Use Factory Method pattern when you want the creator decoupled from concrete products creation
     *2) when  not to use the pattern?
     * If there are few product types and no new product types will be added in future
     * If product types donot share a common behavior
     * 3) Strengths
     * Loose coupling between the Client code and creation of concrete product types
     * Adheres to open -close Principle, extensible - can create new product types at runtime using subclasses
     *Objects are created at one place. This avoids duplication.
     * This allowes to program to an interface rather than a implementation and hence extensible in future
     * Easy to test as it is easy to mock the creation of objects
     *
     * 4) Weaknesses
     *Passing in string parameters to create object is not type safe and may cause run time error
     * Have to create a subclass to create an object of a product
     *
     * 5) Where is it used or misused in our code.
     * IResponseProcedureFactory :  extend-health/communications-response-group-routing
     * We can avoid creating factory method for this as there is only one concrete product(ResponseProcedure) and one concrete creator(ResponseProcedureFactory) for this factory.
     * Might have been created to provide extensibility
     *
     * 6) Maintenance Concerns
     * Working with factory methods using DI is tricky.
     * We may end up creating too many objects. Use DI to create objects
     *
     * */
    #region Abstract and Concrete Products

    public abstract class Member
    {
        public string Name { get; set; }
        public string phone { get; set; }

        public string Address { get; set; }

        public string signup()
        {
            return "registered";
        }

        public string login()
        {
            return "logged in";
        }

        public string PersonalInfo()
        {
            return Name + phone + Address;
        }
    }

    public class BasicMember : Member
    {
        public int membershipPrice()
        {
            return 10;
        }
    }

    public class ClubMember : Member
    {
        public int membershipPrice()
        {
            return 100;
        }

        public int discount()
        {
            return 10;
        }
    }

    #region Membership from Chicago City

    public class ChicagoBasicMember : Member
    {
        public int membershipPrice()
        {
            return 20;
        }

        public string JoiningOffer()
        {
            return "swimming & Zumba included in basic membership";
        }
    }

    public class ChicagoClubMember : Member
    {
        public int membershipPrice()
        {
            return 200;
        }

        public int discount()
        {
            return 20;
        }
    }

    #endregion

    #region Membership from California City

    public class SFOBasicMember : Member
    {
        public int membershipPrice()
        {
            return 100;
        }

    }

    public class SFOClubMember : Member
    {
        public int membershipPrice()
        {
            return 300;
        }

        public int discount()
        {
            return 30;
        }
    }

    #endregion

    #endregion

    #region Creator Classes - Abstract and  Concrete

    public abstract class MemberShipManager{
        public void JoinGym(string type)
        {
            Member m = CreateObject(type);
            m.signup();
            m.login();

        }

        public abstract Member CreateObject(string type);

    }

    public class SFOMemberShipManager : MemberShipManager{
        public override Member CreateObject(string type)
        {
            if (type == "basic") return new SFOBasicMember();
            return new SFOClubMember();
        }
    }

    public class ChicagoMemberShipManager : MemberShipManager
    {
        public override Member CreateObject(string type)
        {
            if (type == "basic") return new ChicagoBasicMember();
            return new ChicagoClubMember();
        }
    }

    #endregion
}
