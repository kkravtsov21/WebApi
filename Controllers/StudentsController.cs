using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    public class StudentsController : Controller
    {
        StudentDataAccessLayer objemployee = new StudentDataAccessLayer();

        [HttpGet]
        [Route("api/Students/Index")]
        public IEnumerable<TblStudents> Index()
        {
            return objemployee.GetAllStudents();
        }

        [HttpPost]
        [Route("api/Students/Create")]
        public int Create([FromBody] TblStudents student)
        {
            return objemployee.AddEmployee(student);
        }

        [HttpGet]
        [Route("api/Students/Details/{id}")]
        public TblStudents Details(int id)
        {
            return objemployee.GetStudentData(id);
        }

        [HttpPut]
        [Route("api/Students/Edit")]
        public int Edit([FromBody]TblStudents student)
        {
            return objemployee.UpdateStudent(student);
        }

        [HttpDelete]
        [Route("api/Students/Delete/{id}")]
        public int Delete(int id)
        {
            return objemployee.DeleteStudent(id);
        }

        [HttpGet]
        [Route("api/Students/GetGroupList")]
        public IEnumerable<TblGroups> Details()
        {
            return objemployee.GetGroups();
        }
    }
}

