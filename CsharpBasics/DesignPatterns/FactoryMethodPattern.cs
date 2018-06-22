using System.Runtime.InteropServices.WindowsRuntime;

namespace CsharpBasics.DesignPatterns
{

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
