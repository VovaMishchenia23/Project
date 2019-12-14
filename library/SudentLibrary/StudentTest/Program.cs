using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject;

namespace StudentTest
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentServices services = new StudentServices();
            services.Add(new Student
            {
                Name = "Ivan",
                Age = 20,
                Lastname = "Ivanov",
            });
            services.Add(new Student
            {
                Name = "Petro",
                Age = 22,
                Lastname = "Petrenko",
            });
            Random rand = new Random();

            foreach (Student item in services.Students)
            {
                item.AddMark("C++", rand.Next(1, 12));
                item.AddMark("C#", rand.Next(1, 12));
            }
            services.Save();
            foreach (Student item in services.Students)
            {
                Console.WriteLine(item);
            }
            Student best = services.FindBestStudent();
            Console.WriteLine($"Best student is {best}");
            



        }
    }
}
