using Microsoft.AspNetCore.Mvc;
using SnakeProj.game;
using SnakeProj.Models.Api;

namespace SnakeProj.Controllers
{
    public class GAMEcontroller : Controller
    {
        private readonly Game _game;
        public GAMEcontroller(Game game)
        {
            _game = game;
        }


        public IActionResult Index()
        {
            var dataModel = new SnakeFieldDataModel(_game);
            return View(_game);
        }

    }
}
