using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IBrandService
    {
        void Add(Brand brand);
        void Delete(Brand brand);
        List<Brand> GetAll();
        List<Brand> GetById(int id);
        void Update(Brand brand);
    }
}
