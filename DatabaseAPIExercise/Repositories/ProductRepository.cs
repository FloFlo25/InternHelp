using DatabaseAPIExercise.Context;
using DatabaseAPIExercise.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseAPIExercise.Repositories
{
    public interface IProductRepository
    {
        Product CreateProduct(Product product);
        Product UpdateProduct(Product product);
        Product DeleteProduct(Guid productId);


        List<Product> GetProducts();
        
    }

    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _context;

        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Product CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product DeleteProduct(Guid productId)
        {
            var a = _context.Products.Remove(_context.Products.Find(productId));
            
            _context.SaveChanges();
            return null;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.Include(p => p.Ratings).ToList();
        }

        //TODO: need two products?
        public Product UpdateProduct(Product product)
        {
            var searchedProduct = _context.Products.First(p => p.Id==product.Id);
            searchedProduct = product;
            _context.SaveChanges();
            return searchedProduct;
        }
    }
}
