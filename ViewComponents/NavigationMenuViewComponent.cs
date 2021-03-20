using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using veic_web.Models;

namespace veic_web.ViewComponents
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly INavigationRepository repository;

        public NavigationMenuViewComponent(INavigationRepository rep)
        {
            repository = rep;
        }

        private List<Navigation> GetMenu(int langId = 6134)
        {
            #region menu1level
            /*
            var menu1 = repository.Navigations.Where(lang => lang.Lang_id.Equals(langId))
                .Where(parent => parent.Parent_id.Equals(0))
                .OrderBy(order => order.Order1);
            */
            /*
            var menu2 = repository.Navigations.Where(lang => lang.Lang_id.Equals(langId))
                .Where(parent => !parent.Parent_id.Equals(0))
                .OrderBy(order => order.Order1).ToList();
            */
            #endregion
            var menus = repository.Navigations.Where(lang => lang.Lang_id.Equals(langId))
                .OrderBy(order => order.Order1);

            return menus.ToList();
        }

        public IViewComponentResult Invoke()
        {
            return View(GetMenu(4136));
        }
    }
}
