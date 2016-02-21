using AutoMapper;
using DTOs;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Core
{
    public partial class Service
    {
        public IEnumerable<UserDTO> GetAllUsers()
        {
            IEnumerable<User> list = Gateway.Repositories.User.Query(true).ToList();

            return Mapper.Map<IEnumerable<UserDTO>>(list);
        }

        public UserDTO Get(UserDTO user)
        {
            var model = Mapper.Map<User>(user);
            model.EnsureNotNull(new ArgumentNullException("user", "User not valid, cannot be null"));

            var result = Gateway.Repositories.User.Get(model, true);

            return result != null ? Mapper.Map<UserDTO>(result) : null;
        }

        public UserDTO Insert(UserDTO user)
        {
            var model = Mapper.Map<User>(user);

            model.EnsureNotNull(new ArgumentNullException("user", "User not valid, cannot be null"));

            var result = Gateway.Repositories.User.Insert(model);

            if (result == null) return null;

            return Mapper.Map<UserDTO>(result);
        }

        public UserDTO Edit(UserDTO user)
        {
            var model = Mapper.Map<User>(user);
            model.EnsureNotNull(new ArgumentNullException("user", "User not valid, cannot be null"));

            var result = Gateway.Repositories.User.Update(model);

            if (result == null) return null;
            
            return Mapper.Map<UserDTO>(result);
        }

        public bool Delete(UserDTO user)
        {
            var model = Mapper.Map<User>(user);
            model.EnsureNotNull(new ArgumentNullException("user", "User not valid, cannot be null"));

            var result = Gateway.Repositories.User.Delete(model);

            return result;
        }
    }
}
