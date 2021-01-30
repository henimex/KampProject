using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product { ProductId = 1,ProductName = "Kitap", CategoryId = 1,UnitPrice = 15,UnitsInStock = 15 },
                new Product { ProductId = 2,ProductName = "Kamera", CategoryId = 1,UnitPrice = 500,UnitsInStock = 3 },
                new Product { ProductId = 3,ProductName = "Elbise", CategoryId = 2,UnitPrice = 1500,UnitsInStock = 2 },
                new Product { ProductId = 4,ProductName = "Telefon", CategoryId = 2,UnitPrice = 150,UnitsInStock = 65 },
                new Product { ProductId = 5,ProductName = "Laptop", CategoryId = 2,UnitPrice = 85,UnitsInStock = 1 }
            };
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public void Delete(Product product)
        {
            //Product productToDelete = null;

            //foreach (var pro in _products)
            //{
            //    if (product.ProductId == pro.ProductId)
            //    {
            //        productToDelete = pro;
            //    }
            //}

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=>p.CategoryId == categoryId).ToList();
        }
    }
}
