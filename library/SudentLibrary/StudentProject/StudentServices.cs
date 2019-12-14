using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;


namespace StudentProject
{
    public class StudentServices
    {
        private string path = "student.xml";
        public IEnumerable<Student> Students { get; set; }
        public StudentServices()
        {
            if (File.Exists(path))
                Load();
            else 
            Students = new List<Student>();
        }
        public void Add(Student st)
        {
            (Students as List<Student>).Add(st);
        }
        public void Remove(string lastname)
        {
            List<Student> temp = (Students as List<Student>);
           temp.Remove(temp.Find(st => st.Lastname.Equals(lastname)));

        }
        public void Save()
        {
            Type[] types={typeof(Student), typeof(Mark) };
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Student>),types);
                formatter.Serialize(fs, Students);
            }
        }
        private void Load()
        {
            Type[] types = { typeof(Mark),typeof(Student) };
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                
                XmlSerializer formatter = new XmlSerializer(typeof(List<Student>), types);
                Students =(List<Student>)formatter.Deserialize(fs);
            }
        }
        private List<double> FindAvg()
        {
            List<double> avg = new List<double>();
            foreach (Student item in Students)
            {
                avg.Add(item.Marks.Average(m => m.Raiting));
            }
            return avg;
        }
        public Student FindBestStudent()
        {
            List<double> avgMarks = FindAvg();
            double maxMark = avgMarks.Max();
            int index = avgMarks.IndexOf(maxMark);
            return (Students as List<Student>)[index];
            
        }
    }
}
