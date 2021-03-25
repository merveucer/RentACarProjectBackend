using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands;

        public InMemoryBrandDal()
        {
            _brands = new List<Brand>
            {
                new Brand{BrandId=1,BrandName="Marka1"},
                new Brand{BrandId=2,BrandName="Marka2"},
                new Brand{BrandId=3,BrandName="Marka3"}
            };
        }

        public void Add(Brand brand)
        {
            _brands.Add(brand);
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete = _brands.SingleOrDefault(b => b.BrandId == brand.BrandId);

            _brands.Remove(brandToDelete);
        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(b => b.BrandId == brand.BrandId);

            brandToUpdate.BrandName = brand.BrandName;
        }
    }
}
