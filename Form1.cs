using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace NorthwindApp
{
    public partial class Form1 : Form
    {
        private string selectedTable;
        private string selectedColumn;
        private object selectedValue;
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=True;";
        public Form1()
        {
            InitializeComponent();
            PopulateComboBox();
            btnLoadTableData.Click += btnLoadTableData_Click;
            comboBoxTable.SelectedIndexChanged += comboBoxTable_SelectedIndexChanged;
            comboBoxColumn.SelectedIndexChanged += comboBoxColumn_SelectedIndexChanged;
            btnDelete.Click += btnDelete_Click;
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
                    comboBoxTable.Items.Clear();
                    comboBoxColumn.Items.Clear();
                    while (reader.Read())
                    {
                        comboBoxTable.Items.Add(reader["TABLE_NAME"].ToString());

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (comboBoxTable.Items.Count > 0)
            {
                comboBoxTable.SelectedIndex = 0;
            }
        }

        private void LoadTableData(string selectedTable)
        {
            string query = $"SELECT * FROM [{selectedTable}]";
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
        private void comboBoxTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTable.SelectedItem != null)
            {
                string selectedTable = comboBoxTable.SelectedItem.ToString();
                LoadColumnNames(selectedTable);
            }
            else
            {
                selectedTable = null;
            }
        }

        private void btnLoadTableData_Click(object sender, EventArgs e)
        {
            if (comboBoxTable.SelectedItem != null)
            {
                string selectedTable = comboBoxTable.SelectedItem.ToString();
                LoadTableData(selectedTable);
            }
            else
            {
                MessageBox.Show("Please select a table from the list.");
            }
        }
        private void LoadColumnNames(string tableName)
        {
            string query = @"SELECT TOP 1 COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @TableName ORDER BY ORDINAL_POSITION";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TableName", tableName);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    comboBoxColumn.Items.Clear();
                    while (reader.Read())
                    {
                        comboBoxColumn.Items.Add(reader["COLUMN_NAME"].ToString());
                    }

                    reader.Close();
                    comboBoxValues.Items.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading column names: " + ex.Message);
                }
            }
        }
        private void comboBoxColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxColumn.SelectedItem != null)
            {
                selectedTable = comboBoxTable.SelectedItem.ToString();
                selectedColumn = comboBoxColumn.SelectedItem.ToString();
                LoadColumnValues(selectedTable, selectedColumn);
            }
            else
            {
                selectedColumn = null;
            }
        }
        private void LoadColumnValues(string tableName, string columnName)
        {
            tableName = tableName.Trim();
            columnName = columnName.Trim();
            if (string.IsNullOrWhiteSpace(tableName) || string.IsNullOrWhiteSpace(columnName))
            {
                MessageBox.Show("Error: Table name or column is null or empty");
                return;
            }

            string query = $"SELECT DISTINCT [{columnName}] FROM [{tableName}]";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    comboBoxValues.Items.Clear();
                    while (reader.Read())
                    {
                        var value = reader.IsDBNull(0) ? null : reader.GetValue(0);

                        // Add the value to the ComboBox
                        comboBoxValues.Items.Add(value ?? "<NULL>");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading column values: " + ex.Message);
                }
            }
        }
        private void tableAddForm_Click(object sender, EventArgs e)
        {
            if (comboBoxTable.SelectedItem != null)
            {
                string selectedTable = comboBoxTable.SelectedItem.ToString();
                AddForm addForm = new AddForm(selectedTable);
                addForm.Show();
            }
            else
            {
                MessageBox.Show("Please select a table from the list.");
            }
        }

        private void dataGridViewData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (comboBoxValues.SelectedItem != null)
            {
                selectedValue = comboBoxValues.SelectedItem;
                DeleteItem(selectedTable, selectedColumn, selectedValue);
                LoadTableData(selectedTable);
                MessageBox.Show("Deletion attempted. Please check the database for results.");
            }
            else
            {
                MessageBox.Show("Please select a value to delete.");
            }
        }
        private void DeleteItem(string tableName, string columnName, object value)
        {
            string query = $"DELETE FROM [{tableName}] WHERE [{columnName}] {(value == DBNull.Value ? "IS NULL" : "= @Value")}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    if (value != DBNull.Value)
                    {
                        // Determine parameter type based on the type of 'value'
                        if (value is int)
                        {
                            command.Parameters.Add("@Value", SqlDbType.Int).Value = (int)value;
                        }
                        else if (value is decimal)
                        {
                            command.Parameters.Add("@Value", SqlDbType.Decimal).Value = (decimal)value;
                        }
                        else if (value is DateTime)
                        {
                            command.Parameters.Add("@Value", SqlDbType.DateTime).Value = (DateTime)value;
                        }
                        else if (value is string)
                        {
                            command.Parameters.Add("@Value", SqlDbType.NVarChar, 4000).Value = (string)value;
                        }
                        else if (value is char) 
                        {
                            command.Parameters.Add("@Value", SqlDbType.Char, 1000).Value = (char)value;
                        }
                        else
                        {
                            command.Parameters.Add("@Value", SqlDbType.Variant).Value = value;
                        }
                    }

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Item(s) deleted successfully.");
                        comboBoxValues.Items.Remove(comboBoxValues.SelectedItem);
                    }
                    else
                    {
                        MessageBox.Show("No matching items found to delete.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during deletion: " + ex.Message);
                }
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
