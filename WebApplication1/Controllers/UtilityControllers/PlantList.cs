using WebApplication1.Models;

namespace WebApplication1.Controllers.UtilityControllers
{
    public class PlantList
    {
        private static List<Plant>? _plants;

        public static void Init()
        {
            _plants = new List<Plant>();
        }

        public static void Fill(List<Plant> newList)
        {
            _plants = null;
            _plants = newList;
        }

        public static List<Plant> GetPlants() => _plants;
    }
}
