using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.BusinessRules;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
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
        IProductRuler _productRuler;

        public ProductManager(IProductDal productDal, ICategoryService categoryService, IProductRuler productRuler)
        {
            _productDal = productDal;
            _categoryService = categoryService;
            _productRuler = productRuler;
        }

        [CacheAspect]
        [PerformanceAspect(5)]
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

        [CacheAspect()]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            IResult result = BusinessRuleTool.Run(
                _productRuler.RuleCategoryCount(OptionVariables.MaxCategoryCount, product.CategoryId),
                _productRuler.RuleProductNameExists(product.ProductName),
                _productRuler.RuleCategoryLimit(OptionVariables.CategoryEndLimit)
                );

            if (result != null) return result;

            //return CheckAllRules(product);
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            IResult result = BusinessRuleTool.Run(
                _productRuler.RuleCategoryCount(OptionVariables.MaxCategoryCount, product.CategoryId),
                _productRuler.RuleProductNameExists(product.ProductName),
                _productRuler.RuleCategoryLimit(OptionVariables.CategoryEndLimit)
                );

            if (result != null) return result;
            _productDal.Update(product);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactional(Product product)
        {
            //Test Senaryosu
            Add(product);

            if (product.UnitPrice > 50)
            {
                Add(product);
                return new SuccessResult();
            }

            throw new TransactionAbortedException(Messages.TransactionAborted);
            return new ErrorResult(Messages.TransactionAborted);
        }

        private IResult CheckAllRules(Product product)
        {
            //trying to methodize this one
            IResult result = BusinessRuleTool.Run(
                _productRuler.RuleCategoryCount(OptionVariables.MaxCategoryCount, product.CategoryId),
                _productRuler.RuleProductNameExists(product.ProductName),
                _productRuler.RuleCategoryLimit(OptionVariables.CategoryEndLimit)
            );

            if (result != null)
                return result;
            else
                return null;
        }
    }
}
