﻿using Core.DataAccess;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService 
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetID(int userID);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
    }
}
