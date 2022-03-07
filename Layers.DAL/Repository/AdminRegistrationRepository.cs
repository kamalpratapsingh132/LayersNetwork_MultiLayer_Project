using LayerNetwork.Model.AdminModel;
using Layers.DAL.EntityDbContext;
using Layers.DAL.IRepository;
using Layers.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Layers.DAL.Repository
{
   public class AdminRegistrationRepository : IAdminRegistrationRepository
    {
        private readonly ApplicationDBContext _context;
        public AdminRegistrationRepository(ApplicationDBContext context)
        {
            _context = context;

        }

        public Employee CreateAdmin(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return employee;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EmployeeModel CreateAdmin(EmployeeModel employeemodel)
        {
            try
            {
                _context.EmployeeModels.Add(employeemodel);
                _context.SaveChanges();
                return employeemodel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<EmployeeModel> DataRecieve()
        {
            try
            {


                var show = _context.EmployeeModels.ToList();
                return show;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool DeleteAdmin(int id)
        {
            try
            {
                var cat = _context.Employees.SingleOrDefault(e => e.ID == id);
            if (cat != null)
            {
                _context.Employees.Remove(cat);
                _context.SaveChanges();

                return true;

            }
            else
            {
                return false;
            }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Employee GetAdminById(int id)
        {
            try { 
            var cats = _context.Employees.SingleOrDefault(e => e.ID == id);
            return cats;
        }
            catch (Exception ex)    
            {

                         throw ex;
                        }
}

        public List<Employee> Getdata()
        {
            try
            {


                var cats = _context.Employees.ToList();
            return cats;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Employee UpdateAdmin(Employee employee)
        {
            try { 
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return employee;
        }
            catch (Exception ex)    
            {

                         throw ex;
                        }
}
    }
}
