using LayerNetwork.BAL.IAdminService;
using LayerNetwork.Model.AdminModel;
using Layers.DAL.EntityDbContext;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LayersNetwork.web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminRegistrationService adminService;
        private readonly ApplicationDBContext Context;


        public AdminController(IAdminRegistrationService _AdminService,
           ApplicationDBContext _Context)
        {
            adminService = _AdminService;
            Context = _Context;
        }




        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Employee usermodel)
        {
            var userDetails = Context.Employees.Where(model => model.Email == usermodel.Email && model.Password == usermodel.Password).FirstOrDefault();
            if (userDetails == null)
            {
                ViewBag.Tempmessage = "INVALID USERNAME OR PASSWORD";
                return View("Login", usermodel);
            }
            else
            {
                //Session["id"] = userDetails.id;
                //Session["emp_id"] = userDetails.emp_id;
                //Session["UserName"] = Convert.ToString(userDetails.emp_name);
                return RedirectToAction("Show_data", "admin");
            }

        }
        public IActionResult Show_data()
        {
            var emp = adminService.Getdata();
            return View(emp);
        }
   
        public IActionResult Data_Recieve()
        {
            var emp = adminService.DataRecieve();
            return View(emp);
   }
        public IActionResult Create()                    
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid) 
            {

                var employee = new Employee()
                {
                    Name = model.Name,
                    Age = model.Age,
                    Email = model.Email,
                    Password = model.Password,
                    Gender = model.Gender,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.PhoneNumber

                };
                adminService.CreateAdmin(employee);
                return RedirectToAction("Show_data"); ;
            }
            else
            {
                return View("Create");
            }
        }

        public IActionResult Add_data()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add_data(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {


                var emp = new EmployeeModel()
            {
                Name = model.Name,
                Age = model.Age,
                Email = model.Email,
                Password = model.Password,
                Gender = model.Gender,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address

            };
            adminService.CreateAdmin(emp);
            return RedirectToAction("Data_Recieve");
            }
            else
            {
                return View("Add_data");
            }
        }
        public IActionResult Update(int id)
        {
            //var emp = adminService.GetAdminById(id);
            var emp = adminService.GetAdminById(id);
            var emp2 = new Employee()
            {
                ID = emp.ID,
                Name = emp.Name,
                Age = emp.Age,
                Email = emp.Email,
                Password = emp.Password,
                Gender = emp.Gender,
                PhoneNumber = emp.PhoneNumber,
                Address = emp.PhoneNumber
            };

            return View(emp2);
        }

        [HttpPost]
        public IActionResult Update(Employee model)
        {
            var emps = adminService.GetAdminById
               (model.ID);
            if (emps != null)
            {
                //update
                emps.Name = model.Name;
                emps.Age = model.Age;
                emps.Email = model.Email;
                emps.Password = model.Password;
                emps.Gender = model.Gender;
                emps.PhoneNumber = model.PhoneNumber;
                emps.Address = model.Address;


                adminService.UpdateAdmin(emps);
                return RedirectToAction("Show_data");

            }
            else
            {
                //do not update
                ViewBag.message = "Employee not found!";
                return View();
            }
        }


        public IActionResult Delete(int id)
        {
            var result = adminService.DeleteAdmin(id);
            if (result)
            {
                return RedirectToAction("Create");
            }
            else
            {
                ViewBag.message = "Data not found !";
                return RedirectToAction("Create");
            }
        }


        public IActionResult About()
        {
            return View();
        }

        public IActionResult Createjson()
        {
        return View();
        }



        public IActionResult Datatable()
        {
            return View();
        }
    }
}
