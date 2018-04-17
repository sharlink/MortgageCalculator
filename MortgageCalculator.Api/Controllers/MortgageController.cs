using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MortgageCalculator.Api.Filters;
using MortgageCalculator.Api.Services;
using NLog;

namespace MortgageCalculator.Api.Controllers
{

    [RoutePrefix("api/mortgage")]
    [CustomExceptionFilter]
    public class MortgageController : ApiController
    {
        private readonly IMortgageService _repository;

        public MortgageController(IMortgageService repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get list of mortgage
        /// </summary>
        /// <returns>Return list of mortgage</returns>
        /// 
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var result = _repository.GetAllMortgages();

            if (result == null)
            {
                BadRequest();
            }
            return Ok(result);
        }

        /// <summary>
        ///  Get mortgage by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return mortgage </returns>
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var result = _repository.GetAllMortgages().FirstOrDefault(x => x.MortgageId == id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
