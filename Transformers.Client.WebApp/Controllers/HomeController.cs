using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transformers.Services;

namespace Transformers.Client.WebApp.Controllers {
    public class HomeController : Controller
    {
        private IGameService gameService;

        public HomeController()
        {
            this.gameService = new GameService();
        }

        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Index(List<string> transformers)
        {
            try {
                var transformerModels = transformers.Where(x => !string.IsNullOrEmpty(x)).Select(GetTransformer).ToList();
                var score = gameService.ComputeScore(transformerModels);
                score.Winners = string.Join(",", transformerModels.Where(x => x.Type == score.WinningTeam).Select(x => x.Name));

                return View(score);
            } catch (Exception ex)
            {
                ViewData["Errors"] = "Something went wrong when trying to compute the game score; please check your inputs and try again!";
                return View();
            }
        }

        private static Transformer GetTransformer(string value)
        {
            var tokens = value.Split(',').Select(x=>x.Trim()).ToList();  
            var transformer = new Transformer
            {
                Name = tokens[0],
                Type = tokens[1]=="D"?TransformerType.Decepticon:TransformerType.Autobot,
                Strength = int.Parse(tokens[2]),
                Intelligence = int.Parse(tokens[3]),
                Speed = int.Parse(tokens[4]),
                Endurance = int.Parse(tokens[5]),
                Rank = int.Parse(tokens[6]),
                Courage = int.Parse(tokens[7]),
                Firepower = int.Parse(tokens[8]),
                Skill = int.Parse(tokens[9])
            };
            return transformer;
        } 
    }
}