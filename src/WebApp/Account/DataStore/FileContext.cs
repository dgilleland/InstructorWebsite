using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LiteDB;
using Newtonsoft.Json;
using WebApp.Account.Model;

namespace WebApp.Account.DataStore
{
    public class FileContext
    {
        private static string Connection = HttpContext.Current.Server.MapPath("~/App_Data/AIs.json");
        public static IEnumerable<UserAccount> GetInstructors()
        {
            using (var db = new LiteDatabase(Connection))
            {
                var data = db.GetCollection<UserAccount>();
                var instructors = data.FindAll();
                return instructors;
            }
        }

        public static IEnumerable<CourseOffering> GetCourseOfferings()
        {
            using (var db = new LiteDatabase(Connection))
            {
                return db.GetCollection<CourseOffering>().FindAll();
            }
        }

        public static CourseOffering FindCourse(CourseOffering searchCourse)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var courses = db.GetCollection<CourseOffering>();
                var results = courses.Find(x => x.CourseNumber == searchCourse.CourseNumber && x.Term.TermId == searchCourse.Term.TermId && x.Section == searchCourse.Section).SingleOrDefault();
                return results;
            }
        }

        public static void CreateCourse(CourseOffering course)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var courses = db.GetCollection<CourseOffering>();
                courses.Insert(course);
            }
        }

        public static void UpdateCourse(CourseOffering course)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var courses = db.GetCollection<CourseOffering>();
                courses.Update(course);
            }
        }



        //public static IEnumerable<string> GetCourseOfferingFiles()
        //{
        //    return null;
        //}
        //// Filename patterns:
        ////  AIs.json = Admin Instructors
        ////  {CourseNumber}-{Year}-{TermStart}-{Section}

        //private static string GetFileName()
        //{
        //    return ;
        //}

        //private static string GetFileName(CourseOffering offering)
        //{
        //    if (offering == null)
        //        throw new ArgumentNullException(nameof(offering), "Cannot generate file name from null offering");
        //    var fileName = $"{offering.CourseNumber}-{offering.Term.SchoolYear}-{offering.Term.Start}-{offering.Section}";
        //    if (string.IsNullOrWhiteSpace(fileName.Replace("-", "")))
        //        throw new ArgumentException("Cannot generate file name from blank offering", nameof(offering));
        //    return HttpContext.Current.Server.MapPath($"~/App_Data/{fileName}.json");
        //}
    }
}