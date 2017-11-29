using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicConnectionAplication
{
    public class Errors
    {
        public void WrongFillField(string errorCode, string typeColumn)
        {
            if (errorCode == "1")
            {
                MessageBox.Show("Musisz wprowadzić wartość w " + typeColumn + " !");
            }
            else if (errorCode == "2")
            {
                MessageBox.Show("Za duża wartość!");
            }
            else if (errorCode == "3")
            {
                MessageBox.Show("Wprowadź liczbę w formacie szesnastkowym!");
            }
            else if (errorCode == "5")
            {
                MessageBox.Show("Wprowadź liczbę w formacie dziesiętnym!");
            }
        }
    }
}
