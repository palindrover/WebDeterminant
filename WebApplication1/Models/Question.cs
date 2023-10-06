namespace WebApplication1.Models
{
	public record class Question (int Id, string? Text, int IfTrue,  int IfFalse, bool? Answer);
}