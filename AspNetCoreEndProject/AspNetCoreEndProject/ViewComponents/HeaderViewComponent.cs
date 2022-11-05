using AspNetCoreEndProject.Data;
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
    public class HeaderViewComponent : ViewComponent
    {
        private readonly LayoutService _layoutService;

        public HeaderViewComponent(LayoutService layoutService)
        {
            _layoutService = layoutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Dictionary<string, string> setting = await _layoutService.GetDatasFromSetting();
            IEnumerable<Currency> currencies = await _layoutService.GetDatasFromCurrency();
            IEnumerable<Languge> languges = await _layoutService.GetDatasFromLanguage();

            HeaderVM headerVM = new HeaderVM
            { 
                Settings = setting,
                Currencies = currencies,
                Languges = languges
            };

            return await Task.FromResult(View(headerVM));
        }
    }
}
