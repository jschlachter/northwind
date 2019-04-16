using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Api.Services;
using Northwind.Api.ViewModels;

namespace Northwind.Api.Controllers
{
    public class ProductsController:BaseApiController
    {
        IProductViewModelService _productViewModelService;


        public ProductsController(IProductViewModelService productViewModelService) => _productViewModelService = productViewModelService;

        public async Task<ActionResult<ProductIndexViewModel>> List(int pageSize, int pageNumber)
        {
            var productModel = await _productViewModelService.GetProducts(pageSize, pageNumber);
            return Ok(productModel);
        }
    }
}
