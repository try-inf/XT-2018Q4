using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task06_Users.Entities
{
    public class Award
    {
        private string _title;

        public int Id { get; set; }

        public string Title
        {
            get
            {
                return this._title;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Title is empty.");
                }
                else
                {
                    this._title = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{Id} {Title}";
        }
    }
}
