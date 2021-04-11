using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Entities.Dto;
using Core.Utilities.Result;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<User> Get(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.Updatetd);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
           
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<UserOperationClaimsDto>> GetUserClaims(int userId)
        {
            return new SuccessDataResult<List<UserOperationClaimsDto>>(_userDal.GetUserClaims(userId));
        }
    }
}
