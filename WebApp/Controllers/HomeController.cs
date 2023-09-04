using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        List<Plant> plants = new List<Plant>
        {
            new Plant(1, "Ромашка", "Рома́шка (лат. Matricária) — род однолетних цветковых растений семейства астровые, или сложноцветные (Asteraceae), по современной классификации объединяет около 70 видов невысоких пахучих трав, цветущих с первого года жизни. Наиболее известный вид — Ромашка аптечная (Matricaria chamomilla, syn. Matricaria recutita), это растение широко используется в лечебных и косметических целях.", "https://upload.wikimedia.org/wikipedia/commons/thumb/8/87/Chamomile_Flowers_-_Flickr_-_Swallowtail_Garden_Seeds.jpg/413px-Chamomile_Flowers_-_Flickr_-_Swallowtail_Garden_Seeds.jpg"),
            new Plant(2, "Роза", "Ро́за — собирательное название видов и сортов представителей рода Шипо́вник (лат. Rósa), выращиваемых человеком и растущих в дикой природе. Бо́льшая часть сортов роз получена в результате длительной селекции путём многократных повторных скрещиваний и отбора. Некоторые сорта являются формами дикорастущих видов.", "https://upload.wikimedia.org/wikipedia/commons/thumb/b/be/A_rose_flower.jpg/330px-A_rose_flower.jpg"),
            new Plant(3, "Тюльпан", "Тюльпа́н (лат. Túlipa) — род многолетних травянистых луковичных растений семейства Лилейные (Liliaceae), в современных систематиках включающий более 80 видов. Центр происхождения и наибольшего разнообразия видов тюльпанов — горы северного Ирана, Памиро-Алай и Тянь-Шань. За 10—15 миллионов лет эволюции тюльпаны расселились до Испании и Марокко на западе, до Забайкалья на востоке и до Синайского полуострова на юге. На севере интродуцированные человеком популяции тюльпана лесного достигли Шотландии и южного побережья Скандинавии.", "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d7/5_Tulpen_in_der_Mittagssonne.JPG/413px-5_Tulpen_in_der_Mittagssonne.JPG")
        };
        public IActionResult Index() => View(plants);

        public IActionResult About() => View();
    }
}
