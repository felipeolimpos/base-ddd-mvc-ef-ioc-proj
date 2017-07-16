using AutoMapper;
using POS.Domain.Interfaces.Services;
using POS.Infra.Cross.DTO;
using POS.Web.ViewModels;
using System.Web.Mvc;

namespace POS.Web.Controllers
{
    public class ProductsController : EntityBaseController<IProductService, ProductDTO, ProductViewModel>
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService) : base(productService)
        {
            _productService = productService;
        }

        // GET: product/1
        public ActionResult Index(int id)
        {
            var product = _productService.GetById(id);
            var mappedProduct = Mapper.Map<ProductViewModel>(product);

            return View(mappedProduct);
        }
    }
}
