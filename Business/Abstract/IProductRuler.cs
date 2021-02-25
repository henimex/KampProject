using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IProductRuler
    {
        IResult RuleCategoryLimit(int categoryLimit);
        IResult RuleProductNameExists(string search);
        IResult RuleCategoryCount(int maxCount, int categoryId);
    }
}
