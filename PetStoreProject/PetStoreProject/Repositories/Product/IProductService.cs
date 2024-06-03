using PetStoreProject.ViewModels;
using PetStoreProject.Models;

namespace PetStoreProject.Repositories.Product
{
	public interface IProductService
	{
		public ProductDetailVM GetDetail(int productId);
		public List<RelatedProductVM> getRelatedProduct(int productId);

		//public List<ProductDetailVM> GetAllAccessariesDetail();

		//public List<ProductDetailVM> GetAllFoodsDetail();
	}
}
