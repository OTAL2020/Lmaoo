﻿using Otal.lmaoo.Core.Entities;

namespace Otal.lmaoo.Services.Interfaces
{
    public interface IUserService
    {
        public User Get(int id);

        public User GetByUsernameAndPassword(string username, string password);
    }
}
