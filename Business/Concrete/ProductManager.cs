using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConserns.Validation.FluentValidation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProdcutsListed);
        }

        public IDataResult<List<Product>> GetAllByCategory(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(
                RuleCategoryCount(OptionVariables.MaxCategoryCount, product.CategoryId),
                RuleProductNameExists(product.ProductName),
                RuleCategoryLimit(OptionVariables.CategoryEndLimit)
                );

            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            IResult result = BusinessRules.Run(
                RuleCategoryCount(OptionVariables.MaxCategoryCount, product.CategoryId),
                RuleProductNameExists(product.ProductName),
                RuleCategoryLimit(OptionVariables.CategoryEndLimit)
                );

            if (result != null)
            {
                return result;
            }

            _productDal.Update(product);
            return new SuccessResult();
        }

        private IResult RuleCategoryCount(int maxCount, int categoryId)
        {
            var currentCount = _productDal.GetAll(x => x.CategoryId == categoryId).Count;
            if (currentCount >= maxCount) return new ErrorResult(Messages.CategoryAdetUyarısı);
            return new SuccessResult();
        }

        private IResult RuleProductNameExists(string search)
        {
            var pname = _productDal.GetAll(x => x.ProductName == search).Any();
            if (pname) return new ErrorResult(Messages.NameAlreadyExists);

            return new SuccessResult();
        }

        private IResult RuleCategoryLimit(int categoryLimit)
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > categoryLimit)
            {
                return new ErrorResult("");
            }

            return new SuccessResult();
        }

    }
}
