﻿using Business.Concrete;
using System;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ListProducts();
            //CategoryTest();

            //    ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));

            //    var result = productManager.GetProductDetails();
            //    if (result.Success)
            //    {
            //        foreach (var productDetailDto in result.Data)
            //        {
            //            Console.WriteLine(productDetailDto.ProductName);
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine(result.Message);
            //    }

            //    //foreach (var productDetailDto in productManager.GetProductDetails().Data)
            //    //{
            //    //    Console.WriteLine(productDetailDto.ProductName +" " + productDetailDto.CategoryName);
            //    //}
            //}

            //private static void CategoryTest()
            //{
            //    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            //    //foreach (var category in categoryManager.GetAll())
            //    //{
            //    //    Console.WriteLine(category.CategoryName);
            //    //}
            //}

            //private static void ListProducts()
            //{
            //    ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));

            //    foreach (var product in productManager.GetAll().Data)
            //    {
            //        Console.WriteLine(product.ProductName);
            //    }

            //    foreach (var product in productManager.GetAllByCategory(12).Data)
            //    {
            //        Console.WriteLine(product.ProductName);
            //    }

            //    foreach (var product in productManager.GetByUnitPrice(10, 25).Data)
            //    {
            //        Console.WriteLine(product.ProductName);
            //    }
            //}
        }
    }
}
