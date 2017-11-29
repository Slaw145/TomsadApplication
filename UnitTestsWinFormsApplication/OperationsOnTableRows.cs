using LogicConnectionAplication;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitTestsConnectionDesktopApp
{
    [TestFixture]
    public class OperationOnRows
    {
        DataGridView table;

        [SetUp]
        public void Init()
        {
            table = new DataGridView();

            table.Columns.Add("StandardID", "Standard ID");
            table.Columns.Add("ExtendedID", "Extended ID");
            table.Columns.Add("IDE", "IDE");
            table.Columns.Add("RTR", "RTR");
            table.Columns.Add("DLC", "DLC");
            table.Columns.Add("Data", "Data");
            table.Columns.Add("Data ASCII", "Data ASCII");
            table.Columns.Add("Time", "Time");

            table.Rows.Add(new DataGridViewRow());
            table.Rows[0].Cells[0].Value = "Standard ID";
            table.Rows[0].Cells[1].Value = "Extended ID";
            table.Rows[0].Cells[2].Value = "IDE";
            table.Rows[0].Cells[3].Value = "RTR";
            table.Rows[0].Cells[4].Value = "1";
            table.Rows[0].Cells[5].Value = "Data";
            table.Rows[0].Cells[6].Value = ".";
            table.Rows[0].Cells[7].Value = "0";

            table.Rows[1].Cells[0].Value = "123";
            table.Rows[1].Cells[1].Value = "123";
            table.Rows[1].Cells[2].Value = "IDE";
            table.Rows[1].Cells[3].Value = "RTR";
            table.Rows[1].Cells[4].Value = "1";
            table.Rows[1].Cells[5].Value = "Data";
            table.Rows[1].Cells[6].Value = ".";
            table.Rows[1].Cells[7].Value = "0";
        }

        [Test]
        public void test_down_row()
        {
            table.CurrentCell = table.Rows[0].Cells[0];

            OperationsOnRowsTable operations = new OperationsOnRowsTable();

            bool down = operations.DownRow(table);

            Assert.AreEqual(true, down);
        }

        [Test]
        public void test_failed_down_row()
        {
            table.CurrentCell = table.Rows[1].Cells[1];

            OperationsOnRowsTable operations = new OperationsOnRowsTable();

            bool down = operations.DownRow(table);

            Assert.AreEqual(false, down);
        }

        [Test]
        public void test_up_row()
        {
            table.CurrentCell = table.Rows[1].Cells[1];

            OperationsOnRowsTable operations = new OperationsOnRowsTable();

            bool down = operations.UpRow(table);

            Assert.AreEqual(true, down);
        }

        [Test]
        public void test_failed_up_row()
        {
            table.CurrentCell = table.Rows[0].Cells[0];

            OperationsOnRowsTable operations = new OperationsOnRowsTable();

            bool down = operations.UpRow(table);

            Assert.AreEqual(false, down);
        }

        [Test]
        public void test_change_convert_system_on_HEX()
        {
            ConvertingOnDiffrentNumericSystems convert = new ConvertingOnDiffrentNumericSystems();

            string whichsystem = convert.ChangeTextOnButtonSystemConverting();

            Assert.AreEqual("Data format: HEX", whichsystem);
        }

        [Test]
        public void test_change_convert_system_on_DEC()
        {
            ConvertingOnDiffrentNumericSystems convert = new ConvertingOnDiffrentNumericSystems();

            convert.ChangeTextOnButtonSystemConverting();

            string whichsystem = convert.ChangeTextOnButtonSystemConverting();

            Assert.AreEqual("Data format: DEC", whichsystem);
        }
    }
}
