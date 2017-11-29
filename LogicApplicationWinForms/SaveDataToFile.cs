using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicConnectionAplication
{
    public class SaveDataToFile
    {
        public SaveFileDialog saveFile;

        public SaveDataToFile(SaveFileDialog saveFile)
        {
            this.saveFile = saveFile;
        }

        public void ShowDialogSave()
        {
            saveFile.Filter = "Text Files (*.txt)|*.txt";
            saveFile.Title = "Export frames to textfile";
            saveFile.ShowDialog();
        }

        public void SaveData(DataGridView rows)
        {
            try
            {
                StreamWriter writer = new StreamWriter(saveFile.OpenFile());

                foreach (DataGridViewRow row in rows.Rows)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append("0x" + row.Cells["StandardID"].Value.ToString());
                    sb.Append(",");
                    sb.Append(row.Cells["ExtendedID"].Value.ToString());
                    sb.Append(",");
                    sb.Append(row.Cells["IDE"].Value.ToString());
                    sb.Append(",");
                    sb.Append(row.Cells["RTR"].Value.ToString());
                    sb.Append(",");
                    sb.Append(row.Cells["DLC"].Value.ToString());
                    sb.Append(",");
                    sb.Append(row.Cells["Data"].Value.ToString());

                    writer.WriteLine(sb.ToString());
                }
                writer.Close();
            }
            catch{ }
            
        }
    }
}
