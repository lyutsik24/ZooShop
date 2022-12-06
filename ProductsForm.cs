using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooShop
{
    public partial class ProductsForm : Form
    {
        MySqlConnection cn = new MySqlConnection();
        MySqlCommand cm = new MySqlCommand();
        BDUtills dbcon = new BDUtills();
        MySqlDataReader dr;
        int id;
        string title = "Pet Shop Management System";

        public ProductsForm()
        {
            InitializeComponent();
            cn = BDUtills.GetDBConnection();
            this.productsTableAdapter.Fill(this.zooShopDataSet.Products);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.productsTableAdapter.Update(this.zooShopDataSet.Products);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductModule module = new ProductModule(this);
            module.ShowDialog();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProducts.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                ProductModule module = new ProductModule(this);
                module.lblPcode.Text = dgvProducts.Rows[e.RowIndex].Cells[0].Value.ToString();
                module.txtName.Text = dgvProducts.Rows[e.RowIndex].Cells[1].Value.ToString();
                module.txtType.Text = dgvProducts.Rows[e.RowIndex].Cells[2].Value.ToString();
                module.cbCategory.Text = dgvProducts.Rows[e.RowIndex].Cells[3].Value.ToString();
                module.txtQty.Text = dgvProducts.Rows[e.RowIndex].Cells[4].Value.ToString();
                module.txtPrice.Text = dgvProducts.Rows[e.RowIndex].Cells[5].Value.ToString();

                module.btnSave.Enabled = false;
                module.btnUpdate.Enabled = true;
                module.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this items?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new MySqlCommand("DELETE FROM `Products` WHERE (`idProducts` = @id)");
                    cm.Parameters.AddWithValue("@id", id);
                    cn.Open();
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Item record has been successfully removed!", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            this.productsTableAdapter.Update(this.zooShopDataSet.Products);
        }
    }
}