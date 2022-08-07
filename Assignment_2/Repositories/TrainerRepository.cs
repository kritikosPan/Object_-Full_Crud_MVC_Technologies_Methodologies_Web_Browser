using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Assignment_2.MyContext;
using Assignment_2.Models;

namespace Assignment_2.Repositories
{
    public class TrainerRepository
    {
        ApllicationContext db;

        public TrainerRepository(ApllicationContext context)
        {
            db = context;
        }





        public List<Trainer> GetAll()
        {
            return db.Trainers.ToList();
        }


        public Trainer GetById(int? id)
        {
            var trainer = db.Trainers.Find(id);
            return trainer;
        }





        public void Add(Trainer trainer)
        {
            db.Entry(trainer).State = EntityState.Added;
            db.SaveChanges();
        }






        public void Edit(Trainer trainer)
        {
            db.Entry(trainer).State = EntityState.Modified;
            db.SaveChanges();
        }







        public void Delete(Trainer trainer)
        {
            db.Entry(trainer).State = EntityState.Deleted;
            db.SaveChanges();
        }


    }
}