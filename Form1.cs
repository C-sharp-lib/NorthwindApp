using Microsoft.Data.SqlClient;
using System.Data;

namespace NorthwindApp
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=True;";
        public Form1()
        {
            InitializeComponent();
            PopulateComboBox();
            btnLoadTableData.Click += btnLoadTableData_Click;
        }
        public void PopulateComboBox()
        {

            string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    tableNameSelector.Items.Clear();
                    while (reader.Read())
                    {
                        tableNameSelector.Items.Add(reader["TABLE_NAME"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (tableNameSelector.Items.Count > 0)
            {
                tableNameSelector.SelectedIndex = 0;
            }
        }
        private void LoadTableData(string tableName)
        {
            string query = $"SELECT * FROM [{tableName}]";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
                    dataGridViewData.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }
        private void tableNameSelector_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLoadTableData_Click(object sender, EventArgs e)
        {
            if (tableNameSelector.SelectedItem != null)
            {
                string selectedTable = tableNameSelector.SelectedItem.ToString();
                LoadTableData(selectedTable);
            }
            else
            {
                MessageBox.Show("Please select a table from the list.");
            }
        }

        private void tableAddForm_Click(object sender, EventArgs e)
        {
            if (tableNameSelector.SelectedItem != null)
            {
                string selectedTable = tableNameSelector.SelectedItem.ToString();
                AddForm addForm = new AddForm(selectedTable);
                addForm.Show();
            }
            else
            {
                MessageBox.Show("Please select a table from the list.");
            }
        }
    }
}
