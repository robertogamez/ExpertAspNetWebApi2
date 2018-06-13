﻿using ExampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExampleApp.Controllers.WebApi
{
    public class ProductsController : ApiController
    {
        IRepository repo;

        public ProductsController(IRepository repoImpl)
        {
            repo = repoImpl;
        }

        public IEnumerable<Product> GetAll()
        {
            return repo.Products;
        }

        public void Delete(int id)
        {
            repo.DeleteProduct(id);
        }

        public void Post(Product product)
        {
            repo.SaveProduct(product);
        }
    }
}
