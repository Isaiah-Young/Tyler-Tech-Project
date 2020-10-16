using System.Runtime.Remoting.Channels;
using System.Windows.Forms;
using Tyler_Technologies_Solution;

namespace SSquared_Winform
{
    partial class AddEmployeeWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.employeeId = new System.Windows.Forms.TextBox();
            this.firstName = new System.Windows.Forms.TextBox();
            this.lastName = new System.Windows.Forms.TextBox();
            this.managerList = new System.Windows.Forms.ComboBox();
            this.roleList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(219, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add New Employee";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label2.Location = new System.Drawing.Point(201, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "Employee ID:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label3.Location = new System.Drawing.Point(201, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 35);
            this.label3.TabIndex = 2;
            this.label3.Text = "First Name:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label4.Location = new System.Drawing.Point(201, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 35);
            this.label4.TabIndex = 3;
            this.label4.Text = "Last Name:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label5.Location = new System.Drawing.Point(184, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 35);
            this.label5.TabIndex = 4;
            this.label5.Text = "Manager:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label6.Location = new System.Drawing.Point(201, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 35);
            this.label6.TabIndex = 5;
            this.label6.Text = "Roles:";
            // 
            // saveButton
            // 
            this.saveButton.AccessibleName = "";
            this.saveButton.Location = new System.Drawing.Point(201, 444);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(112, 25);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.AddEmployeeClick);
            // 
            // cancelButton
            // 
            this.cancelButton.AccessibleName = "";
            this.cancelButton.Location = new System.Drawing.Point(407, 444);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 25);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // employeeId
            // 
            this.employeeId.AccessibleDescription = "Employee ID";
            this.employeeId.AccessibleName = "";
            this.employeeId.Location = new System.Drawing.Point(317, 172);
            this.employeeId.Name = "employeeId";
            this.employeeId.Size = new System.Drawing.Size(168, 22);
            this.employeeId.TabIndex = 8;
            this.employeeId.Text = "Enter Text";
            this.employeeId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // firstName
            // 
            this.firstName.AccessibleDescription = "First name";
            this.firstName.AccessibleName = "";
            this.firstName.Location = new System.Drawing.Point(317, 207);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(168, 22);
            this.firstName.TabIndex = 9;
            this.firstName.Text = "Enter Text";
            this.firstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // lastName
            // 
            this.lastName.AccessibleDescription = "Last name";
            this.lastName.AccessibleName = "";
            this.lastName.Location = new System.Drawing.Point(317, 242);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(168, 22);
            this.lastName.TabIndex = 10;
            this.lastName.Text = "Enter Text";
            this.lastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // managerList
            // 
            this.managerList.AccessibleName = "";
            this.managerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.managerList.FormattingEnabled = true;
            this.managerList.Location = new System.Drawing.Point(283, 98);
            this.managerList.Name = "managerList";
            this.managerList.Size = new System.Drawing.Size(197, 24);
            this.managerList.TabIndex = 11;
            // 
            // roleList
            // 
            this.roleList.AccessibleName = "";
            this.roleList.FormattingEnabled = true;
            this.roleList.ItemHeight = 16;
            this.roleList.Location = new System.Drawing.Point(262, 298);
            this.roleList.Name = "roleList";
            this.roleList.ScrollAlwaysVisible = true;
            this.roleList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.roleList.Size = new System.Drawing.Size(223, 100);
            this.roleList.TabIndex = 12;
            // 
            // AddEmployeeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(712, 528);
            this.Controls.Add(this.roleList);
            this.Controls.Add(this.managerList);
            this.Controls.Add(this.lastName);
            this.Controls.Add(this.firstName);
            this.Controls.Add(this.employeeId);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddEmployeeWindow";
            this.Text = "S-Squared Enterprises Personnel System";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox employeeId;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.ComboBox managerList;
        private System.Windows.Forms.ListBox roleList;
        private System.Windows.Forms.Button saveButton;

        #endregion
    }
}