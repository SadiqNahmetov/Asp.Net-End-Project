using AspNetCoreEndProject.Data;
using AspNetCoreEndProject.Models;
using AspNetCoreEndProject.Services;
using AspNetCoreEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly LayoutService _layoutService;
        private readonly AppDbContext _context;

        public FooterViewComponent(LayoutService layoutService, AppDbContext context)
        {
            _layoutService = layoutService;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Dictionary<string, string> setting = await _layoutService.GetDatasFromSetting();
            IEnumerable<Category> categories = await _layoutService.GetDatasFromCategory();

            List<BasketDetailVM> basketDetailsList = new List<BasketDetailVM>();


            if (Request.Cookies["basket"] != null)
            {
                List<BasketVM> basketItems = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);

                List<BasketDetailVM> basketDetail = new List<BasketDetailVM>();

                foreach (var item in basketItems)
                {
                    Product product = await _context.Products
                        .Where(m => m.Id == item.Id && m.isDeleted == false)
                        .Include(m => m.ProductImage).FirstOrDefaultAsync();


                    BasketDetailVM newBasket = new BasketDetailVM
                    {
                        Id = product.Id,
                        Title = product.Title,
                        Image = product.ProductImage.Where(m => m.IsMain).FirstOrDefault().Image,
                        Price = product.Price,
                        Count = item.Count,
                        DiscountPrice = product.DiscountPrice,
                        Total = (product.Price - ((product.Price / 100) * product.DiscountPrice)) * item.Count
                    };

                    basketDetail.Add(newBasket);
                }
                FooterVM footerVM = new FooterVM
                {
                    BasketDetail = basketDetail,
                    Categories = categories,
                    Settings = setting

                };
                return await Task.FromResult(View(footerVM));
            }
            else
            {
                FooterVM footerVM = new FooterVM
                {
                    BasketDetail = basketDetailsList,
                    Categories = categories,
                    Settings = setting

                };
                return await Task.FromResult(View(footerVM));
            }
        }
    }
}
