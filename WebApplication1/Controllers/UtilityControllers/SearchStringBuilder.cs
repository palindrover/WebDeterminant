namespace WebApplication1.Controllers.UtilityControllers
{
	public class SearchStringBuilder
	{
		private const string c_startString = "SELECT vidy.id, vidy.vid, vidy.onlatin, vidy.description, vidy.imagelink, vidy.finder, classes.class, classes.classesonlatin, families.family, families.familiesonlatin, genues.genus, genues.genusonlatin, vidy.liveformid, vidy.leafmodificationid, vidy.leafstructureid, vidy.leafarrangementid, phylus.phylus, phylus.phylusonlatin FROM (phylus INNER JOIN ((classes INNER JOIN families ON classes.id = families.classid) INNER JOIN genues ON families.id = genues.familyid) ON phylus.id = classes.phylusid) INNER JOIN vidy ON genues.id = vidy.genusid WHERE (";
		private static string _searchString = string.Empty;

		private static int _currentLiveFormID;
		private static int _currentLeafModificationID;
		private static int _currentLeafStructureID;
		private static int _currentLeafArangementID;

		private static Dictionary<string, int> _searchIDs;
		private static bool[] _flags;

		public static void Init()
		{
			_searchIDs = new Dictionary<string, int>
			{
                { "leafarrangementid", 0 },
				{ "leafstructureid", 0 },
				{ "leafmodificationid", 0 },
				{ "liveformid", 0 }
			};

			_flags = new bool[_searchIDs.Count];
		}
		public static void SetLiveForm(int id) => _searchIDs["liveformid"] = id;
		public static void SetLeafModification(int id) => _searchIDs["leafmodificationid"] = id;
		public static void SetLeafStructure(int id) => _searchIDs["leafstructureid"] = id;
		public static void SetLeafArangement(int id) => _searchIDs["leafarrangementid"] = id;
		public static string BuildSearchString()
		{
			CheckBeforeBuild();

			_searchString = c_startString;

			int trueFlagsCount = 0;
			foreach (var i in _flags)
				if (i == true) trueFlagsCount++;

			for (var i = 0; i < _searchIDs.Count; i++)
			{
				if (_flags[i] == true)
				{
					_searchString += $"((vidy.{_searchIDs.ElementAt(i).Key})={_searchIDs.ElementAt(i).Value})";

					if (trueFlagsCount > 1)
						_searchString += " AND ";
					trueFlagsCount--;
				}
			}
			_searchString += ")";
			ClearSearchIDs();
			return _searchString;
		}

		private static void ClearSearchIDs()
		{
			foreach (var i in _searchIDs.Keys)
			{
				_searchIDs[i] = 0;
			}
		}

		private static void CheckBeforeBuild()
		{

			for (var i = 0; i < _searchIDs.Count; i++)
			{
				_flags[i] = false;
				if (_searchIDs.ElementAt(i).Value > 0) _flags[i] = true;
			}
		}

		public static string GetRecentSearchString() => _searchString;
	}
}