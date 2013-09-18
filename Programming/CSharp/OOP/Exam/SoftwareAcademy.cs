using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace SoftwareAcademy
{
    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }

    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            ITeacher teacher = new Teacher(name);
            return teacher;
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            ILocalCourse localCourse = new LocalCourse(name, teacher, lab);
            return localCourse;
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            IOffsiteCourse offsiteCourse = new OffsiteCourse(name, teacher, town);
            return offsiteCourse;
        }
    }

    public abstract class Course : ICourse
    {
        string name;
        ITeacher teacher;
        IList<string> topics;

        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.topics = new List<string>();
        } 

        public IList<string> Topics
        {
            get
            {
                return this.topics;
            }
            set
            {
                this.topics = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public ITeacher Teacher
        {
            get
            {
                return this.teacher;
            }
            set
            {
                this.teacher = value;
            }
        }

        public void AddTopic(string topic)
        {
            Topics.Add(topic);
        }

        private string TopicAsString()
        {
            if (Topics.Count == 0)
            {
                return null;
            }
            else
            {
                StringBuilder topicsToString = new StringBuilder();
                foreach (var topic in Topics)
                {
                    topicsToString.AppendFormat("{0}, ", topic);
                }
                topicsToString.Length -= 2;
                return topicsToString.ToString();
            }
        }

        public override string ToString()
        {
            StringBuilder courseToString = new StringBuilder();
            courseToString.AppendFormat("Name={0};", this.Name);
            if (teacher != null)
            {
                courseToString.AppendFormat(" Teacher={0};", this.Teacher.Name);
            }
            if (TopicAsString() != null)
            {
                courseToString.AppendFormat(" Topics=[{0}];", this.TopicAsString());
            }
            return courseToString.ToString();
        }
    }

    public class LocalCourse : Course, ILocalCourse
    {
        string lab;

        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name, teacher)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    this.lab = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder localCourseAsString = new StringBuilder();
            localCourseAsString.AppendFormat("{0}: ", this.GetType().ToString().Replace("SoftwareAcademy.", String.Empty));
            localCourseAsString.Append(base.ToString());
            localCourseAsString.AppendFormat(" Lab={0};", this.Lab);
            localCourseAsString.Length--;
            return localCourseAsString.ToString();
        }
    }

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        string town;

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    this.town = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder offsiteCourseAsString = new StringBuilder();
            offsiteCourseAsString.AppendFormat("{0}: ", this.GetType().ToString().Replace("SoftwareAcademy.", String.Empty).ToString());
            offsiteCourseAsString.Append(base.ToString());
            offsiteCourseAsString.AppendFormat(" Town={0};", this.Town);
            offsiteCourseAsString.Length--;
            return offsiteCourseAsString.ToString();
        }
    }

    public class Teacher : ITeacher
    {
        string name;
        IList<ICourse> courses;

        public Teacher(string name)
        {
            this.Name = name;
            this.courses = new List<ICourse>();
        }

        public IList<ICourse> Courses
        {
            get
            {
                return this.courses;
            }
            set
            {
                this.courses = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public void AddCourse(ICourse course)
        {
            this.Courses.Add(course);
        }

        private string CoursesNamesAsString()
        {
            if (this.Courses.Count!=0)
            {
                StringBuilder coursesNames = new StringBuilder();
                foreach (var course in Courses)
                {
                    coursesNames.AppendFormat("{0}, ", course.Name);
                }
                coursesNames.Length -= 2;
                return coursesNames.ToString();
            }
            else
            {
                return null;
            }
        }

        public override string ToString()
        {
            StringBuilder teacherToString = new StringBuilder();
            teacherToString.AppendFormat("Teacher: Name={0};", this.Name);
            if (CoursesNamesAsString() != null)
            {
                teacherToString.AppendFormat(" Courses=[{0}];", CoursesNamesAsString());
            }
            teacherToString.Length--;
            return teacherToString.ToString();
        }
    }

    public class SoftwareAcademyCommandExecutor
    {
        static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using SoftwareAcademy;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}
