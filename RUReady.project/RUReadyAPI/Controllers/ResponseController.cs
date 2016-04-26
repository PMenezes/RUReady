using AutoMapper;
using DTOs;
using RUReadyAPI.Models;
using Services.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace RUReadyAPI.Controllers
{
    public class ResponseController : ApiController
    {
        #region Variables

        Service service = new Service();

        MapperConfiguration config = new MapperConfiguration(cfg =>
            cfg.CreateMap<Response, ResponseDTO>());

        #endregion

        // GET: api/Response
        public IEnumerable<Response> Get()
        {
            IMapper mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<Response>>(service.GetAllResponses(new UserDTO()));
        }

        // GET: api/Response/5
        public IHttpActionResult Get(Guid id)
        {
            if (id == null) return BadRequest("Response ID must be defined");

            IMapper mapper = config.CreateMapper();
            ResponseDTO responseDTO = service.Get(new ResponseDTO { Key = id });
            
            return Ok(mapper.Map<Response>(responseDTO));
        }

        // POST: api/Response
        public IHttpActionResult Post(Response item)
        {
            if (item == null) return BadRequest("Response must be defined");
            IMapper mapper = config.CreateMapper();
            
            ResponseDTO responseDTO = service.Insert(mapper.Map<ResponseDTO>(item));

            if(responseDTO == null) return InternalServerError();
            return Ok(mapper.Map<Response>(responseDTO));
        }

        // DELETE: api/Response/5
        public IHttpActionResult Delete(Guid id)
        {
            if (id == null) return BadRequest("Response ID must be defined");
            IMapper mapper = config.CreateMapper();

            bool res = service.Delete(new ResponseDTO { Key = id });

            if (res) return Ok();
            else return InternalServerError();
        }
    }
}
