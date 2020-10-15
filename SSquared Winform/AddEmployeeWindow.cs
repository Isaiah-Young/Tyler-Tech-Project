using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tyler_Technologies_Solution;

namespace SSquared_Winform
{
    public partial class AddEmployeeWindow : Form
    {
        // This is my first time working with a WinForm so I'm sure there is a more conventional way to do this
        private readonly EmployeeDbHandle _dbHandle = new EmployeeDbHandle();
        private List<Employee> _managers;
        private readonly List<Employee> _allEmployees;
        
        public AddEmployeeWindow()
        {
            InitializeComponent();
            
            FillManagerList();
            
            var possibleRoles = _dbHandle.GetPossibleRoles();
            roleList.DataSource = new BindingSource(possibleRoles, null);
            roleList.DisplayMember = "Name";
            roleList.ValueMember = "Id";

            _allEmployees = _dbHandle.GetAllEmployees();
        }

        private void AddEmployeeClick(object sender, EventArgs e)
        {
            if (FormIsFilled())
            {
                List<string> cleanEmployeeInputs =
                    SanitizeEmployeeInputs(employeeId.Text, firstName.Text, lastName.Text);

                int EmployeeId = int.Parse(cleanEmployeeInputs[0]);
                if (_allEmployees.Select(emp => emp.Id).Contains(EmployeeId))
                {
                    MessageBox.Show(
                        "Employee could not be added. An employee with the ID " + EmployeeId + " already exists");
                    return;
                }

                string first = cleanEmployeeInputs[1];
                string last = cleanEmployeeInputs[2];
                int ManagerId = (int) managerList.SelectedValue;
                List<Role> roles = roleList.SelectedItems.Cast<Role>().ToList();

                MessageBox.Show(_dbHandle.AddEmployee(EmployeeId, ManagerId, first, last, roles));
                ClearControls();
                FillManagerList();
            }
        }

        private void ClearControls()
        {
            foreach (TextBox tb in Controls.OfType<TextBox>())
            {
                tb.Text = string.Empty;
            }
        }

        private bool FormIsFilled()
        {
            foreach (TextBox tb in Controls.OfType<TextBox>())
            {
                if (string.IsNullOrEmpty(tb.Text))
                {
                    MessageBox.Show(tb.AccessibleDescription + " field is empty.");
                    return false;
                }
            }
            
            return true;
        }

        // Even though the user is prevented from typing incorrect characters, they can still paste them - this double checks that
        private List<string> SanitizeEmployeeInputs(string employeeId, string firstName, string lastName)
        {
            string cleanId = new string(employeeId.Where(char.IsNumber).ToArray());
            string cleanFirst = new string(firstName.Where(char.IsLetter).ToArray());
            string cleanLast = new string(lastName.Where(char.IsLetter).ToArray());
            
            return new List<string>() {cleanId, cleanFirst, cleanLast};
        }

        private void FillManagerList()
        {
            _managers = _dbHandle.GetAllManagers();
            managerList.DataSource = new BindingSource(_managers, null);
            managerList.DisplayMember = "FirstName";
            managerList.ValueMember = "Id";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            FormProvider.MainMenu.Show();
            Hide();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char _char = e.KeyChar;
            
            // EmployeeId input should only accept digits
            if ( ((TextBox)sender).Name == employeeId.Name)
            {
                if ( (!char.IsNumber(_char) || char.IsWhiteSpace(_char)) && !char.IsControl(_char)) 
                {
                    e.Handled = true; // don't accept the character
                }
            }
            
            // Name inputs should only accept letters
            else if ( ((TextBox)sender).Name == firstName.Name || ((TextBox)sender).Name == lastName.Name)
            {
                if ( (char.IsNumber( _char) || char.IsPunctuation(_char) || char.IsWhiteSpace(_char)) && !char.IsControl(_char)) 
                {
                    e.Handled = true;
                }
            }

        }
    }
}