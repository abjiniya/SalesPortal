using Microsoft.AspNetCore.Mvc;
using SalesPortalAPI.Core.Repository;
using SalesPortalAPI.Data;
using SalesPortalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class QuotationController : ControllerBase
    {
        private readonly QuotationDBContext _context;
        private readonly IDataGenerator<Quotation> _quotationsGeneratorService;
        
        public QuotationController(QuotationDBContext context, IDataGenerator<Quotation> dataGeneratorService)
        {
            _context = context;
            _quotationsGeneratorService = dataGeneratorService;
        }
        // GET: api/<QuotationController>
        [HttpGet("Get")]
        /// <summary>
        /// Gets the Quotations from in memory data.
        /// </summary>
        public IEnumerable<Quotation> Get()
        {
            return _context.Quotations;           
        }

        [HttpGet("GetData")]
        /// <summary>
        /// Gets the Quotations from mock data.
        /// </summary>
        public IEnumerable<Quotation> GetData()
        {
            return _quotationsGeneratorService.Collection(10000).Distinct(); //Generates mock data using GenFu library
        }

        // POST api/<QuotationController>
        [HttpPost]
        /// <summary>
        /// Post the Quotations to in memory data.
        /// </summary>
        public void Post([FromBody] Quotation quotation)
        {
            _context.Quotations.Add(quotation);
            _context.SaveChanges();
        }


        // PUT api/<QuotationController>/5
        [HttpPut("{id}")]
        /// <summary>
        /// Update the Quotation to in memory data.
        /// </summary>
        public void Put(int id, [FromBody] Quotation quotation)
        {
            var entity = _context.Quotations.Where(x => x.Id == id).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception("Quotation with id " + id + "not found in database");
            }
            entity.Number = quotation.Number;
            entity.DealerName = quotation.DealerName;
            entity.Description = quotation.Description;
            entity.DateOfQuotation = quotation.DateOfQuotation;
            entity.ValidUntil = quotation.ValidUntil;
            entity.Price = quotation.Price;
            entity.ProductName = quotation.ProductName;
            entity.CustomerName = quotation.CustomerName;
            _context.Quotations.Update(entity);
            _context.SaveChanges();
        }

        // DELETE api/<QuotationController>/5
        [HttpDelete("{id}")]
        /// <summary>
        /// Delete the Quotation to in memory data.
        /// </summary>
        public void Delete(int id)
        {
            var quotation = _context.Quotations.Where(x => x.Id == id).FirstOrDefault();
            if (quotation == null)
            {
                throw new Exception("Quotation with id " + id + "not found in database");
            }
            _context.Quotations.Remove(quotation);
            _context.SaveChanges();
        }
    }
}
