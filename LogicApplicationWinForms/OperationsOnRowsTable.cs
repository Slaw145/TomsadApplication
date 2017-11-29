using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicConnectionAplication
{
    public class OperationsOnRowsTable
    {
        public void RemoveDuplicatedRows(DataGridView table)
        {
            for (int currentRow = 0; currentRow < table.Rows.Count - 1; currentRow++)
            {
                DataGridViewRow rowToCompare = table.Rows[currentRow];

                for (int otherRow = currentRow + 1; otherRow < table.Rows.Count; otherRow++)
                {
                    DataGridViewRow row = table.Rows[otherRow];

                    bool duplicateRow = true;
                    if (!rowToCompare.Cells["StandardID"].Value.Equals(row.Cells["StandardID"].Value) || !rowToCompare.Cells["ExtendedID"].Value.Equals(row.Cells["ExtendedID"].Value) || !rowToCompare.Cells["IDE"].Value.Equals(row.Cells["IDE"].Value) || !rowToCompare.Cells["RTR"].Value.Equals(row.Cells["RTR"].Value) || !rowToCompare.Cells["Data"].Value.Equals(row.Cells["Data"].Value))
                    {
                        duplicateRow = false;
                        break;
                    }

                    if (duplicateRow)
                    {
                        table.Rows.Remove(row);
                        otherRow--;
                    }
                }
            }
        }

        public void RemoveSelectedRow(DataGridView table)
        {
            foreach (DataGridViewRow item in table.SelectedRows)
            {
                try
                {
                    table.Rows.RemoveAt(item.Index);
                }
                catch (Exception)
                {
                    MessageBox.Show("Zaznaczono pusty wiersz!");
                }
            }
        }

        public bool UpRow(DataGridView table)
        {
            int inIndex = table.CurrentRow.Index;
            
            if (inIndex != 0)
            {
                DataGridViewRow dr = table.Rows[inIndex];
                table.CurrentCell = table.Rows[inIndex - 1].Cells[0];
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DownRow(DataGridView table)
        {
            int inIndex = table.CurrentRow.Index;

            if (inIndex != (table.Rows.Count - 1))
            {
                DataGridViewRow dr = table.Rows[inIndex];
                table.CurrentCell = table.Rows[inIndex + 1].Cells[0];
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
