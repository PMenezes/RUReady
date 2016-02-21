using AutoMapper;
using DTOs;
using RUReadyAPI.Models;
using Services.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace RUReadyAPI.Controllers
{
    public class DareController : ApiController
    {
        #region Variables

        Service service = new Service();

        MapperConfiguration config = new MapperConfiguration(cfg =>
            cfg.CreateMap<Dare, DareDTO>());

        #endregion

        // GET: api/Dare
        public IEnumerable<Dare> Get()
        {
            IMapper mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<Dare>>(service.GetAllDares(new UserDTO()));    
        }

        // GET: api/Dare/5
        public IHttpActionResult Get(Guid id)
        {
            if (id == null) return BadRequest("Dare ID must be defined");

            IMapper mapper = config.CreateMapper();
            DareDTO dareDTO = service.Get(new DareDTO { Key = id });
            
            return Ok(mapper.Map<Dare>(dareDTO));
        }

        // POST: api/Dare
        public IHttpActionResult Post([FromBody]string value)
        {
            return InternalServerError();
        }

        // PUT: api/Dare/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return InternalServerError();
        }

        // DELETE: api/Dare/5
        public IHttpActionResult Delete(int id)
        {
            return InternalServerError();
        }
    }
}
