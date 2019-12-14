using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject
{
    [Serializable]
    public class Student
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public List<Mark> Marks { get; set; }
        public Student()
        {
           Marks= new List<Mark>();
        }
        public void AddMark(string subject,int raiting)
        {
            Mark m = new Mark();
            m.Raiting = raiting;
            m.Subject = subject;
            Marks.Add(m);
        }
        public override string ToString()
        {
            string raiting = String.Empty;
            foreach (var item in Marks)
            {
                raiting += Environment.NewLine +item;
            }
            return $"{Name} {Lastname}, {Age}, {raiting}";
        }


    }
    [Serializable]
    public class Mark
    {
        public Mark()
        {

        }
        
        public int Raiting { get; set; }
        public string Subject { get; set; }
        public override string ToString()
        {
            return $"{Subject}--------------{Raiting}";
        }
    }

   
}
