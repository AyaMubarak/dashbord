using AutoMapper;
using Landing.DAL.Data;
using Landing.DAL.Models;
using Landing.PL.Areas.Dashboard.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Landing.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        

        public ServicesController(ApplicationDbContext context,IMapper mapper )
        {
            this.context = context;
           this.mapper = mapper;
        }

        public IActionResult Index()
        {
          
          
            return View(mapper.Map<IEnumerable<ServiceVM>>(context.Services.ToList()));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceFormVM vm)
        {
            if (!ModelState.IsValid)
            {
               return View(vm);
            } 
            var service = mapper.Map<Service>(vm);
            context.Add(service);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var service = context.Services.Find(id);
            if (service == null)
            {
                return NotFound();
            }

            var serviceFormVM = mapper.Map<ServiceFormVM>(service);
            return View(serviceFormVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ServiceFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var service = context.Services.Find(vm.Id);
            if (service == null)
            {
                return NotFound();
            }
            mapper.Map(vm, service);
            context.Update(service);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public IActionResult Details(int id)
        {
            var service = context.Services.Find(id);
            if (service == null)
            {
                return NotFound();
            }

            return View(mapper.Map<ServiceDetailsVM>(service));
        }
      
        public IActionResult Delete(int id)
        {
            var service = context.Services.Find(id);
            if (service == null)
            {
                return NotFound();
            }

            return View(mapper.Map<ServiceVM>(service));
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var service = context.Services.Find(id);
            if (service is null)
            {
                return RedirectToAction(nameof(Index));
            }
            context.Services.Remove(service);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
