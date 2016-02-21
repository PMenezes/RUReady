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
        public IEnumerable<ResponseDTO> GetAllResponses(UserDTO user)
        {
            IEnumerable<Response> list = Gateway.Repositories.Response.Query(true).Where(response => response.From.Key == user.Key).ToList();

            return Mapper.Map<IEnumerable<ResponseDTO>>(list);
        }

        public IEnumerable<ResponseDTO> GetAllResponsesForDare(DareDTO dare)
        {
            IEnumerable<Response> list = Gateway.Repositories.Response.Query(true).Where(response => response.Dare.Key == dare.Key).ToList();

            return Mapper.Map<IEnumerable<ResponseDTO>>(list);
        }

        public ResponseDTO Get(ResponseDTO response)
        {
            var model = Mapper.Map<Response>(response);
            model.EnsureNotNull(new ArgumentNullException("response", "Response not valid, cannot be null"));

            var result = Gateway.Repositories.Response.Get(model, true);

            return result != null ? Mapper.Map<ResponseDTO>(result) : null;
        }

        public ResponseDTO Insert(ResponseDTO response)
        {
            var model = Mapper.Map<Response>(response);

            model.EnsureNotNull(new ArgumentNullException("response", "Response not valid, cannot be null"));

            var result = Gateway.Repositories.Response.Insert(model);

            if (result == null) return null;

            return Mapper.Map<ResponseDTO>(result);
        }

        public bool Delete(ResponseDTO response)
        {
            var model = Mapper.Map<Response>(response);
            model.EnsureNotNull(new ArgumentNullException("response", "Response not valid, cannot be null"));

            var result = Gateway.Repositories.Response.Delete(model);

            return result;
        }
    }
}
