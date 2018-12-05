using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._5_Employee
{

    class Employee : User
    {
        private int seniority;
        public int Seniority
        {
            get { return seniority; }
            set
            {
                if ((DateTime.Now.Year - BDate.Year) < value)
                {
                    throw new ArgumentException("Your seniority should be less than your age.");
                }
                seniority = value;
            }
        }

        public string Position { get; set; }


        public Employee() { }

        public Employee(string fName, string lName, string pName, DateTime bDate, 
            int seniority, string position)
            : base(fName, lName, pName, bDate)
        {
            Seniority = seniority;
            Position = position;
        }
    }
}
