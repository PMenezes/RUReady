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
        public IHttpActionResult Post(Dare item)
        {
            if (item == null) return BadRequest("Dare must be defined");
            IMapper mapper = config.CreateMapper();

            DareDTO dareDTO = service.Insert(mapper.Map<DareDTO>(item));

            if (dareDTO == null) return InternalServerError();
            return Ok(mapper.Map<Dare>(dareDTO));
        }

        // DELETE: api/Dare/5
        public IHttpActionResult Delete(Guid id)
        {
            if (id == null) return BadRequest("Dare ID must be defined");
            IMapper mapper = config.CreateMapper();

            bool res = service.Delete(new DareDTO { Key = id });

            if (res) return Ok();
            else return InternalServerError();
        }
    }
}
