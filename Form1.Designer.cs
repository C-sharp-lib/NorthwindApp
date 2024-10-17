namespace NorthwindApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxTable = new ComboBox();
            btnLoadTableData = new Button();
            dataGridViewData = new DataGridView();
            tableAddForm = new Button();
            btnDelete = new Button();
            comboBoxColumn = new ComboBox();
            btnExit = new Button();
            comboBoxValues = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).BeginInit();
            SuspendLayout();
            // 
            // comboBoxTable
            // 
            comboBoxTable.FormattingEnabled = true;
            comboBoxTable.Location = new Point(627, 69);
            comboBoxTable.Name = "comboBoxTable";
            comboBoxTable.Size = new Size(161, 23);
            comboBoxTable.TabIndex = 0;
            comboBoxTable.SelectedIndexChanged += comboBoxTable_SelectedIndexChanged;
            // 
            // btnLoadTableData
            // 
            btnLoadTableData.BackColor = Color.DodgerBlue;
            btnLoadTableData.FlatStyle = FlatStyle.Popup;
            btnLoadTableData.Font = new Font("Verdana", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnLoadTableData.ForeColor = Color.White;
            btnLoadTableData.Location = new Point(629, 182);
            btnLoadTableData.Name = "btnLoadTableData";
            btnLoadTableData.Size = new Size(161, 51);
            btnLoadTableData.TabIndex = 1;
            btnLoadTableData.Text = "Load Table";
            btnLoadTableData.UseVisualStyleBackColor = false;
            btnLoadTableData.Click += btnLoadTableData_Click;
            // 
            // dataGridViewData
            // 
            dataGridViewData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewData.Location = new Point(12, 12);
            dataGridViewData.Name = "dataGridViewData";
            dataGridViewData.RowTemplate.Height = 25;
            dataGridViewData.Size = new Size(609, 543);
            dataGridViewData.TabIndex = 2;
            dataGridViewData.CellContentClick += dataGridViewData_CellContentClick;
            // 
            // tableAddForm
            // 
            tableAddForm.BackColor = Color.ForestGreen;
            tableAddForm.FlatStyle = FlatStyle.Popup;
            tableAddForm.Font = new Font("Verdana", 11F, FontStyle.Bold, GraphicsUnit.Point);
            tableAddForm.ForeColor = Color.White;
            tableAddForm.Location = new Point(629, 239);
            tableAddForm.Name = "tableAddForm";
            tableAddForm.Size = new Size(161, 51);
            tableAddForm.TabIndex = 3;
            tableAddForm.Text = "Add To Table";
            tableAddForm.UseVisualStyleBackColor = false;
            tableAddForm.Click += tableAddForm_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Font = new Font("Verdana", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(629, 296);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(161, 51);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // comboBoxColumn
            // 
            comboBoxColumn.FormattingEnabled = true;
            comboBoxColumn.Location = new Point(629, 107);
            comboBoxColumn.Name = "comboBoxColumn";
            comboBoxColumn.Size = new Size(159, 23);
            comboBoxColumn.TabIndex = 5;
            comboBoxColumn.SelectedIndexChanged += comboBoxColumn_SelectedIndexChanged;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.DarkOrange;
            btnExit.FlatAppearance.BorderColor = Color.Black;
            btnExit.FlatAppearance.BorderSize = 12;
            btnExit.FlatStyle = FlatStyle.Popup;
            btnExit.Font = new Font("Verdana", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(629, 353);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(161, 51);
            btnExit.TabIndex = 6;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // comboBoxValues
            // 
            comboBoxValues.FormattingEnabled = true;
            comboBoxValues.Location = new Point(627, 144);
            comboBoxValues.Name = "comboBoxValues";
            comboBoxValues.Size = new Size(161, 23);
            comboBoxValues.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 567);
            Controls.Add(comboBoxValues);
            Controls.Add(btnExit);
            Controls.Add(comboBoxColumn);
            Controls.Add(btnDelete);
            Controls.Add(tableAddForm);
            Controls.Add(dataGridViewData);
            Controls.Add(btnLoadTableData);
            Controls.Add(comboBoxTable);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBoxTable;
        private Button btnLoadTableData;
        private DataGridView dataGridViewData;
        private Button tableAddForm;
        private Button btnDelete;
        private ComboBox comboBoxColumn;
        private Button btnExit;
        private ComboBox comboBoxValues;
    }
}
