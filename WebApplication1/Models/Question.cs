namespace WebApplication1.Models
{
	public class Question
	{
		public int Id { get; set; }
		public string? QuestionText { get; set; }
		public string? ImageLink1 { get; set; }
		public string? ImageLink2 { get; set; }
		public int IfTrue { get; set; }
		public int IfFalse { get; set; }
		public bool IsDefinding { get; set; }
		public int LiveFormID { get; set; }
		public int LeafModificationID { get; set; }
		public int LeafStructureID { get; set; }
		public int LeafArangementID { get; set; }
	}
}