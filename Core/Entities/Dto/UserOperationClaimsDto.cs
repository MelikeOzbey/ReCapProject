using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class UserOperationClaimsDto
    {
        public int OperationClaimId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
