using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using veic_web.Models.Repositories;

namespace veic_web.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactRepository _contact;

        public ContactController(ILogger<ContactController> logger,
            IContactRepository repoContact)
        {
            _logger = logger;
            _contact = repoContact;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Contact/{strName}")]
        public IActionResult GetDept(String strName)
        {
            //int startIndex = strName.IndexOf("-");
            //int endIndex = strName.Length;
            //String deptName = strName.Substring(startIndex + 1).Trim();

            var contactus = from contus in _contact.Contacts
                          where (contus.Lang_id.Equals(4136)) && (contus.Name.Contains(strName))
                          select contus;
            foreach (var item in contactus)
            {
                ViewData["displayName"] = item.DisplayName;
                ViewData["tel"] = item.Tel;
                ViewData["fax"] = item.Fax;
                ViewData["email"] = item.Email;
            }

            return View("Contactus");
        }
    }
}
