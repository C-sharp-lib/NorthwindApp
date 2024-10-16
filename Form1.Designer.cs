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
            tableNameSelector = new ComboBox();
            btnLoadTableData = new Button();
            dataGridViewData = new DataGridView();
            tableAddForm = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).BeginInit();
            SuspendLayout();
            // 
            // tableNameSelector
            // 
            tableNameSelector.FormattingEnabled = true;
            tableNameSelector.Location = new Point(12, 11);
            tableNameSelector.Name = "tableNameSelector";
            tableNameSelector.Size = new Size(144, 23);
            tableNameSelector.TabIndex = 0;
            tableNameSelector.SelectedIndexChanged += tableNameSelector_SelectedIndexChanged;
            // 
            // btnLoadTableData
            // 
            btnLoadTableData.BackColor = Color.DodgerBlue;
            btnLoadTableData.ForeColor = Color.White;
            btnLoadTableData.Location = new Point(162, 1);
            btnLoadTableData.Name = "btnLoadTableData";
            btnLoadTableData.Size = new Size(142, 34);
            btnLoadTableData.TabIndex = 1;
            btnLoadTableData.Text = "Load Table";
            btnLoadTableData.UseVisualStyleBackColor = false;
            btnLoadTableData.Click += btnLoadTableData_Click;
            // 
            // dataGridViewData
            // 
            dataGridViewData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewData.Location = new Point(12, 41);
            dataGridViewData.Name = "dataGridViewData";
            dataGridViewData.RowTemplate.Height = 25;
            dataGridViewData.Size = new Size(642, 365);
            dataGridViewData.TabIndex = 2;
            // 
            // tableAddForm
            // 
            tableAddForm.BackColor = Color.ForestGreen;
            tableAddForm.ForeColor = Color.White;
            tableAddForm.Location = new Point(310, 1);
            tableAddForm.Name = "tableAddForm";
            tableAddForm.Size = new Size(161, 34);
            tableAddForm.TabIndex = 3;
            tableAddForm.Text = "Add To Table";
            tableAddForm.UseVisualStyleBackColor = false;
            tableAddForm.Click += tableAddForm_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableAddForm);
            Controls.Add(dataGridViewData);
            Controls.Add(btnLoadTableData);
            Controls.Add(tableNameSelector);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox tableNameSelector;
        private Button btnLoadTableData;
        private DataGridView dataGridViewData;
        private Button tableAddForm;
    }
}
