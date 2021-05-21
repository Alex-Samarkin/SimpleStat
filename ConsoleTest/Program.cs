using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCL;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            TStudent stud = new TStudent();
            Console.WriteLine(stud.UserName.FullName());
            Console.WriteLine(stud.UserName.ShortName());
            Console.WriteLine(stud.Age.GetAgeWithDate());
            stud.Age.Age = 20;
            Console.WriteLine(stud.Age.GetAgeWithDate());
            Console.WriteLine(stud.StudData.GetShortGroup());
            Console.ReadLine();
        }
    }
}
