using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using WebApp.Account.DataStore;
using WebApp.Account.Model;

namespace WebApp.Account.BLL
{
    [DataObject]
    public class AccountManager
    {
        public void SelfRegistration(CourseOffering course, UserAccount account)
        {
            // Look for the course
            var existingCourse = FileContext.FindCourse(course);
            if(existingCourse == null)
            {
                course.Students.Add(account.LoginName, account);
                FileContext.CreateCourse(course);
            }
            else
            {
                if (existingCourse.Students.ContainsKey(account.LoginName))
                    throw new Exception("Already registered");
                existingCourse.Students.Add(account.LoginName, account);
                FileContext.UpdateCourse(existingCourse);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<CourseOffering> ListAllCourses()
        {
            return FileContext.GetCourseOfferings();
        }
    }
}