using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Squares.Models;

namespace Squares.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SquaresController : ControllerBase
    {
        readonly string[] colorSet = new[] {"#f25022","#7fba00","#01a4ef","#ffb901"};
        // GET api/squares
        [HttpGet]
        [ProducesResponseType(400)]
        public ActionResult<List<Square>> Get([FromQuery]int? maxLength)
        {
            if (maxLength == null)
            return BadRequest("Resend request with max Length. For e.g. /Squares?maxLength=100");

            var squares = new List<Square>();
             for(var i=0;i<4;i++)
                {
                    squares.Add(
                        new Square{
                            Length = maxLength.Value,
                            FillColor = colorSet[i],
                            LineWidth = 2,
                            StrokeColor = "#FFFFFF"
                        }
                    );
                }
            return squares;
        }
    }
}
