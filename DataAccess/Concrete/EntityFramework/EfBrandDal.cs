using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (CarRentalProjectDbContext context = new CarRentalProjectDbContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (CarRentalProjectDbContext context = new CarRentalProjectDbContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (CarRentalProjectDbContext context = new CarRentalProjectDbContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (CarRentalProjectDbContext context = new CarRentalProjectDbContext())
            {
                return filter == null ? context.Set<Brand>().ToList() : context.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand entity)
        {
            using (CarRentalProjectDbContext context = new CarRentalProjectDbContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}