namespace SnakeProj.Models.Api
{
    public class SnakeFieldDataModel
    {
        public int FieldWidth => game.Field._FIELD_WIDTH;
        public int FieldHeigth => game.Field._FIELD_HEIGTH;
        private int[][] _fieldData;
        public int[][] FieldData => _fieldData;
        public SnakeFieldDataModel(game.Game game)
        {
            _fieldData = game.field.FieldData;
        }

    }
}
