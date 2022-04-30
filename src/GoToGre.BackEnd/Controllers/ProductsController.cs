﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoToGre.Common.Models;
using GoToGre.BackEnd.Repos;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoToGre.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly GoToGreRepo _repo;
        public ProductsController(GoToGreRepo repo) {
            _repo = repo;
                }
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return new List<Product>();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _repo.GetProductByID(id);
        }
        [HttpGet("{productType}")]
        public List<Product> GetByType(string productType)
        {
            return _repo.GetProductsByType(productType);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public Product Post([FromBody] Product value)
        {
            value.Id = default;
            return _repo.AddProduct(value);
        }
        [HttpPost("update")]
        public Product UpdateProduct([FromBody] Product value)
        {
            _repo.UpdateProduct(value);
            return _repo.GetProductByID(value.Id);
        }


        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.DeleteProduct(_repo.GetProductByID(id));
        }
    }
}
