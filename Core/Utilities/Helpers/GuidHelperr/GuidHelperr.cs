using System;
namespace Core.Utilities.Helpers.GuidHelper
{
    public class GuidHelperr
    {
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
