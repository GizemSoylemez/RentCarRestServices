using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCar.Data.Abstract;
using RentCar.Entity;

namespace RentCar.RestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private IUnitOfWork uow;
        public CarController(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        [HttpPost]
        public StatusCodeResult AddCar(Car entity)
        {
            try
            {
                uow.Cars.Add(entity);
                uow.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public StatusCodeResult UpdateCar(Car entity)
        {
            try
            {
                uow.Cars.Update(entity);
                uow.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete]
        public StatusCodeResult RemoveCar(Car entity)
        {
            try
            {
                uow.Cars.Delete(entity);
                uow.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public List<Car> GetAll()
        {
            try
            {
                return uow.Cars.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}