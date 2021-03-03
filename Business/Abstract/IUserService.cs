using Core.Entities.Concrete;
using Core.Utilities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService 
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetID(int userID);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
    }
}
