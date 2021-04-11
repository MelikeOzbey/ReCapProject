using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        List<UserOperationClaimsDto> GetUserClaims(int userId);
    }
}
