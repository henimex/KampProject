using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.BusinessRules
{
    public class ProductManagerRules : IProductRuler
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManagerRules(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        public IResult RuleCategoryLimit(int categoryLimit)
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > categoryLimit)
            {
                return new ErrorResult(Messages.YeniCategoryEklemeUyarisi);
            }

            return new SuccessResult();
        }

        public IResult RuleProductNameExists(string search)
        {
            var result = _productDal.GetAll(x => x.ProductName == search).Any();
            if (result) return new ErrorResult(Messages.NameAlreadyExists);

            return new SuccessResult();
        }

        public IResult RuleCategoryCount(int maxCount, int categoryId)
        {
            var currentCount = _productDal.GetAll(x => x.CategoryId == categoryId).Count;
            if (currentCount >= maxCount) return new ErrorResult(Messages.CategoryAdetUyarısı);
            return new SuccessResult();
        }
    }
}
