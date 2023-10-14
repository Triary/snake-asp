using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using work_Avr.game;
using work_Avr.Models.Api;

namespace work_Avr.Controllers
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
