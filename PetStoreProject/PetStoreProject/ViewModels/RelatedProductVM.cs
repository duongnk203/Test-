using PetStoreProject.Models;

namespace PetStoreProject.ViewModels
{
	public class RelatedProductVM
	{
		public int ProductId { get; set; }
		public string Name { get; set; }
		public float Price { get; set; }
		public List<Image> images { get; set; }
		public string brand { get; set; }
	}
}
