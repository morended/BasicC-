using System.Collections.Generic;

namespace CsharpBasics.basics
{
    public struct Subject
    {
         public string Name;
         public int Marks;

        public Subject(int marks,string name)
        {
            Name = name;
            Marks = marks;
        }
        static Subject() { }
    }


   public class Total
    {
        public static int GetMarks(string name)
        {
            Subject maths = new Subject(100,"maths");
            Subject english;
            english.Marks = 90;
            english.Name = "english";

            List<Subject> subjectList = new List<Subject> {maths, english};

           return subjectList.Find(Subject => Subject.Name == name).Marks;
   
        }
    }
}
