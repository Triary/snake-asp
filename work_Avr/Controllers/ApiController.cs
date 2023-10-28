using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using SnakeProj.game;
using SnakeProj.Models.Api;

namespace SnakeProj.Controllers
{
    public class ApiController : Controller
    {
        private readonly Game _game;
        public ApiController(Game game)
        {
            _game = game;
        }

        //GET
        public IActionResult GetField()
        {

            var dataModel = new SnakeFieldDataModel(_game);
            return PartialView("/Views/PageParts/SnakeTable.cshtml", dataModel);

        }

        //GET
        public IActionResult GetStatus()
        {
            var dataModel = new SnakeStatusDataModel(_game);
            return PartialView("/Views/PageParts/SnakeStatus.cshtml", dataModel);
        }

        //GET
        public SnakeStatusDataModel GetSnakeStatusDataModel()
        {
            return new SnakeStatusDataModel(_game);
        }


        public void GoUp()
        {
            _game.Snake.Speed = new Point(0, -1);
        }

        public void GoDown()
        {
            _game.Snake.Speed = new Point(0, +1);
        }

        public void GoLeft()
        {
            _game.Snake.Speed = new Point(-1, 0);
        }

        public void GoRigth()
        {
            _game.Snake.Speed = new Point(+1, 0);
        }

    }
}
