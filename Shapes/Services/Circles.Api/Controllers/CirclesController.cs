using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Circles.Models;
using Microsoft.AspNetCore.Mvc;

namespace Circles.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CirclesController : ControllerBase
    {
        private readonly CircleContext context;
        public CirclesController(CircleContext context)
        {
            this.context = context;
        }
        // GET api/Circles
        [HttpGet]
        public ActionResult<List<Circle>> Get()
        {
            return context.Circles.ToList();
        }

        // GET api/Circles/5
        [HttpGet("{id}")]
        public ActionResult<Circle> Get(int id)
        {
           var item = this.context.Circles.Find(id);
           if (item==null) return NotFound();
           return item; 
        }
        string[] colorSet = new[] {"#f25022","#7fba00","#01a4ef","#ffb901"};
        Random random = new Random();
        [HttpGet("New")]
        [ProducesResponseType(400)]
        public ActionResult<Circle> GetNewCircle([FromQuery]int? maxRadius)
        {
            if (maxRadius == null)
            return BadRequest("Resend request with max radius. For e.g. /Circles/New?maxRadius=100");
            
            var c = new Circle{
                Radius = random.Next(2,maxRadius.Value),
                LineWidth = random.Next(2,10),
                StrokeColor = colorSet[random.Next(0,colorSet.Count()-1)],
                FillColor = colorSet[random.Next(0,colorSet.Count()-1)],  
            };
            this.context.Circles.Add(c);
            this.context.SaveChanges();
            return c;
        }
    }
}
