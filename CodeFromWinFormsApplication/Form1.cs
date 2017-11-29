
using LogicConnectionAplication;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConnectionDesktopApp
{
    public partial class SmartConnection : MetroFramework.Forms.MetroForm
    {
        OperationsOnRowsTable operations = new OperationsOnRowsTable();
        ConvertingOnDiffrentNumericSystems convert;
        FillingFields fields;
        Errors errors;
        int EmulatorToggle = 0;

        public SmartConnection()
        {
            InitializeComponent();

            convert = new ConvertingOnDiffrentNumericSystems();
            fields = new FillingFields(convert);
            errors = new Errors();

            UsbNotification.RegisterUsbDeviceNotification(this.Handle);

            DataTableGrid.AllowUserToAddRows = false;
        }

        private void standardIDTexbox_Click(object sender, System.EventArgs e)
        {
            if (standardIDTexbox.Text == "Standard ID") standardIDTexbox.Text = null;
        }

        private void standardIDTexbox_leave(object sender, System.EventArgs e)
        {
            if (standardIDTexbox.Text == "") standardIDTexbox.Text = "Standard ID";
        }

        private void ExtendedIDTextBox_Click(object sender, System.EventArgs e)
        {
            if (ExtendedIDTextBox.Text == "Extended ID") ExtendedIDTextBox.Text = null;
        }

        private void ExtendedIDTextBox_Leave(object sender, System.EventArgs e)
        {
            if (ExtendedIDTextBox.Text == "") ExtendedIDTextBox.Text = "Extended ID";
        }

        private void IDETextBox_Click(object sender, System.EventArgs e)
        {
            if (IDETextBox.Text == "IDE") IDETextBox.Text = null;
        }

        private void IDETextBox_Leave(object sender, System.EventArgs e)
        {
            if (IDETextBox.Text == "") IDETextBox.Text = "IDE";
        }

        private void RTRTextBox_Click(object sender, System.EventArgs e)
        {
            if (RTRTextBox.Text == "RTR") RTRTextBox.Text = null;
        }

        private void RTRTextBox_Leave(object sender, System.EventArgs e)
        {
            if (RTRTextBox.Text == "") RTRTextBox.Text = "RTR";
        }

        private void DataTextBox_Click(object sender, System.EventArgs e)
        {
            if (DataTextBox.Text == "Data") DataTextBox.Text = null;
        }

        private void DataTextBox_Leave(object sender, System.EventArgs e)
        {
            if (DataTextBox.Text == "") DataTextBox.Text = "Data";
        }

        private void AddFrameButton_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> valuesInColumn = new Dictionary<string, string>();

            string FieldStandardID = fields.FillingField(standardIDTexbox.Text, "Standard ID", 2047);
            errors.WrongFillField(FieldStandardID,"Standard ID");

            string FieldExtendedID = fields.FillingField(ExtendedIDTextBox.Text, "Extended ID", 262143);
            errors.WrongFillField(FieldExtendedID, "Extended ID");

            string FieldIDEID = fields.FillFieldIDE(IDETextBox.Text);

            string FielRTRID = fields.FillFieldRTR(RTRTextBox.Text);

            valuesInColumn.Add("Standard ID", FieldStandardID);

            valuesInColumn.Add("Extended ID", FieldExtendedID);

            valuesInColumn.Add("IDE", FieldIDEID);

            valuesInColumn.Add("RTR", FielRTRID);

            DataTableGrid.Rows.Add(valuesInColumn["Standard ID"], "0x"+valuesInColumn["Extended ID"], valuesInColumn["IDE"], valuesInColumn["RTR"], "1", DataTextBox.Text, ".", "0");
        }

        private void RemoveSelectedButton_Click(object sender, System.EventArgs e)
        {
            operations.RemoveSelectedRow(DataTableGrid);
        }

        private void UpButton_Click(object sender, System.EventArgs e)
        {
            operations.UpRow(DataTableGrid);
        }

        private void DownButton_Click(object sender, System.EventArgs e)
        {
            operations.DownRow(DataTableGrid);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DataTableGrid.Rows.Clear();
        }

        private void RemoveDupplicatesButton_Click(object sender, System.EventArgs e)
        {
            operations.RemoveDuplicatedRows(DataTableGrid);
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SaveButtonInputSelect_Click(object sender, System.EventArgs e)
        {

        }

        private void SmartConnection_Load(object sender, System.EventArgs e)
        {

        }

        private void metroGrid1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataFormatButton_Click_1(object sender, System.EventArgs e)
        {
            DataFormatButton.Text = convert.ChangeTextOnButtonSystemConverting();

            List<string> columnStandardID = new List<string>();
            List<string> columnExtendedID = new List<string>();

            for (int i = 0; i < DataTableGrid.RowCount; i++)
            {
                columnStandardID.Add(DataTableGrid.Rows[i].Cells[0].Value.ToString());
                columnExtendedID.Add(DataTableGrid.Rows[i].Cells[1].Value.ToString().Remove(0, 2));
            }

            DataTableGrid.Rows.Clear();

            if (DataFormatButton.Text == "Data format: HEX")
            {
                string [] ValesStandardID = convert.ConvertColumnsTableGridOnHEX(columnStandardID);
                string [] ValesExtendedID = convert.ConvertColumnsTableGridOnHEX(columnExtendedID);

                AddColumnsToTable(ValesStandardID, ValesExtendedID);
            }
            else
            {
                string[] ValesStandardID = convert.ConvertColumnsTableGridOnDEC(columnStandardID);
                string[] ValesExtendedID = convert.ConvertColumnsTableGridOnDEC(columnExtendedID);

                AddColumnsToTable(ValesStandardID, ValesExtendedID);
            }
        }

        public void AddColumnsToTable(string[] ValesStandardID, string[] ValesExtendedID)
        {
            for(int i=0;i< ValesStandardID.Length;i++)
            {
                DataTableGrid.Rows.Add(ValesStandardID[i], "0x" + ValesExtendedID[i], fields.FillFieldIDE(IDETextBox.Text), fields.FillFieldRTR(RTRTextBox.Text), "1", DataTextBox.Text, ".", "0");
            }
        }

        private void InfoTile_Click(object sender, System.EventArgs e)
        {
            ShowMessageInfo showmessage = new ShowMessageInfo();

            showmessage.ShowMessage();
        }

        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            MessgeBoxSaveAndRead message = new MessgeBoxSaveAndRead();

            if (DataTableGrid.Rows.Count>0)
            {
                message.GetTableRowsGird(DataTableGrid);
                message.ShowDialog();
            }
            else
            {
                message.ReadFile(DataTableGrid);
            }
        }

        private void ListPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == UsbNotification.WmDevicechange)
            {
                switch ((int)m.WParam)
                {
                    case UsbNotification.DbtDeviceremovecomplete:
                        StatusBar.BackColor = Color.FromArgb(243, 119, 53);
                        StatusBar.Text = "DEVICE NOT CONNECTED";
                        break;
                    case UsbNotification.DbtDevicearrival:
                        StatusBar.BackColor = Color.FromArgb(0, 174, 219);
                        StatusBar.Text = "READY";
                        break;
                }
            }
        }

        private void StatusBar_Click(object sender, EventArgs e)
        {

        }

        private void InputSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SaceInputSelect_Click(object sender, EventArgs e)
        {

        }

        private void SaveTermination_Click(object sender, EventArgs e)
        {

        }

        private void PredefinedFrameSets_Click(object sender, EventArgs e)
        {
            if(EmulatorToggle==0)
            {
                EmulatorEnable();
                EmulatorToggle = 1;
            }
            else
            {
                EmulatorDisable();
                EmulatorToggle = 0;
            }
        }

        private void EmulatorEnable()
        {

            DataTableGrid.Visible = false;
            standardIDTexbox.Visible = false;
            ExtendedIDTextBox.Visible = false;
            IDETextBox.Visible = false;
            RTRTextBox.Visible = false;
            DataTextBox.Visible = false;
            AddFrameButton.Visible = false;
            RemoveSelectedButton.Visible = false;
            UpButton.Visible = false;
            DownButton.Visible = false;
            ClearButton.Visible = false;
            RemoveDupplicatesButton.Visible = false;
            DataFormatButton.Visible = false;
            InputSelect.Visible = false;
            SaveButtonInputSelect.Visible = false;
            InputSelectCombo.Visible = false;
            SaceInputSelect.Visible = false;
            BusTermination.Visible = false;
            SaveTermination.Visible = false;
            PredefinesFramesTab.Visible = true;

        }

        private void EmulatorDisable()
        {
            DataTableGrid.Visible = true;
            standardIDTexbox.Visible = true;
            ExtendedIDTextBox.Visible = true;
            IDETextBox.Visible = true;
            RTRTextBox.Visible = true;
            DataTextBox.Visible = true;
            AddFrameButton.Visible = true;
            RemoveSelectedButton.Visible = true;
            UpButton.Visible = true;
            DownButton.Visible = true;
            ClearButton.Visible = true;
            RemoveDupplicatesButton.Visible = true;
            DataFormatButton.Visible = true;
            InputSelect.Visible = true;
            SaveButtonInputSelect.Visible = true;
            InputSelectCombo.Visible = true;
            SaceInputSelect.Visible = true;
            BusTermination.Visible = true;
            SaveTermination.Visible = true;
            PredefinesFramesTab.Visible = false;
        }
    }
}
