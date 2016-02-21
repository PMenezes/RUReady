using DTOs;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Models;
using System;
using Repositories;

namespace Services.Core
{
    public partial class Service
    {
        public IEnumerable<DareDTO> GetAllDares(UserDTO user)
        {
            IEnumerable<Dare> list = Gateway.Repositories.Dare.Query(true).Where(dare => dare.From.Key == user.Key).ToList();

            return Mapper.Map<IEnumerable<DareDTO>>(list);
        }

        public DareDTO Get(DareDTO dare) {
            var model = Mapper.Map<Dare>(dare);
            model.EnsureNotNull(new ArgumentNullException("dare", "Dare not valid, cannot be null"));

            var result = Gateway.Repositories.Dare.Get(model, true);

            return result != null ? Mapper.Map<DareDTO>(result) : null;
        }

        public DareDTO Insert(DareDTO response)
        {
            var model = Mapper.Map<Dare>(response);

            model.EnsureNotNull(new ArgumentNullException("dare", "Dare not valid, cannot be null"));

            var result = Gateway.Repositories.Dare.Insert(model);

            if (result == null) return null;

            return Mapper.Map<DareDTO>(result);
        }

        public bool Delete(DareDTO response)
        {
            var model = Mapper.Map<Dare>(response);
            model.EnsureNotNull(new ArgumentNullException("dare", "Dare not valid, cannot be null"));

            var result = Gateway.Repositories.Dare.Delete(model);

            return result;
        }

    }
}
