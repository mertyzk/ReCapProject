using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim:IEntity
    {
        [Key]
        public int UserClaimId { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
