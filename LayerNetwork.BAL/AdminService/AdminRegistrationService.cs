using LayerNetwork.BAL.IAdminService;
using LayerNetwork.Model.AdminModel;
using Layers.DAL.EntityDbContext;
using Layers.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace LayerNetwork.BAL.Service
{
   public class AdminRegistrationService: IAdminRegistrationService
    { 
        private readonly ApplicationDBContext Context ;
        private UnitOfWork _unitOfwork;
        public AdminRegistrationService( ApplicationDBContext _Context)
        {
            Context = _Context;
            _unitOfwork=new UnitOfWork(_Context);
        }

        public Employee CreateAdmin(Employee employee)
        {
            return _unitOfwork.IAdminRegistrationRepository.CreateAdmin(employee);
        }

        public EmployeeModel CreateAdmin(EmployeeModel employeemodel)
        {
            return _unitOfwork.IAdminRegistrationRepository.CreateAdmin(employeemodel);
        }

        public List<EmployeeModel> DataRecieve()
        {
            return _unitOfwork.IAdminRegistrationRepository.DataRecieve();
        }

        public bool DeleteAdmin(int id)
        {
            return _unitOfwork.IAdminRegistrationRepository.DeleteAdmin(id);
        }

        public Employee GetAdminById(int id)
        {
            var result = _unitOfwork.IAdminRegistrationRepository.GetAdminById(id);
            return result;
        }

        public List<Employee> Getdata()
        {
            return _unitOfwork.IAdminRegistrationRepository.Getdata();
        }

        public Employee UpdateAdmin(Employee employee)
        {
            return _unitOfwork.IAdminRegistrationRepository.UpdateAdmin(employee);
        }
 
    }
}
