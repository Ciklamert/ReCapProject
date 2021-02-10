using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService:IEntityService<Car>
    {
        
        

        List<Car> GetAllByBrandId(int brandId);
        List<Car> GetAllByColorId(int colorId);

        List<CarDetailDto> GetCarDetails();

        
    }
}
