using DatabaseAPIExercise.Models;
using DatabaseAPIExercise.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseAPIExercise.Business
{
    public enum FilterType
    {
        ASC,
        DESC,
    }

    public interface IProductManager
    {
        //Standard methods
        Product CreateProduct(Product product);
        Product UpdateProduct(Product product);
        Product DeleteProduct(Guid productId);
        List<Product> GetProducts();



        //Filtering methods
        Product GetMostRecentProduct();
        Product GetOldestProduct();
        List<Product> GetProductsByAvgRating(FilterType filterType);
        List<Product> GetProductsByKeyword(string keyword);


    }

    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public Product CreateProduct(Product product)
        {
            return _productRepository.CreateProduct(product);
        }

        public Product DeleteProduct(Guid productId)
        {
            return _productRepository.DeleteProduct(productId);
        }

        public Product GetMostRecentProduct()
        {
            var list = GetProducts();
            list.Reverse();
            var a = list.FirstOrDefault();
            return a;
        }

        public Product GetOldestProduct()
        {
            var list = GetProducts();
            var a = list.FirstOrDefault();
            return a;
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public List<Product> GetProductsByAvgRating(FilterType filterType)
        {
            if (filterType==FilterType.ASC)
            {
                return _productRepository.GetProducts().OrderBy(p => p.Ratings.Average(x=>x.Value)).ToList();
            }
            return _productRepository.GetProducts().OrderByDescending(p => p.Ratings.Average(x => x.Value)).ToList(); ;
        }



        public List<Product> GetProductsByKeyword(string keyword)
        {
            List<Product> products = new List<Product>(GetProducts());
            List<Product> output = new List<Product>();

            foreach (var product in products)
            {
                if (product.Name.ToLower().Contains(keyword.ToLower()) ||(product.Description.ToLower().Contains(keyword.ToLower())))
                {
                    output.Add(product);

                }
            }

            return output;
        }

        public Product UpdateProduct(Product product)
        {
           return _productRepository.UpdateProduct(product);
        }

        /// <summary>
        /// Old sorting method using Dict<>
        /// </summary>
        /// <returns></returns>
        public List<Product> CreatProd_AvgDict()
        {
            Dictionary<Product,double> dict = new Dictionary<Product,double>();
            var list = GetProducts();

            foreach (var product in list)
            {
                var avg = product.Ratings.Average(x => x.Value);

                dict.Add(product, avg);
            }

            dict.OrderBy(x => x.Value);

            List<Product> products = new List<Product>();

            foreach (var product in dict)
            {
                products.Add(product.Key);
            }

            return products;
            
        }
    }
}
