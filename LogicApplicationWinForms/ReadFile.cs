using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicConnectionAplication
{
    public class ReadFile
    {
        public OpenFileDialog ReadDataFile;

        public ReadFile(OpenFileDialog ReadDataFile)
        {
            this.ReadDataFile = ReadDataFile;
        }

        public void ShowDialogRead()
        {
            ReadDataFile.Filter = "Text Files (*.txt)|*.txt";
            ReadDataFile.Title = "Export frames to textfile";
            ReadDataFile.ShowDialog();
        }

        public void Read(DataGridView rows)
        {
            try
            {   
                using (StreamReader sr = new StreamReader(ReadDataFile.FileName))
                {
                    string line = null;

                    while (null != (line = sr.ReadLine()))
                    {
                        string[] values = line.Split(',');

                        rows.Rows.Add(values[0].Remove(0,2), values[1], values[2], values[3], values[4], values[5], ".", "0");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Plik nie został odnaleziony!");
            }
        }
    }
}
