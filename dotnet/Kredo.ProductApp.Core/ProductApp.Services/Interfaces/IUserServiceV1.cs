﻿using ProductApp.Models.Domain.Users;
using ProductApp.Models.Requests.Users;
using System.Collections.Generic;

namespace ProductApp.Services.Interfaces
{
    public interface IUserServiceV1
    {
        int Add(UserAddRequest model, int CurrentUserId);
        void Delete(int id);
        User Get(int id);
        List<User> GetAll();
        void Update(UserUpdateRequest model, int CurrentUserId);
    }
}