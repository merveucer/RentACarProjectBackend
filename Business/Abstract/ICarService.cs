using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService : IEntityService<Car, int>
    {
        IDataResult<List<Car>> GetAllByBrandId(int brandId);
        IDataResult<List<Car>> GetAllByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetAllWithCarDetails();
        IDataResult<CarDetailDto> GetWithCarDetailsById(int id);
    }
}
