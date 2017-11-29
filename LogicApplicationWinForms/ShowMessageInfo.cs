using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicConnectionAplication
{
    public class ShowMessageInfo
    {
        public void ShowMessage()
        {
            string message = "Icons made by Dave Gandy, Madebyoliver, Gregor Cresnar, Cursor Creative, Google, Freepik, Lucy G, Gregor Cresnar from www.flaticon.com\nCreated and developed for Tomsad. All rights reserved.\nLearn more on www.programatory.com";
            string caption = "Copyrights info";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
        }
    }
}
