using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using veic_web.Models;
using veic_web.Models.Repositories;

namespace veic_web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _product;
        private readonly IParameterRepository _parameter;
        private readonly IImageRepository _image;

        public ProductController(ILogger<HomeController> logger,
            IProductRepository repoProduct,
            IParameterRepository repoParameter,
            IImageRepository repoImage)
        {
            _logger = logger;
            _product = repoProduct;
            _parameter = repoParameter;
            _image = repoImage;
        }

        private int _getImage(int imgId)
        {
            var images = from img in _image.Images
                        where (img.Id.Equals(imgId))
                        select new { img.Name };

            foreach (var item in images)
            {
                ViewData["imgName"] = item.Name;
            }

            return 1;
        }
        private int _getProduct(string productName)
        {
            int paramId = 0;
            int imgId = 0;
            /**
             * https://stackoverflow.com/questions/1719488/linq-where-with-and-or-condition
             */
            var products = from product in _product.Products
                             where (product.Lang_id.Equals(4136)) && (product.Name.Equals(productName))
                             select new { product.Name, product.Param_id, product.Description, product.Img_id };

            foreach (var p in products)
            {
                ViewData["productName"] = p.Name;
                ViewData["productDesc"] = p.Description;
                paramId = p.Param_id;
                imgId = p.Img_id;
            }

            _logger.LogInformation(paramId.ToString());
            var paramters = _parameter.Parameters.Where(aei => aei.Id.Equals(paramId));

            foreach (var param in paramters)
            {
                ViewData["mtbf"] = param.Mtbf;
                ViewData["voltage"] = param.Voltage;
                ViewData["electricity"] = param.Electricity;
                ViewData["ipxx"] = param.Ipxx;
                ViewData["temperature"] = param.Temperature;
            }

            _getImage(imgId);

            return 1;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Product/{productName}")]
        public IActionResult ProductAEI(string productName)
        {
            _getProduct(productName);

            return View("production_cn");
        }
    }
}
