
namespace CsharpBasics.basics
{
   public class Student
        {

            private string _name; // field

            public string Name
            {
                // property
                get { return _name; }
                set
                {
                    _name = value;
                }
            }

            public int Marks { get; set; } // Auto property

            public string Result // read only property
            {
                get
                {
                    string leftAlignment = $"{"Left Alignment",-10}";
                    string rightAlignment = $"{"Right Alignment",10}";
                    string formatString = $"{10.16:P}";
                    if (Marks < 0) return "Invalid Marks";
                    return Marks > 50 ? "Pass" : "Fail";
                }
            }

            private int _percentage;
            public int Percentage
            {
                get { return _percentage; }
                set => _percentage = value == 0 ? Marks / 100 : 35;
            }

            public string Grade { get; set; } = "A"; // default auto property intialization

        }

  
}
