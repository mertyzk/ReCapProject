using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Concrete
{
    public class OperationClaim:IEntity
    {
        [Key]
        public int OperationClaimId { get; set; }
        public string OperationName { get; set; }
    }
}
