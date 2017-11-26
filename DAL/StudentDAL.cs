using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class StudentDAL
    {
        public List<Student> GetAllStudents()
        {
            using (StudentsDDBBEntities db = new StudentsDDBBEntities())
            {
                return db.Student.ToList();
            }
        }

        public int GetAllStudentsCount()
        {
            using (StudentsDDBBEntities db = new StudentsDDBBEntities())
            {
                return db.Student.Count();
            }
        }

        public List<Student> GetAllStudents(string SearchBy, string Search, int page, int pageSize)
        {
            using (StudentsDDBBEntities db = new StudentsDDBBEntities())
            {
                List<Student> studentList = new List<Student>();
                page -= 1;
                if (string.IsNullOrEmpty(Search))
                {
                    studentList = db.Student.OrderBy(x => x.StudentId).Skip(page * pageSize).Take(pageSize).ToList();
                }
                else
                {
                    switch (SearchBy)
                    {
                        case "N":
                            studentList = db.Student.Where(x => x.FirstName.Contains(Search)).OrderBy(x => x.StudentId).Skip(page * pageSize).Take(pageSize).ToList();
                            break;
                        case "S":
                            studentList = db.Student.Where(x => x.Surname.Contains(Search)).OrderBy(x => x.StudentId).Skip(page * pageSize).Take(pageSize).ToList();
                            break;
                        case "C":
                            studentList = db.Student.Where(x => x.Course.Contains(Search)).OrderBy(x => x.StudentId).Skip(page * pageSize).Take(pageSize).ToList();
                            break;
                    }
                }
                return studentList; 
            }
        }

        public Student Details(int id = 0)
        {
            using (StudentsDDBBEntities db = new StudentsDDBBEntities())
            {
                return db.Student.Where(x=> x.StudentId == id).FirstOrDefault();
            }
        }

        public List<Student> Create(Student student)
        {
            using (StudentsDDBBEntities db = new StudentsDDBBEntities())
            {
                db.Student.Add(student);
                db.SaveChanges();
                return db.Student.ToList();
            }
        }

        public List<Student> Edit(Student student)
        {
            using (StudentsDDBBEntities db = new StudentsDDBBEntities())
            {
                db.Entry(student).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return db.Student.ToList();
            }
        }

        public List<Student> Delete(int id = 0)
        {
            using (StudentsDDBBEntities db = new StudentsDDBBEntities())
            {
                Student student = db.Student.Find(id);
                db.Student.Remove(student);
                db.SaveChanges();
                return db.Student.ToList();
            }
        }
    }
}
