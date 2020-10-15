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
        // This is my first time working with a WinForm so if there I'm sure there is a conventional way to do this
        private List<Employee> _managers;
        private List<Role> _possibleRoles;
        private EmployeeDbHandle _dbHandle = new EmployeeDbHandle();
        
        public AddEmployeeWindow()
        {
            InitializeComponent();
            
            FillManagerList();
            
            _possibleRoles = _dbHandle.GetPossibleRoles();
            roleList.DataSource = new BindingSource(_possibleRoles, null);
            roleList.DisplayMember = "Name";
            roleList.ValueMember = "Id";
        }

        private void addEmployeeClick(object sender, EventArgs e)
        {
            // add method to check that form is filled out
            int EmployeeId = int.Parse(employeeId.Text);
            int ManagerId = (int) managerList.SelectedValue;
            string first = firstName.Text;
            string last = lastName.Text;
            List<Role> roles = roleList.SelectedItems.Cast<Role>().ToList();

            bool wasAdded = _dbHandle.AddEmployee(EmployeeId, ManagerId, first, last, roles);
            if (!wasAdded)
            {
                MessageBox.Show("An exception occured");
                return;
            }

            MessageBox.Show("Employee Added.");
            FillManagerList();
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
    }
}