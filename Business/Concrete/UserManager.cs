using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    //Interface result yapısına cevrildikten sonra tekrar refactor edildi.
    public class UserManager : IUserService
    {
        //IUserDal _userDal;

        //public UserManager(IUserDal userDal)
        //{
        //    _userDal = userDal;
        //}

        //public IDataResult<List<OperationClaim>> GetClaims(User user)
        //{
        //    return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        //}

        //public IResult Add(User user)
        //{
        //    _userDal.Add(user);
        //    return new SuccessResult(Messages.ProductAdded);
        //}

        //public IDataResult<User> GetByMail(string email)
        //{
        //    return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        //}

        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}