using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using veic_web.Models;
using veic_web.Models.Wraps;

namespace veic_web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleRepository _article;

        public ArticleController(IArticleRepository repository)
        {
            _article = repository;
        }

        [HttpGet]
        [Route("Article/View/{articleId}")]
        public IActionResult View(int? articleId)
        {
            var article = from art in _article.Articles
                          where (art.Lang_id.Equals(4136)) && (art.Id.Equals(articleId))
                          select art;
            foreach (var item in article)
            {
                ViewData["title"] = item.Title;
                ViewData["body"] = item.Body;
            }
            
            return View("Index");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Company/{strNewType}")]
        public async Task<IActionResult> Articles(int? pageNumber, string strNewType)
        {
            int iNewType = 0;
            if (strNewType.Equals("notice"))
                iNewType = 1002;
            else
                iNewType = 1001;

            var article = from art in _article.Articles
                          where(art.Lang_id.Equals(4136)) && (art.Type_id.Equals(iNewType))
                          orderby(art.Pubdate)
                          select art;

            int pageSize = 12;
            return View(await PaginatedList<Article>.CreateAsync(article.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
    }
}
