using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseManager
{
    public partial class WarehouseManager : Form
    {
        DataTable warehouse = new DataTable();
        public WarehouseManager()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            idTextBox.Text = "";
            nameTextBox.Text = "";
            priceTextBox.Text = "";
            quantityTextBox.Text = "";
            descriptionTextBox.Text = "";
            categoryComboBox.SelectedIndex = -1;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Save all the values from our fields into variables
            String id = idTextBox.Text;
            String name = nameTextBox.Text;
            String price = priceTextBox.Text;
            String quantity = quantityTextBox.Text;
            String description = descriptionTextBox.Text;
            String category = (string)categoryComboBox.SelectedItem;

            // Add these values to the datatable
            warehouse.Rows.Add(id, name, price, quantity, description, category);

            // Clear fields after save
            newButton_Click(sender, e);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                warehouse.Rows[warehouseGridView.CurrentCell.RowIndex].Delete();
            }
            catch (Exception err)
            {
                Console.WriteLine("Error: " + err);
            }
        }

        private void warehouseGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idTextBox.Text = warehouse.Rows[warehouseGridView.CurrentCell.RowIndex].ItemArray[0].ToString();
                nameTextBox.Text = warehouse.Rows[warehouseGridView.CurrentCell.RowIndex].ItemArray[1].ToString();
                priceTextBox.Text = warehouse.Rows[warehouseGridView.CurrentCell.RowIndex].ItemArray[3].ToString();
                quantityTextBox.Text = warehouse.Rows[warehouseGridView.CurrentCell.RowIndex].ItemArray[4].ToString();
                descriptionTextBox.Text = warehouse.Rows[warehouseGridView.CurrentCell.RowIndex].ItemArray[5].ToString();

                String itemToLookFor = warehouse.Rows[warehouseGridView.CurrentCell.RowIndex].ItemArray[2].ToString();
                categoryComboBox.SelectedIndex = categoryComboBox.Items.IndexOf(itemToLookFor);
            }
            catch (Exception err)
            {
                Console.WriteLine("There has been an error: " + err);
            }
        }

        private void WarehouseManager_Load(object sender, EventArgs e)
        {
            warehouse.Columns.Add("ID");
            warehouse.Columns.Add("Name");
            warehouse.Columns.Add("Price");
            warehouse.Columns.Add("Quantity");
            warehouse.Columns.Add("Description");
            warehouse.Columns.Add("Category");

            warehouseGridView.DataSource = warehouse;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
