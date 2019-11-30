using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SQLite;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{

    public class StudentDataAccessLayer
    {
        testContext db = new testContext();

        public IEnumerable<TblStudents> GetAllStudents()
        {
            try
            {
                return db.TblStudents.ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new employee record   
        public int AddEmployee(TblStudents student)
        {
            try
            {
                db.TblStudents.Add(student);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar employee  
        public int UpdateStudent(TblStudents student)
        {
            try
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

      

        //Get the details of a particular employee  
        public TblStudents GetStudentData(int id)
        {
            try
            {
                TblStudents student = db.TblStudents.Find(id);
                return student;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular employee  
        public int DeleteStudent(int id)
        {
            try
            {
                TblStudents std = db.TblStudents.Find(id);
                db.TblStudents.Remove(std);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Get the list of Cities  
        public List<TblGroups> GetGroups()
        {
            List<TblGroups> lstGroup = new List<TblGroups>();
            lstGroup = (from GroupList in db.TblGroups select GroupList).ToList();

            return lstGroup;
        }
    }
}

