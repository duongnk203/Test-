using PetStoreProject.Models;
using Attribute = PetStoreProject.Models.Attribute;

namespace PetStoreProject.ViewModels
{
	public class ProductOptionVM
	{
		public int Id { get; set; }
		public Attribute attribute { get; set; }
		public Size size { get; set; }
		public float price { get; set; }
		public string? img_url { get; set; }
	}
}
