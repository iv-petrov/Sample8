using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sample8.Domain;
using Sample8.DataModels;

namespace Sample8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICompanyService _companyService;

        public HomeController(ILogger<HomeController> logger, ICompanyService service)
        { 
            _logger = logger;
            _companyService = service;
        }

        public IActionResult Index()
        {
            return View(_companyService.GetAll());
        }

        [HttpGet("Append", Name = "AppendCompany")]
        public IActionResult AppendCompany()
        {
            Company company = new ();
            return View("Append", company);
        }

        [HttpGet("Update/{id}", Name = "UpdateCompany")]
        public IActionResult UpdateCompany(int id)
        {
            Company company = _companyService.GetById(id);
            return View("Update", company);
        }

        [HttpPost()]
        public IActionResult Save(Company company)
        {
            if (String.IsNullOrEmpty(company.Name))
            {
                ModelState.ClearValidationState("Name");
                ModelState.AddModelError("Name", "Поле наименование должно быть заполнено");
                if (company.Id == null)
                    return View("Append", company);
                else
                    return View("Update", company);
            }
            if (String.IsNullOrEmpty(company.Inn))
            {
                ModelState.ClearValidationState("Inn");
                ModelState.AddModelError("Inn", "Поле ИНН обязательное");
                if (company.Id == null)
                    return View("Append", company);
                else
                    return View("Update", company);
            }
            if (company.Id == null)
            {
                _companyService.AppendCompany(company);
            }
            else
            {
                _companyService.UpdateCompany(company);
            }
            return RedirectToAction("");
        }

        [HttpGet("Delete/{id}", Name = "Delete")]
        public IActionResult Delete(int id)
        {
            _companyService.DeleteCompany(id);
            return RedirectToAction("");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
