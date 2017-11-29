using LogicConnectionAplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectionDesktopApp
{
    public partial class MessgeBoxSaveAndRead : Form
    {
        public MessgeBoxSaveAndRead()
        {
            InitializeComponent();
        }
        DataGridView rows;

        public void GetTableRowsGird(DataGridView rows)
        {
            this.rows = rows;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveDataToFile save = new SaveDataToFile(new SaveFileDialog());
            save.ShowDialogSave();
            save.SaveData(rows);
        }

        private void Read_Click(object sender, EventArgs e)
        {
            rows.Rows.Clear();
            ReadFile(rows);
        }

        public void ReadFile(DataGridView rows)
        {
            ReadFile read = new ReadFile(new OpenFileDialog());
            read.ShowDialogRead();
            read.Read(rows);
        }

        private void MessgeBoxSaveAndRead_Load(object sender, EventArgs e)
        {

        }
    }
}
