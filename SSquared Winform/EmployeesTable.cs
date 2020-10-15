using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tyler_Technologies_Solution;

namespace SSquared_Winform
{
    public partial class EmployeesTableWindow : Form
    {
        private EmployeeDbHandle _dbHandle = new EmployeeDbHandle();
        private List<Employee> _managers;

        public EmployeesTableWindow()
        {
            InitializeComponent();
            FillManagerList();
            FillTable(_managers.First().Id);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            FormProvider.MainMenu.Hide();
            AddEmployeeWindow addEmpWin = new AddEmployeeWindow();
            addEmpWin.Show();
        }
        
        // This is repetitive code found in Form1, but I can't call that method without instantiating the form first
        private void FillManagerList()
        {
            _managers = _dbHandle.GetAllManagers();
            ManagerList.DataSource = new BindingSource(_managers, null);
            ManagerList.DisplayMember = "FirstName";
            ManagerList.ValueMember = "Id";
        }

        public List<Employee> GetEmployeesForManager(int managerId)
        {
            List<Employee> employeesForSelectedManager = _dbHandle.GetAllEmployees().Where(emp => emp.ManagerId == managerId).ToList();
            List<Employee> employeesThatAreAlsoManagers = employeesForSelectedManager.Where(e => _managers.Contains(e)).ToList();

            // for used instead of foreach because employeesThatAreAlsoManagers changes with each loop
            for (var i = 0; i < employeesThatAreAlsoManagers.Count(); i++)
            {
                var subEmployees = GetEmployeesForManager(employeesThatAreAlsoManagers[i].Id);
                employeesForSelectedManager.AddRange(subEmployees);
            }
            
            return employeesForSelectedManager;
        }

        public void FillTable(int managerId)
        {
            List<Employee> employeesForManager = GetEmployeesForManager(managerId);
            DataTable dt = ConvertToDatatable(employeesForManager);
            
            // This could maybe be its own "SanitizeEmployeeTable()" method
            dt.Columns.Remove("ManagerId");
            dt.Columns.Remove("Roles");
            empTable.DataSource = dt;
            empTable.Columns["Id"].HeaderText = "Employee ID";
            empTable.Columns["Id"].DisplayIndex = 0;
            empTable.Columns["LastName"].HeaderText = "Last Name";
            empTable.Columns["LastName"].DisplayIndex = 1;
            empTable.Columns["FirstName"].HeaderText = "First Name";
            empTable.Columns["FirstName"].DisplayIndex = 2;
        }
        
        // I could explain this method if I had to but I "borrowed" it from SO
        private static DataTable ConvertToDatatable<T>(List<T> data)
        { 
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++) 
            {
                PropertyDescriptor prop = props[i];
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]); 
                else
                    table.Columns.Add(prop.Name, prop.PropertyType);
            }

            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        private void ManagerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillTable( (int)ManagerList.SelectedValue );
        }
    }
    
    // This is for switching back once an employee is added or the add process cancelled
    public class FormProvider
    {
        public static EmployeesTableWindow MainMenu
        {
            get
            {
                if (_mainMenu == null)
                {
                    _mainMenu = new EmployeesTableWindow();
                }
                return _mainMenu;
            }
        }
        private static EmployeesTableWindow _mainMenu;
    }
}