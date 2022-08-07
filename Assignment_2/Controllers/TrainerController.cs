using Assignment_2.MyContext;
using Assignment_2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment_2.Models;


namespace Assignment_2.Controllers
{
    public class TrainerController : Controller
    {
        private ApllicationContext db = new ApllicationContext();

        private TrainerRepository trainerRepository;

        public TrainerController()
        {
            trainerRepository = new TrainerRepository(db);
        }

        
        public ActionResult Index()
        {   
            var trainers = trainerRepository.GetAll();

            return View(trainers);
        }

        public ActionResult Details(int? Id)
        {
            var trainer = trainerRepository.GetById(Id);
            if (trainer == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            
            return View(trainer);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Trainer trainer)  
        {   
            if (ModelState.IsValid)               
            {
                trainerRepository.Add(trainer);
                TempData["message"] = "You have succesfully created trainer " + trainer.FirstName;
                return RedirectToAction("Index");
            }

            return View(trainer);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var emp = trainerRepository.GetById(id);

            if (emp == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                trainerRepository.Edit(trainer);
                TempData["message"] = $"Employee with id {trainer.Id} Successfully Modified";
                
                return RedirectToAction("Index");
            }
            return View(trainer);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            var trainer = trainerRepository.GetById(id);
            if (trainer == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            trainerRepository.Delete(trainer);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }

    }
}