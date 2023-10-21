using System.ComponentModel.DataAnnotations;
using WebApplication1.Context;

namespace WebApplication1.Models
{
	public class Plant
	{
		private PlantContext context;

		[Key]
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? LatinName { get; set; }
		public string? ImageURL { get; set; }
		public string? Finder { get; set; }
		public string? Description { get; set; }
		public int LiveFormID { get; set; }
		public int LeafModificationID { get; set; }
		public int LeafStructureID { get; set; }
		public int LeafArrangmentID { get; set; }


		public string? Genus { get; set; }
		public string? GenusLatin { get; set; }
		public string? Family { get; set; }
		public string? FamilyLatin { get; set; }
		public string? Class { get; set; }
		public string? ClassLatin { get; set; }
		public string? Phylus { get; set; }
		public string? PhylusLatin { get; set; }
	}
}
