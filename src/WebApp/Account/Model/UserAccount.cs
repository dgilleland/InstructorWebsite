using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Account.Model
{
    public class UserAccount
    {
        public int Id { get; set; }

        public string LoginName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string GitHubUsername { get; set; }
    }
    public class CourseOffering
    {
        public int Id { get; set; }

        public string CourseNumber { get; set; }
        public string Section { get; set; }
        public string Name { get; set; }
        public UserAccount Instructor { get; set; }
        public Term Term { get; set; }

        public Dictionary<string, UserAccount> Students { get; set; }
            = new Dictionary<string, UserAccount>();

        public static CourseOffering Create(string fullCourseName, string shortCourseName)
        {
            //&c_fn=CPSC1520 - Javascript (2016/2017 Winter Term (1162)) (A03)
            //&c_sn=CPSC1520.1162.A03.REG.1
            var c_sn = shortCourseName.Split('.');
            // "clean" full course name
            //  0) "CPSC1520 - Javascript (2016/2017 Winter Term (1162)) (A03)"
            fullCourseName = fullCourseName.Replace($"{c_sn[0]} - ", "");
            fullCourseName = fullCourseName.Replace($" ({c_sn[1]})", "");
            fullCourseName = fullCourseName.Replace($" ({c_sn[2]})", "");
            //  1) "Javascript (2016/2017 Winter Term)"
            string name = fullCourseName.Substring(0, fullCourseName.IndexOf(" (20"));
            fullCourseName = fullCourseName.Replace($"{name} (","").Replace(")","");
            //  2) "2016/2017 Winter Term"
            var termInfo = fullCourseName.Split(' ');
            var result = new CourseOffering
            {
                CourseNumber = c_sn[0],
                Section = c_sn[2],
                Name = name,
                Term = new Term
                {
                    TermId = c_sn[1],
                    Name = fullCourseName,
                    SchoolYear = termInfo[0].Replace("/","."),
                    Start = termInfo[1].Equals("Winter") ? TermStart.Jan
                          : termInfo[1].Equals("Fall") ? TermStart.Sept : TermStart.May
                }
            };

            return result;
        }
    }

    public class Term
    {
        public int Id { get; set; }

        public string TermId { get; set; }
        public string Name { get; set; }
        public string SchoolYear { get; set; }
        public TermStart Start { get; set; }        
    }
    public enum TermStart { Sept, Jan, May }
}