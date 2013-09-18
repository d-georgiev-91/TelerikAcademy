using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using Students.Models;

namespace Students.Services.Models
{
    [DataContract(IsReference = true)]
    public class StudentModel
    {
        public static Expression<Func<Student, StudentModel>> FromStudent
        {
            get
            {
                return s => new StudentModel()
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    School = new SchoolModel()
                    {
                        Name = s.School.Name,
                        Location = s.School.Location,
                    },
                };
            }
        }

        public void UpdateStudent(Student student)
        {
            if (student.FirstName != null)
            {
                student.FirstName = this.FirstName;
            }

            if (student.LastName != null)
            {
                student.LastName = this.LastName;
            }
        }

        [DataMember(Name = "firstName")]
        public int Id { get; set; }

        [DataMember(Name="firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "laststName")]
        public string LastName { get; set; }

        [DataMember(Name = "schoolName")]
        public SchoolModel School { get; set; }

        internal object CreateStudent()
        {
            return new Student()
            {
            };
        }
    }
}