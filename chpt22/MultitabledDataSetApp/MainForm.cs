using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace MultitabledDataSetApp
{
    public partial class MainForm : Form
    {
        private DataSet _autoLotDs = new DataSet("AutoLot");

        private SqlCommandBuilder _sqlCbInventory;
        private SqlCommandBuilder _sqlCbCustomers;
        private SqlCommandBuilder _sqlCbOrders;

        private SqlDataAdapter _invTableAdapter;
        private SqlDataAdapter _custTableAdapter;
        private SqlDataAdapter _ordersTableAdapter;

        private string _connectionString;

        private void BuildTableRelationShip()
        {
            DataRelation dr = new DataRelation("CustomerOrder", _autoLotDs.Tables["Customers"].Columns["CustId"], _autoLotDs.Tables["Orders"].Columns["CustId"]);
            _autoLotDs.Relations.Add(dr);

            dr = new DataRelation("InventoryOrder", _autoLotDs.Tables["Inventory"].Columns["CarId"], _autoLotDs.Tables["Orders"].Columns["CarId"]);
            _autoLotDs.Relations.Add(dr);
        }

        public MainForm()
        {
            InitializeComponent();

            _connectionString = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            _invTableAdapter = new SqlDataAdapter("SELECT * FROM Inventory", _connectionString);
            _custTableAdapter = new SqlDataAdapter("SELECT * FROM Customers", _connectionString);
            _ordersTableAdapter = new SqlDataAdapter("SELECT * FROM Orders", _connectionString);

            _sqlCbInventory = new SqlCommandBuilder(_invTableAdapter);
            _sqlCbOrders = new SqlCommandBuilder(_ordersTableAdapter);
            _sqlCbCustomers = new SqlCommandBuilder(_custTableAdapter);

            _invTableAdapter.Fill(_autoLotDs, "Inventory");
            _ordersTableAdapter.Fill(_autoLotDs, "Orders");
            _custTableAdapter.Fill(_autoLotDs, "Customers");

            BuildTableRelationShip();

            dataGridViewInv.DataSource = _autoLotDs.Tables["Inventory"];
            dataGridViewOrd.DataSource = _autoLotDs.Tables["Orders"];
            dataGridViewCust.DataSource = _autoLotDs.Tables["Customers"];
        }

        private void btnUpdateDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                _invTableAdapter.Update(_autoLotDs, "Inventory");
                _custTableAdapter.Update(_autoLotDs, "Customers");
                _ordersTableAdapter.Update(_autoLotDs, "Orders");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnGetOrderInfo_Click(object sender, EventArgs e)
        {
            string strOrderInfo = string.Empty;

            int custId = int.Parse(txtCustId.Text);

            var drsCust = _autoLotDs.Tables["Customers"].Select($"CustId = {custId}");

            strOrderInfo += $"Customer {drsCust[0]["CustId"]}: {drsCust[0]["FirstName"].ToString().Trim()} {drsCust[0]["LastName"].ToString().Trim()}\n";

            var drsOrder = drsCust[0].GetChildRows(_autoLotDs.Relations["CustomerOrder"]);

            foreach (DataRow order in drsOrder)
            {
                strOrderInfo += $"---- \n Order number: {order["OrderId"]}\n";

                DataRow[] drsInv = order.GetParentRows(_autoLotDs.Relations["InventoryOrder"]);

                DataRow car = drsInv[0];
                strOrderInfo += $"Make: {car["Make"]}\n";
                strOrderInfo += $"Color: {car["Color"]}\n";
                strOrderInfo += $"PetName: {car["PetName"]}\n";
            }

            MessageBox.Show(strOrderInfo, "Order Details");
        }
    }
}
