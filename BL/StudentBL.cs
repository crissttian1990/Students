using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BL
{
    public class StudentBL
    {
        public static List<Student> GetAllStudents()
        {
            StudentDAL obj = new StudentDAL();
            return obj.GetAllStudents();
        }

        public static int GetAllStudentsCount()
        {
            StudentDAL obj = new StudentDAL();
            return obj.GetAllStudentsCount();
        }

        public static List<Student> GetAllStudents(string SearchBy, string Search, int page, int pageSize)
        {
            StudentDAL obj = new StudentDAL();
            return obj.GetAllStudents(SearchBy, Search, page, pageSize);
        }

        public static Student Details(int id = 0)
        {
            StudentDAL obj = new StudentDAL();
            return obj.Details(id);
        }

        public static List<Student> Create(Student student)
        {
            StudentDAL obj = new StudentDAL();
            return obj.Create(student);
        }

        public static List<Student> Edit(Student student)
        {
            StudentDAL obj = new StudentDAL();
            return obj.Edit(student);
        }

        public static List<Student> Delete(int id = 0)
        {
            StudentDAL obj = new StudentDAL();
            return obj.Delete(id);
        }
    }
}
