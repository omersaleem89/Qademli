using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Qademli.AreasAPI.AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewGoalPropertyController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ViewGoalPropertyController(ApplicationDBContext context)
        {
            _context = context;
        }
        // GET: api/ViewGoalProperty
        [HttpGet("{goalId}", Name = "Get")]
        public List<dynamic> Get(int goalId)
        {
            var data = _context.GoalDetail.Where(x => x.GoalID == goalId).ToList();
            var list = new List<dynamic>();
            foreach (var a in data)
            {
                list.Add(new
                {
                    a.ID,
                    a.GoalID,
                    GoalProperty = _context.GoalProperty.Where(x => x.ID == a.GoalPropertyID).ToList(),
                    GoalPropertyValue = _context.GoalPropertyValue.Where(x => x.GoalPropertyID == a.GoalPropertyID).ToList()
                });
            }
            return list;
        }

        // GET: api/ViewGoalProperty/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/ViewGoalProperty
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ViewGoalProperty/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
