using System;
using System.Linq;
using System.Text;

namespace Student
{
    class Student : ICloneable, IComparable<Student>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private int ssn;
        private string permanentAddress;
        private string mobilePhone;
        private string email;
        private int course;
        private Specialty specialty;
        private University university;
        private Faculty faculty;

        public Student()
        {

        }

        public Student(string firstName, string middleName, string lastName, string address, string mobilePhone, string email, int course, int ssn, Specialty specialty, University university, Faculty faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.PermanentAddress = address;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.Ssn = ssn;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        public override int GetHashCode()
        {
            return (this.FirstName.GetHashCode() ^ this.MiddleName.GetHashCode() ^ this.LastName.GetHashCode() ^ this.PermanentAddress.GetHashCode() ^ this.MobilePhone.GetHashCode() ^ this.Course.GetHashCode() ^ this.Ssn.GetHashCode() ^ this.Specialty.GetHashCode() ^ this.University.GetHashCode() ^ this.Faculty.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            Student student = obj as Student;

            if ((object)student == null)
            {
                return false;
            }

            if (!Object.Equals(this.Ssn, student.Ssn))
            {
                return false;
            }

            return true;
        }

        public static bool operator ==(Student studentFirst, Student studentSecond)
        {
            return Student.Equals(studentFirst, studentSecond);
        }

        public static bool operator !=(Student studentFirst, Student studentSecond)
        {
            return !Student.Equals(studentFirst, studentSecond);
        }

        public override string ToString()
        {
            StringBuilder studentToString = new StringBuilder();
            studentToString.AppendLine("First name: " + this.FirstName);
            studentToString.AppendLine("Middle name: " + this.MiddleName);
            studentToString.AppendLine("Last name: " + this.LastName);
            studentToString.AppendLine("Permanent address: " + this.PermanentAddress);
            studentToString.AppendLine("Mobile phone: " + this.MobilePhone.ToString());
            studentToString.AppendLine("Course: " + this.Course.ToString());
            studentToString.AppendLine("SSN: " + this.Ssn.ToString());
            studentToString.AppendLine("Specialty: " + this.Specialty.ToString());
            studentToString.AppendLine("University: " + this.University.ToString());
            studentToString.AppendLine("Faculty: " + this.Faculty.ToString());

            return studentToString.ToString();
        }

        public Student Clone()
        {
            Student copy = new Student(
                this.FirstName, this.MiddleName, this.LastName, this.PermanentAddress, 
                this.MobilePhone, this.Email, this.Course, this.Ssn, this.Specialty, this.University,
                this.Faculty);
            return copy;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public int CompareTo(Student student)
        {
            if (this.LastName != student.LastName)
            {
                return String.Compare(this.LastName, student.LastName);
            }

            if (this.MiddleName != student.MiddleName)
            {
                return String.Compare(this.MiddleName, student.MiddleName);
            }

            if (this.FirstName != student.FirstName)
            {
                return String.Compare(this.FirstName, student.FirstName);
            }

            if (this.Ssn != student.Ssn)
            {
                return (this.Ssn - student.ssn);
            }
            return 0;
        }

        public Faculty Faculty
        {
            get
            {
                return this.faculty;
            }
            set
            {
                this.faculty = value;
            }
        }

        public University University
        {
            get
            {
                return this.university;
            }
            set
            {
                this.university = value;
            }
        }

        public Specialty Specialty
        {
            get
            {
                return this.specialty;
            }
            set
            {
                this.specialty = value;
            }
        }

        public int Course
        {
            get
            {
                return this.course;
            }
            set
            {
                this.course = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return this.mobilePhone;
            }
            set
            {
                this.mobilePhone = value;
            }
        }

        public string PermanentAddress
        {
            get
            {
                return this.permanentAddress;
            }
            set
            {
                this.permanentAddress = value;
            }
        }

        public int Ssn
        {
            get
            {
                return this.ssn;
            }
            set
            {
                this.ssn = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            set
            {
                this.middleName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }
    }
}
