using MySql.Data.MySqlClient;
using WebApplication1.Models;
using System.Data;
using System.Linq;

namespace WebApplication1.Context
{
	public class PlantContext : BaseContext
	{
		private List<Plant> _list;

		public PlantContext(string connectionString) : base(connectionString) { }

		public List<Plant> GetPlantsBySearchResult(string searchString)
		{
			CheckPlantListIsClear();
			MySQGetResult(searchString);
			return _list;
		}

		private void CheckPlantListIsClear() 
		{
			if(_list == null) _list = new List<Plant>();
			else _list.Clear();
		}

		public List<Plant> GetAllPlants()
		{
			CheckPlantListIsClear();
			MySQGetResult("SELECT vidy.id, vidy.vid, vidy.onlatin, vidy.description, vidy.imagelink, vidy.finder, vidy.liveformid, vidy.leafmodificationid, vidy.leafstructureid, vidy.leafarrangementid, genues.genus, genues.genusonlatin, families.family, families.familiesonlatin, classes.class, classes.classesonlatin, phylus.phylus, phylus.phylusonlatin FROM (phylus INNER JOIN ((classes INNER JOIN families ON classes.id = families.classid) INNER JOIN genues ON families.id = genues.familyid) ON phylus.id = classes.phylusid) INNER JOIN vidy ON genues.id = vidy.genusid");

			return _list;		
		}

		private void MySQGetResult(string comand)
		{
			using (MySqlConnection conn = GetConnection())
			{
				conn.Open();
				var cmd = new MySqlCommand(comand, conn);
				using MySqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					_list.Add(new Plant()
					{
						Id = _sd.SafeGetNumericData(reader, "id"),
						Name = _sd.SafeGetStringData(reader, "vid"),
						LatinName = _sd.SafeGetStringData(reader, "onlatin"),
						Description = _sd.SafeGetStringData(reader, "description"),
						ImageURL = _sd.SafeGetStringData(reader, "imagelink"),
						Finder = _sd.SafeGetStringData(reader, "finder"),
						LiveFormID = _sd.SafeGetNumericData(reader, "liveformid"),
						LeafModificationID = _sd.SafeGetNumericData(reader, "leafmodificationid"),
						LeafStructureID = _sd.SafeGetNumericData(reader, "leafstructureid"),
						LeafArrangmentID = _sd.SafeGetNumericData(reader, "leafarrangementid"),

						//inner joined
						Genus = _sd.SafeGetStringData(reader, "genus"),
						GenusLatin = _sd.SafeGetStringData(reader, "genusonlatin"),

						Family = _sd.SafeGetStringData(reader, "family"),
						FamilyLatin = _sd.SafeGetStringData(reader, "familiesonlatin"),

						Class = _sd.SafeGetStringData(reader, "class"),
						ClassLatin = _sd.SafeGetStringData(reader, "classesonlatin"),

						Phylus = _sd.SafeGetStringData(reader, "phylus"),
						PhylusLatin = _sd.SafeGetStringData(reader, "phylusonlatin"),

					});
				}
			}
		}

		public List<Plant> UpdatePlantsList()
		{
			_list.Clear();
			return GetAllPlants();
		}

		public Plant GetPlantsByID(int id)
		{
			if (_list == null) GetAllPlants();
			return _list.Find(element => element.Id == id);
		}

		public List<Plant> GetPlantsBySearchString(string searchString)
		{
			if (searchString == null) return null;
			var comparableLettersSearchString = GetComparableLettersSearchString(searchString);
			CheckPlantListIsClear();
			GetAllPlants();
			var _searchResult = new List<Plant>();
			_searchResult.AddRange(_list.Where(plant => plant.Name.ToLower().Contains(searchString.ToLower()) || plant.LatinName.ToLower().Contains(searchString.ToLower()) || plant.Name.ToLower().Contains(comparableLettersSearchString)));
			return (_searchResult);
		}

		private string GetComparableLettersSearchString(string searchString)
		{
			var temp = searchString.ToLower();
			if (temp.Contains('ё'))
			{
				return temp.Replace('ё', 'е');
			}
			return "none";
		}
	}
}