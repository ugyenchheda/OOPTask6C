using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTask6C
{
    internal class Student
    {
        public static int index=0;

        public Student(int id, string studentName, 
            string address)
        {
            Id = id;
            StudentName = studentName;
            Address = address;
        }

        //public Student(int id, string studentName)
        //{
        //    Id = id;
        //    StudentName = studentName;
        //}

        public int Id { get; set; }
        public string StudentName { get; set; }
        public string Address { get; set; }

        //Static method
        public static int ProvideUniqueIdNumber()
        {
            return ++index;
        }

        public override string? ToString()
        {
            return String.Format("{0, -5} {1, -25} {2, -25}", Id, StudentName,
                (Address==null) ? "address not known" : Address);
        }
    }
}
