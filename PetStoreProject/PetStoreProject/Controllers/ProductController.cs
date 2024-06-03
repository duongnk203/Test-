using Microsoft.AspNetCore.Mvc;
using PetStoreProject.Repositories.Product;

namespace PetStoreProject.Controllers
{
	[Route("[controller]/[action]")]
	public class ProductController : Controller
	{
		private readonly IProductService _product;

		public ProductController(IProductService product)
		{
			_product = product;
		}

		public ActionResult ProductAccessaries(int? pageNumber)
		{

			return View();
		}

		[HttpGet("{productId}")]
		public ActionResult Detail(int productId)
		{
			var product_detail = _product.GetDetail(productId);
			ViewData["product_detail"] = product_detail;
			ViewData["related_products"] = _product.getRelatedProduct(productId);
			return View();
		}

		[HttpPost]
		public ActionResult quickPreview(int productId)
		{
			var product_detail = _product.GetDetail(productId);
			return Json(product_detail);
		}


	}
}
