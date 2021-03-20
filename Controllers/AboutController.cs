using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using veic_web.Models;
using veic_web.Models.Repositories;
using veic_web.Models.Wraps;

namespace veic_web.Controllers
{
    public class AboutController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleRepository _article;
        private readonly IImageRepository _image;
        private readonly IQualificationRepository _qualification;

        public AboutController(ILogger<HomeController> logger,
            IArticleRepository repoArticle,
            IImageRepository repoImage,
            IQualificationRepository repoQualification)
        {
            _logger = logger;
            _article = repoArticle;
            _image = repoImage;
            _qualification = repoQualification;
        }

        /**
         * 
         * https://codedocu.com/Net-Framework/ASP_dot_Net-Core/Data-Model/Data-Errors/
         * InvalidOperationException_colon_-The-model-item-passed-into-the-ViewDataDictionary-_dot__dot_requires-System_dot_Collections_dot_Generic_dot_IEnumerable?2224
         */
        private List<ExhibitDto> _getExhibits(int flag = 1)
        {
            List<ExhibitDto> exhibitDtos = new List<ExhibitDto>();

            var quals = from qual in _qualification.Qualifications
                             join imge1 in _image.Images on qual.Img_id equals imge1.Id
                             where (qual.Lang_id.Equals(4136)) && (qual.Flag.Equals(flag))
                             orderby (qual.Id)
                             select new
                             {
                                 Id = qual.Id,
                                 Name = qual.Name,
                                 ImgName = imge1.Name
                             };

            foreach (var item in quals)
            {
                ExhibitDto dto = new ExhibitDto();
                dto.Id = item.Id;
                dto.Name = item.Name;
                dto.ImgName = item.ImgName;

                exhibitDtos.Add(dto);
            }

            return exhibitDtos;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("About/profile")]
        public IActionResult GetProfile()
        {
            var article = from art in _article.Articles
                          where (art.Lang_id.Equals(4136)) && (art.Type_id.Equals(1003))
                          orderby (art.Pubdate)
                          select art;

            return View("Profile", article);
        }

        [HttpGet]
        [Route("About/innovations")]
        public IActionResult GetInnovations()
        {
            List<ExhibitDto> exhibitDtos = _getExhibits(1);

            return View("Qualifications", exhibitDtos);
        }

        [HttpGet]
        [Route("About/qualifications")]
        public IActionResult GetQualifications()
        {
            List<ExhibitDto> exhibitDtos = _getExhibits(0);

            return View("Qualifications", exhibitDtos);
        }
    }

}
