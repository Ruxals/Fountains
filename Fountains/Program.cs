
public class Grid<T>
{
    public int Row { get; set; }
    public int Column { get; set; }

    public Grid(int row, int column)
    {
        Row = row;
        Column = column;
        Grid<T>[,] grids = new Grid<T>[Row, Column];
    }
}

public class Player
{
    Grid<int> compareGrid = new Grid<int>(4, 4);
    private int _prow = 0;
    private int _pcolumn = 0;

    public int Prow
    {
        get => _prow;
        set
        {
            if (_prow < compareGrid.Row || _prow > compareGrid.Row) { Console.WriteLine("Out of bounds."); }
            _prow = value;
        }
    }
    public int PColumn
    {
        get => _pcolumn;
        set
        {
            if (_pcolumn < compareGrid.Column || _pcolumn > compareGrid.Column) { Console.WriteLine("Out of bounds."); }
            _prow = value;
        }
    }
}

public class Fountain
{
    private int _frow = 0;
    private int _fcol = 2;
    public int Frow { get => _frow; set { } }
    public int Fcol { get => _fcol; set { } }

    public bool isFound = false;
}

public class Game
{
    public Grid<int> grid = new Grid<int>(4, 4);
    public Player player = new Player();
    public Fountain fountain = new Fountain();

    // hi uhh Im testing... yup
}