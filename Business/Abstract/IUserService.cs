using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserService
    {
        //IDataResult<List<OperationClaim>> GetClaims(User user);
        //IResult Add(User user);
        //IDataResult<User> GetByMail(string email);

        /*Eski Hali Auth Managerda hata alınması durumunda kontrol edilmesi gereken refactor başlangıcı burası ve AuthManager Login işlemidir.
        
        */
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
    }
}
