﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.Entity_Framework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public List<Car> Get()
        {

            ICarService carService = new CarManager(new EfCarDal());
            var result = carService.GetAll();
            return result.Data;
           
        }
    }
}