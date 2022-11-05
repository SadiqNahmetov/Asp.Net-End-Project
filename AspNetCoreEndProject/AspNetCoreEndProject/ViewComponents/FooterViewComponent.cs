using AspNetCoreEndProject.Models;
using AspNetCoreEndProject.Services;
using AspNetCoreEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly LayoutService _layoutService;

        public FooterViewComponent(LayoutService layoutService)
        {
            _layoutService = layoutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Dictionary<string, string> setting = await _layoutService.GetDatasFromSetting();
            IEnumerable<Category> categories = await _layoutService.GetDatasFromCategory();


            FooterVM footerVM = new FooterVM
            { 
                Categories = categories,
                Settings = setting
                
            };


            return await Task.FromResult(View(footerVM));
        }
    }
}
