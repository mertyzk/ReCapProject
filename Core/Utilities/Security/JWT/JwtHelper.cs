using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Microsoft.Extensions.Configuration;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {

        public IConfiguration Configuration { get; }

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            
        }
    }
}
