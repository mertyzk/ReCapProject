using System;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constans;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception // Bu SecuredOperation JTW için.
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; // HttpContextAccessor bir interface olarak geliyor ve Microsoft.AspnetCore.Http.Abstractions'dan geliyor. JWT isteklerinde bir thread oluşturuyor.

        public SecuredOperation(string roles) // Bana rolleri ver diyoruz.
        {
            _roles = roles.Split(','); // Rollerimiz virgül ile ayrılarak geliyor. Örneğin [SecuredOperation("brands.add,admin")] Split burada virgül ile gelen iki veriyi bir Array'e atıyor.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        // API'de ilgili Controller'da constructor ile dependency injection yaptık, API'de IoC herşey hazır. Fakat bunu Windows Form uygulamasında bu injection'u kullanamazsın.
        // Bu yüzden ServiceTool yazdık. Bu ServiceTool'u kullanarak bizim injection alt yapımızı okuyabilmemizi sağlayan bir araç olacak.
        // SecuredOperation bir ASPECT olduğu için IConfiguration'u enjekte edemiyoruz.
        // Autofac ile oluşturduğumuz servis mimarisine ulaş( Get.Service )

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }


        // OnBefore ile ilgili metodun önünde çalıştırıyoruz. O andaki kullanıcının rollerini bulalım (HttpContext.User.ClaimsRoles)
        // Sonra diyoruz ki eğer claimlerinin içinde ilgili rol varsa metodu çalıştırmaya devam et. Bir problem varsa hata fırlat.
    }
}

