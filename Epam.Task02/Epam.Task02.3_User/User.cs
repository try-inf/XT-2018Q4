using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._3_User
{
    class User
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string PName { get; set; }

        private DateTime bDate;

        public DateTime BDate
        {
            get { return bDate; }
            set
            {
                if (value < DateTime.Now.AddYears(-100))
                {
                    throw new ArgumentException("The date you wrote is incredibly distant.");
                }
                
                bDate = value;
            }
        }




        public User() { }

        public User(string fName, string lName, string pName, DateTime bDate)
        {
            FName = fName;
            LName = lName;
            PName = pName;
            BDate = bDate;
        }
    }
}
