using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Students.Data;
using Students.Models;
using Students.Repositories;
using Students.Services.Models;

namespace Students.Services.Controllers
{
    public class StudentsController : ApiController
    {
        private readonly IRepository<Student> data;

        public StudentsController(IRepository<Student> data)
        {
            this.data = data;
        }


        public StudentsController()
        {
            this.data = new EfRepository<Student>(new StudentsContext());
        }

        public IQueryable<StudentModel> Get()
        {
            var students = this.data.All().Select(StudentModel.FromStudent);

            return students;
        }

        // GET api/students/5
        public HttpResponseMessage Get(int id)
        {
            var student = this.data.All().Where(s => s.Id == id).Select(StudentModel.FromStudent).FirstOrDefault();

            if (student == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student not found.");
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, student);
        }

        // POST api/students
        public HttpResponseMessage Post([FromBody]StudentModel value)
        {
            var student = value.CreateStudent();

            this.data.Add(student);

            var message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(this.Request.RequestUri + student.Id.ToString(CultureInfo.InvariantCulture));

            return message;
        }
    }
}
