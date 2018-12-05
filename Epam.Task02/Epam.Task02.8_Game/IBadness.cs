using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._8_Game
{
    interface IBadness
    {
        double Degree { get; set; }

        void MakePursuit();

    }
}
