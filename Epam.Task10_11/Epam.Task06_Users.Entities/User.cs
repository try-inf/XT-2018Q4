using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task06_Users.Entities
{
    public class User
    {
        private string _name;
        private DateTime _dateOfBirth;

        public int Id { get; set; }

        public string Name
        {
            get
            {
                return this._name;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("User name is empty.");
                }
                else
                {
                    this._name = value;
                }
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return this._dateOfBirth;
            }

            set
            {
                if (this.CheckDateOfBirth(value))
                {
                    this._dateOfBirth = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect Date of birth");
                }
            }
        }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {DateOfBirth} {Age}";
        }

        public bool CheckDateOfBirth(DateTime date)
        {
            if (date > DateTime.Now)
            {
                throw new ArgumentException("You entered Date of birth later than " +
                    "the current date.  ");
            }
            else if (date < DateTime.Now.AddYears(-130))
            {
                throw new ArgumentException("It could hardly be truth that User is older then 130 years old!");
            }
            else
            {
                return true;
            }
        }
    }
}
