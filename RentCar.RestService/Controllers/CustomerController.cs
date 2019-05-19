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
    public class CustomerController : ControllerBase
    {
        private IUnitOfWork uow;
        public CustomerController(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        public StatusCodeResult AddCustomer(Customer entity)
        {
            try
            {
                uow.Customers.Add(entity);
                uow.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public StatusCodeResult UpdateCompany(Company entity)
        {
            try
            {
                uow.Companies.Update(entity);
                uow.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete]
        public StatusCodeResult RemoveCustomer(Customer entity)
        {
            try
            {
                uow.Customers.Delete(entity);
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