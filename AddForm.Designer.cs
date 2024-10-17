namespace NorthwindApp
{
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            exitAdd = new Button();
            SuspendLayout();
            // 
            // exitAdd
            // 
            exitAdd.BackColor = Color.DarkOrange;
            exitAdd.FlatStyle = FlatStyle.Popup;
            exitAdd.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            exitAdd.ForeColor = Color.White;
            exitAdd.Location = new Point(633, 67);
            exitAdd.Name = "exitAdd";
            exitAdd.Size = new Size(134, 49);
            exitAdd.TabIndex = 0;
            exitAdd.Text = "Exit";
            exitAdd.UseVisualStyleBackColor = false;
            exitAdd.Click += exitAdd_Click;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 562);
            Controls.Add(exitAdd);
            Name = "AddForm";
            Text = "AddForm";
            ResumeLayout(false);
        }

        #endregion

        private Button exitAdd;
    }
}