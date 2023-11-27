using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.UtilityControllers;
using WebApplication1.Context;

namespace WebApplication1.Controllers
{
	public class TestController : Controller
	{
		QuestionContext _context;
		PlantContext _plantContext;

        public IActionResult Index(int id = 1)
		{
			GetHttpContext();

			return View(QuestionList._questions[id - 1]);
		}

		public IActionResult Result(int Answer, int Id)
		{
			GetHttpContext();

			QuestionStack.AddTransitionNode(Id);

            if (QuestionList._questions[Id-1].IsDefinding)
            {
                AddToSearchString(Id);
            }

            if (Answer == 1)
			{
				Id = QuestionList._questions[Id - 1].IfTrue;
			}
			else if(Answer == 2)
			{
				Id = QuestionList._questions[Id - 1].IfFalse;
			}

			if(Id > 0)
			{
                return RedirectToAction("Index", new { id = Id });
            }
			else
			{
                return RedirectToAction("End");
            }
			
		}

		public IActionResult End()
		{
			GetPlantHttpContext();

			PlantList.Fill(_plantContext.GetPlantsBySearchResult(SearchStringBuilder.BuildSearchString()));

			if(PlantList.GetPlants().Count() == 0)
			{
				ViewBag.Empty = "Такого растения нет в базе";
			}

            return View(PlantList.GetPlants());
		}

		public IActionResult Back()
		{
			return RedirectToAction("Index", new { id = QuestionStack.GetLastNode() });
		}

		private void GetHttpContext()
		{
            _context ??= HttpContext.RequestServices.GetService(typeof(WebApplication1.Context.QuestionContext)) as QuestionContext;
        }

		private void GetPlantHttpContext()
		{
			_plantContext ??= (HttpContext.RequestServices.GetService(typeof(PlantContext)) as PlantContext);
        }

		private void AddToSearchString(int id)
		{
			SearchStringBuilder.SetLiveForm(QuestionList._questions[id - 1].LiveFormID);
			SearchStringBuilder.SetLeafModification(QuestionList._questions[id - 1].LeafModificationID);
			SearchStringBuilder.SetLeafStructure(QuestionList._questions[id - 1].LeafStructureID);
			SearchStringBuilder.SetLeafArangement(QuestionList._questions[id - 1].LeafArangementID);
		}

        public IActionResult Details(int id)
        {
            return PartialView("Details", PlantList.GetPlants()[id-1]);
        }
    }
}