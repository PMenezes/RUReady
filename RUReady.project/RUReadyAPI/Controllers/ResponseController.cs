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
        public IHttpActionResult Post([FromBody]string value)
        {
            return InternalServerError();
        }

        // PUT: api/Response/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return InternalServerError();
        }

        // DELETE: api/Response/5
        public IHttpActionResult Delete(int id)
        {
            return InternalServerError();
        }
    }
}
