namespace WebApplication1.Controllers.UtilityControllers
{
	public class QuestionStack
	{
		private static Stack<int> _stack;

		public static void Init()
		{
			_stack = new Stack<int>();
		}

		public static void AddTransitionNode(int node)
		{
			_stack.Push(node);
		}

		public static int GetLastNode()
		{
			if (_stack.Count < 2) return 1;
			return _stack.Pop();
		}

		public static void ClearAllNodes()
		{
			_stack?.Clear();
		}
	}
}