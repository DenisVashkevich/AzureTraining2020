using System.Web.Mvc;
using Microsoft.ApplicationInsights;
using AdventureWorks.Services.HumanResources;

namespace AdventureWorks.Web.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly TelemetryClient _telemetry = new TelemetryClient();

        // GET: Departments
        public ActionResult Index()
        {
            DepartmentService departmentService = new DepartmentService();
            var departmentGroups = departmentService.GetDepartments();

            _telemetry.TrackPageView("Departments (WebApp)");

            return View(departmentGroups);
        }

        // GET: Departments/Employees/{id}
        public ActionResult Employees(int id)
        {
            DepartmentService departmentService = new DepartmentService();
            var departmentEmployees = departmentService.GetDepartmentEmployees(id);
            var departmentInfo = departmentService.GetDepartmentInfo(id);

            ViewBag.Title = "Employees in " + departmentInfo.Name + " Department";

            _telemetry.TrackPageView($"Employees/{id} (WebApp)");

            return View(departmentEmployees);
        }
    }
}
