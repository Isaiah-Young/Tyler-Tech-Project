using System.ComponentModel;

namespace SSquared_Winform
{
    partial class EmployeesTableWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.empTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.ManagerList = new System.Windows.Forms.ComboBox();
            this.AddButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.empTable)).BeginInit();
            this.SuspendLayout();
            // 
            // empTable
            // 
            this.empTable.AllowUserToAddRows = false;
            this.empTable.AllowUserToDeleteRows = false;
            this.empTable.AllowUserToResizeColumns = false;
            this.empTable.AllowUserToResizeRows = false;
            this.empTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.empTable.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.empTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.empTable.GridColor = System.Drawing.SystemColors.Desktop;
            this.empTable.Location = new System.Drawing.Point(131, 104);
            this.empTable.Name = "empTable";
            this.empTable.ReadOnly = true;
            this.empTable.RowHeadersVisible = false;
            this.empTable.RowTemplate.Height = 24;
            this.empTable.Size = new System.Drawing.Size(455, 324);
            this.empTable.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(148, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manager:";
            // 
            // ManagerList
            // 
            this.ManagerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ManagerList.FormattingEnabled = true;
            this.ManagerList.Location = new System.Drawing.Point(256, 51);
            this.ManagerList.Name = "ManagerList";
            this.ManagerList.Size = new System.Drawing.Size(239, 24);
            this.ManagerList.TabIndex = 1;
            this.ManagerList.SelectedIndexChanged += new System.EventHandler(this.ManagerList_SelectedIndexChanged);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(306, 458);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(112, 32);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Add Employee";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // EmployeesTableWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(734, 546);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.empTable);
            this.Controls.Add(this.ManagerList);
            this.Controls.Add(this.label1);
            this.Name = "EmployeesTableWindow";
            this.Text = "S-Squared Enterprises Personnel System";
            ((System.ComponentModel.ISupportInitialize) (this.empTable)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.DataGridView empTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ManagerList;

        #endregion
    }
}