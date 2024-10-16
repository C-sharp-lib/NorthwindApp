using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindApp
{
    public partial class AddForm : Form
    {
        private string selectedTable;
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=True;";
        private List<Control> inputControls = new List<Control>();
        public AddForm(string selectedTable)
        {
            InitializeComponent();
            this.selectedTable = selectedTable;
            LoadTableColumns();
        }
        private void LoadTableColumns()
        {
            /*string query = $"SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @TableName";
            string query2 = @"
    SELECT C.COLUMN_NAME, C.DATA_TYPE
    FROM INFORMATION_SCHEMA.COLUMNS C
    LEFT JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE K 
        ON C.TABLE_NAME = K.TABLE_NAME 
        AND C.COLUMN_NAME = K.COLUMN_NAME 
        AND OBJECTPROPERTY(OBJECT_ID(K.CONSTRAINT_SCHEMA + '.' + K.CONSTRAINT_NAME), 'IsPrimaryKey') = 1
    WHERE C.TABLE_NAME = @TableName
    AND K.COLUMN_NAME IS NULL";*/
            string query = @"
        SELECT C.COLUMN_NAME, C.DATA_TYPE
        FROM INFORMATION_SCHEMA.COLUMNS C
        LEFT JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE K 
            ON C.TABLE_NAME = K.TABLE_NAME 
            AND C.COLUMN_NAME = K.COLUMN_NAME 
            AND OBJECTPROPERTY(OBJECT_ID(K.CONSTRAINT_SCHEMA + '.' + K.CONSTRAINT_NAME), 'IsPrimaryKey') = 1
        WHERE C.TABLE_NAME = @TableName
        AND (K.COLUMN_NAME IS NULL OR COLUMNPROPERTY(OBJECT_ID(C.TABLE_SCHEMA + '.' + C.TABLE_NAME), C.COLUMN_NAME, 'IsIdentity') = 0)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TableName", selectedTable);

                    SqlDataReader reader = command.ExecuteReader();
                    int yPosition = 20; // Initial y-position for controls

                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        string dataType = reader["DATA_TYPE"].ToString();

                        // Create a label for each column
                        Label label = new Label();
                        label.Text = columnName;
                        label.Location = new System.Drawing.Point(20, yPosition);
                        label.AutoSize = true;
                        this.Controls.Add(label);

                        // Create a control based on the data type
                        Control inputControl = CreateInputControl(dataType);
                        inputControl.Name = columnName; // Set the control's name to the column name
                        inputControl.Location = new System.Drawing.Point(150, yPosition);
                        this.Controls.Add(inputControl);

                        // Add the control to the list for later retrieval
                        inputControls.Add(inputControl);

                        // Adjust y-position for the next control
                        yPosition += 30;
                    }

                    reader.Close();

                    // Add a button to save the data
                    Button btnSave = new Button();
                    btnSave.Text = "Save";
                    btnSave.Location = new System.Drawing.Point(150, yPosition);
                    btnSave.Click += BtnSave_Click;
                    this.Controls.Add(btnSave);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private Control CreateInputControl(string dataType)
        {
            switch (dataType.ToLower())
            {
                case "int":
                case "bigint":
                case "smallint":
                case "tinyint":
                    return new NumericUpDown(); // Use NumericUpDown for numeric types

                case "decimal":
                case "numeric":
                case "float":
                case "real":
                    return new TextBox(); // Use TextBox for decimal types

                case "bit":
                    return new CheckBox(); // Use CheckBox for boolean types

                case "datetime":
                case "date":
                case "time":
                    return new DateTimePicker(); // Use DateTimePicker for date/time types

                default:
                    return new TextBox(); // Use TextBox for all other types (e.g., varchar, text)
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Construct the INSERT query
                    string columns = string.Join(", ", inputControls.Select(c => $"[{c.Name}]"));
                    string parameters = string.Join(", ", inputControls.Select(c => $"@{c.Name}"));
                    string query = $"INSERT INTO [{selectedTable}] ({columns}) VALUES ({parameters})";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Add parameters to the command
                    foreach (var control in inputControls)
                    {
                        string columnName = control.Name;
                        object value = GetControlValue(control);
                        command.Parameters.AddWithValue($"@{columnName}", value ?? DBNull.Value);
                    }

                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show(rowsAffected > 0 ? "Data saved successfully!" : "No data was saved.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
        }
        private object GetControlValue(Control control)
        {
            switch (control)
            {
                case TextBox textBox:
                    return textBox.Text;
                case NumericUpDown numericUpDown:
                    return numericUpDown.Value;
                case CheckBox checkBox:
                    return checkBox.Checked;
                case DateTimePicker dateTimePicker:
                    return dateTimePicker.Value;
                default:
                    return null;
            }
        }

        private void exitAdd_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
