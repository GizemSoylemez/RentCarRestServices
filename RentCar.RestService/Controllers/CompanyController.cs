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
    public class CompanyController : ControllerBase
    {
        private IUnitOfWork uow;
        public CompanyController(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        [HttpPost]
        public StatusCodeResult AddCompany(Company entity)
        {
            try
            {
                uow.Companies.Add(entity);
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
        public StatusCodeResult RemoveCompany(Company entity)
        {
            try
            {
                uow.Companies.Delete(entity);
                uow.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public List<Company> GetAll()
        {
            try
            {
                return uow.Companies.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}