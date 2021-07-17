using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArticleApp.API.Data;
using ArticleApp.API.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;

namespace ArticleApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Article2Controller : ControllerBase
    {
        private readonly ILogger<Article2Controller> _logger;
        private readonly IMemoryCache _cache;
        private readonly BaseDbContext _context;
        

        public Article2Controller(ILogger<Article2Controller> logger, IMemoryCache cache, BaseDbContext context)
        {
            _logger = logger;
            _cache = cache;
            _context = context;
        }

        // GET: api/Article
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cacheKey = "Get_All_Acticles";

            if (_cache.TryGetValue(cacheKey, out List<Article> Articles))
            {
                return Ok(Articles);
            }

            Articles = await _context.Articles.ToListAsync();

            var cacheOptions = new MemoryCacheEntryOptions()
            {
                // 자주 호출되지 않는 Cache 삭제 기준 시간
                SlidingExpiration = TimeSpan.FromMinutes(2),
                // 강제 DBMS 호출 기준 시간
                AbsoluteExpiration = DateTime.Now.AddMinutes(10)
            };

            _cache.Set(cacheKey, Articles, cacheOptions);

            return Ok(Articles);
        }
    }
}
