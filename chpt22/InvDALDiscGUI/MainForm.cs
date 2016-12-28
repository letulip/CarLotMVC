using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoLotDAL2.DisconnectedLayer;

namespace InvDALDiscGUI
{
    public partial class MainForm : Form
    {
        InventoryDALDC _dal = null;

        public MainForm()
        {
            InitializeComponent();

            string connectionString = "Integrated Security=True; Initial Catalog=AutoLot;" + @"Data Source=.\SQLEXPRESS";

            _dal = new InventoryDALDC(connectionString);

            inventoryGrid.DataSource = _dal.GetAllInventory();
        }

        private void btnUpdateInventory_Click(object sender, EventArgs e)
        {
            DataTable changedDT = (DataTable)inventoryGrid.DataSource;

            try
            {
                _dal.UpdateInventory(changedDT);
                inventoryGrid.DataSource = _dal.GetAllInventory();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
