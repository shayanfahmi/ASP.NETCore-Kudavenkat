using System;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
	public class HomeController : Controller
	{
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		public string Index() {
			return _employeeRepository.GetEmployee(1).Name ;
		}

        public ViewResult Details()
        {
			Employee model = _employeeRepository.GetEmployee(1);
			ViewBag.PageTitle = "Employee Details";
			return View(model);
        }
    }
}

