using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using veic_web.Models;
using veic_web.Models.Wraps;

namespace veic_web.ViewComponents
{
    public class BreadcrumbViewComponent : ViewComponent
    {
        private readonly INavigationRepository repository;

        public BreadcrumbViewComponent(INavigationRepository rep)
        {
            repository = rep;
        }

        private List<NavMenuDto> GetBreadcrumb(string strName, int langId = 6134)
        {
            int parentId = 0;
            string strMenuName = "";
            string strLink = "";
            string prefixLink = "https://localhost:44362";

            List<NavMenuDto> navMenuDtos = new List<NavMenuDto>();
   
            var menus = repository.Navigations
                .Where(lang => lang.Lang_id.Equals(langId))
                .Where(name => name.Name.Equals(strName))
                .OrderBy(order => order.Order1);

            foreach (var item in menus)
            {
                strMenuName = item.Name;
                strLink = item.LinkAddr;

                parentId = item.Parent_id;
            }

            var parentMenus = repository.Navigations
                .Where(lang => lang.Lang_id.Equals(langId))
                .Where(pId => pId.Id.Equals(parentId))
                .OrderBy(order => order.Order1);

            foreach (var item in parentMenus)
            {
                NavMenuDto navMenuDto = new NavMenuDto();

                navMenuDto.Name = strMenuName;

                navMenuDto.LinkAddr = prefixLink + "/" + strLink;

                navMenuDto.ParentName = item.Name;
                navMenuDto.ParentLink = prefixLink + "/home/" + item.LinkAddr;
                

                navMenuDtos.Add(navMenuDto);
            }

            return navMenuDtos;
        }

        public IViewComponentResult Invoke(string displayName)
        {
            ViewBag.displayName = displayName;
            return View(GetBreadcrumb(displayName, 4136));
        }
    }
}
