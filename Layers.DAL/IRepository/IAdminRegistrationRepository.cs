using LayerNetwork.Model.AdminModel;
using Layers.DAL.EntityDbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layers.DAL.IRepository
{
    public interface IAdminRegistrationRepository
    {
       public List<Employee> Getdata();
        public List<EmployeeModel> DataRecieve();

        public Employee CreateAdmin(Employee employee);
        public EmployeeModel CreateAdmin(EmployeeModel employeemodel);

        public bool DeleteAdmin(int id);

        public Employee GetAdminById(int id);
        public Employee UpdateAdmin(Employee employee);
    }
}
