using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetByUserId(int userId);
        public void Add(User user);
        public void Update(User user);
        public void Delete(User user);
    }
}
