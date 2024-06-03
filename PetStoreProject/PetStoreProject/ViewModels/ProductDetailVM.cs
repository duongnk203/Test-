using PetStoreProject.Models;
using Attribute = PetStoreProject.Models.Attribute;

namespace PetStoreProject.ViewModels
{
	public class ProductDetailVM
	{
		public int ProductId { get; set; }
		public string Name { get; set; }
		public string Brand { get; set; }
		public string Description { get; set; }
		public List<ProductOptionVM> productOption { get; set; }
		public List<Image> images { get; set; }
		public List<Attribute>? attributes { get; set; }
		public List<Size>? sizes { get; set; }
	}
}
