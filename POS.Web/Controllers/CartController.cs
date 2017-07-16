using AutoMapper;
using POS.Domain.Interfaces.Services;
using POS.Infra.Cross.IoC;
using POS.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace POS.Web.Controllers
{
    public class CartController : BaseController
    {
        // GET: Cart
        public ActionResult Index()
        {
            var cartViewModel = GetCart();

            return View(cartViewModel);
        }

        // POST: Cart/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(int id, int quantity = 1)
        {
            if (ModelState.IsValid)
            {
                var cart = GetCart();

                var productAlreadyOnCart = cart.Items.Any(i => i.Product.ID.Equals(id));

                if (productAlreadyOnCart)
                {
                    var cartItem = cart.Items.First(i => i.Product.ID.Equals(id));
                    cartItem.Quantity += quantity;
                }
                else
                {
                    AddNewItemToCart(id, cart, quantity);
                }

                SetCart(cart);
            }

            return RedirectToAction("Index");
        }


        // POST: Cart/Remove
        [HttpPost]
        public ActionResult Remove(int id)
        {
            var cart = GetCart();

            var productOnCart = cart.Items.Any(i => i.Product.ID.Equals(id));

            if (productOnCart)
            {
                var cartItem = cart.Items.First(i => i.Product.ID.Equals(id));
                cart.Items.Remove(cartItem);
                SetCart(cart);
            }

            return PartialView("Cart", cart);
        }

        // POST: Cart/Clear
        [HttpPost]
        public ActionResult Clear()
        {
            CartViewModel cart = ClearCartCookie();
            return PartialView("Cart", cart);
        }

        // GET: Cart/Checkout
        public ActionResult Checkout()
        {
            var paymentMethodService = DIContainer.container.GetInstance<IPaymentMethodService>();
            var paymentMethods = paymentMethodService.GetAllActive();
            var mappedPaymentMethods = Mapper.Map<List<PaymentMethodViewModel>>(paymentMethods);

            var checkoutViewModel = new CheckoutViewModel
            {
                Cart = GetCart(),
                PaymentMethods = mappedPaymentMethods
            };

            return View(checkoutViewModel);
        }

        // GET: Cart/Checkout
        public ActionResult Submitted()
        {
            ClearCartCookie();
            ViewBag.CartQuantity = 0;

            return View();
        }

        private void AddNewItemToCart(int id, CartViewModel cart, int quantity)
        {
            var productService = DIContainer.container.GetInstance<IProductService>();
            var product = productService.GetById(id);
            var mappedProduct = Mapper.Map<ProductViewModel>(product);
            var cartItem = new CartItemViewModel
            {
                Product = mappedProduct,
                Quantity = quantity,
            };
            cart.Items.Add(cartItem);
        }

        private CartViewModel ClearCartCookie()
        {
            var cart = new CartViewModel();
            cart.Items = new List<CartItemViewModel>();
            SetCart(cart);
            return cart;
        }
    }
}