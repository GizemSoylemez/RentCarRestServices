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
    public class WorkerController : ControllerBase
    {
        private IUnitOfWork uow;
        public WorkerController(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        public StatusCodeResult AddWorker(Worker entity)
        {
            try
            {
                uow.Workers.Add(entity);
                uow.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public StatusCodeResult UpdateWorker(Worker entity)
        {
            try
            {
                uow.Workers.Update(entity);
                uow.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete]
        public StatusCodeResult RemoveWorker(Worker entity)
        {
            try
            {
                uow.Workers.Delete(entity);
                uow.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}