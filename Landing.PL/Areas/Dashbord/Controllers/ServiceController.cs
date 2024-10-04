using AutoMapper;
using Landing.DAL.Data;
using Landing.DAL.Models;
using Landing.PL.Areas.Dashbord.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Landing.PL.Areas.Dashbord.Controllers
{
    [Area("Dashbord")]
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ServiceController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var services = mapper.Map<IEnumerable<ServiceVM>>(context.Services.ToList());
            return View(services);
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
        public IActionResult Details(int id)
        {
            var service = context.Services.Find(id);
            if (service is null)
            {
                return NotFound();
            }
            var serviceModel = mapper.Map<ServiceDetails>(service);
            return View(serviceModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var service = context.Services.Find(id);
            if (service is null)
            {
                return NotFound();
            }
            var serviceModel = mapper.Map<ServiceDetails>(service);
            return View(serviceModel);
        }


        [HttpPost, ActionName("Delete")]
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var service = context.Services.Find(id);
            if (service is null)
            {
                return NotFound();
            }
            var serviceVM = mapper.Map<ServiceFormVM>(service);
            return View(serviceVM);
        }

        [HttpPost]
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
            context.SaveChanges(); 
            return RedirectToAction("Index");
        }


    }
}
