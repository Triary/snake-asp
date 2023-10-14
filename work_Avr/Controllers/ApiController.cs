using Microsoft.AspNetCore.Mvc;
using work_Avr.game;
using work_Avr.Models.Api;

namespace work_Avr.Controllers
{
    // [Route("api/[controller]")]
    //  [ApiController]
    public class ApiController : Controller
    {
        private Game _game;
        public ApiController(Game game)
        {
            _game = game;
        }

        public IActionResult GetField()
        {

            // _game.field.ChangeField();
            var dataModel = new GetFieldDataModel(_game);
            return PartialView("/Views/PageParts/SnakeTable.cshtml", dataModel);

        }

        public void GoUp()
        {
            _game.Snake.Speed = new System.Drawing.Point(0, -1);
        }
        public void GoDown()
        {
            _game.Snake.Speed = new System.Drawing.Point(0, 1);
        }
        public void GoLeft()
        {
            _game.Snake.Speed = new System.Drawing.Point(-1, 0);
        }
        public void GoRight()
        {
            _game.Snake.Speed = new System.Drawing.Point(1, 0);
        }




    }
}
