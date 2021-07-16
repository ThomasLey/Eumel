using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Eumel.Domse.BusinessLogic;
using Eumel.Domse.Core.Contracts;
using Eumel.Domse.Core.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Eumel.Domse.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : OperatorControllerBase<IDocumentOperator>
    {
        public DocumentController()
        {
            Operator = new DefaultDocumentOperator(null);
        }
        // GET: api/<DocumentController>
        [HttpGet]
        public IEnumerable<DocumentInformation> Get()
        {
            return Operator.GetDocumentList();
        }

        // GET api/<DocumentController>/5
        [HttpGet("{id}")]
        public DocumentInformation Get(Guid id)
        {
            return Operator.GetDocument(id);
        }

        // POST api/<DocumentController>
        [HttpPost]
        public void Post([FromBody] DocumentInformation docInfo)
        {
        }

        // PUT api/<DocumentController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] DocumentInformation docInfo)
        {
        }

        // DELETE api/<DocumentController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
