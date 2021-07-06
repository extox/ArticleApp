using System.Linq;
using ArticleApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ArticleApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly ILogger<ArticleController> _logger;

        private readonly BaseDbContext _context;
        public ArticleController(ILogger<ArticleController> logger, BaseDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult GetArticles()
        {
            return Ok(_context.Articles.ToList());
        }
    }
}