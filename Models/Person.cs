using System;

namespace People.API.Models {     
    public class Person
    {        
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Description { get; set; }

        public int Age
        {
            get
            {
                var dayDiff = (DateTime.Now - BirthDate).TotalDays;

                return Convert.ToInt32(dayDiff / 365);
            }
        }
    }
}