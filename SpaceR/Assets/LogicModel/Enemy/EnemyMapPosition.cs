
public class EnemyMapPosition
{

    public int RowPlace { get; set; }
    public int ColPlace { get; set; }

    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public void SetPositionFromMatrixPlace(string direction)
    {
        Y = 0;
        switch (direction)
        {
            case "left":
                {
                    X = -RowPlace * 8 - 16;
                    Z = ColPlace * 8 - 8;
                    break;
                }
            case "right":
                {

                    X = RowPlace * 8 - 8;
                    Z = ColPlace * 8 - 8;
                    break;
                }
        }
    }


}
