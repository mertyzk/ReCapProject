using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList(); 
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}

/*
 Bir kişinin claimlerini ararken 12. satırdaki, 18. satırdaki kodlar gibi şeyler yazmamız gerekiyor. .NET bizi biraz uğraştırıyor.
JWT'den gelen claimlerini okumak için .NET içerisindeki ClaimsPrincipal adlı classları extend ediyoruz. (ClaimsPrincipal = System.Security.Claims'ten geliyor.)
Bunları normalde uzun uzun yazmak gerekirken "string claimType" hangi claimType mesela roller, onları bulmam gerekiyor.
? null olabilir demektir. Örneğin claim oluşmamış, token istememiş. İşte o zaman null olabilir.

Bize çoğunlukla roller lazım. 16. satırda claimsPrincipal.ClaimRoles dediğimizde rolleri getir, bizi uğraştırma diyoruz.
 */