using System;
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
            if (_prow < 0 || _prow > compareGrid.Row) { Console.WriteLine("Out of bounds."); }
            _prow = value;
        }
    }
    public int PColumn
    {
        get => _pcolumn;
        set
        {
            if (_pcolumn < 0 || _pcolumn > compareGrid.Column) { Console.WriteLine("Out of bounds."); }
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
    public bool isEnabled = false;
}

public class Game
{
    public Grid<int> grid = new Grid<int>(4, 4);
    public Player player = new Player();
    public Fountain fountain = new Fountain();

    public void Setting(int distance)
    {
        if (distance == 0) { fountain.isFound = true; Console.WriteLine("You have found the fountain!"); }
        if (distance == 1) { Console.WriteLine("Within the caverns you hear droplets from a near. You must be close."); }
        if (distance == 2) { Console.WriteLine("It seems you are in the deep cavern with little sheds of lights. Continue onward."); }
        if (distance == 3) { Console.WriteLine("It seems you are in the deeper cavern with no sheds of light. It's a midnight zone here."); }
        if (distance == 4) { Console.WriteLine("You lie in the deep abyss, this is no place for you."); }
        Console.WriteLine("You hear the cavern's emanations. Continue Onward");
    }
    public void Displacement()
    {
        int rowDif = Math.Abs(player.Prow - fountain.Frow);
        int columnDif = Math.Abs(player.PColumn - fountain.Fcol);
        int totalDif = rowDif + columnDif;
        Setting(totalDif);
    }
    public void Status(string direction)
    {
        switch (direction)
        {
            case "move east":
                player.PColumn++;
                Displacement();
                break;
            case "move west":
                player.PColumn--;
                Displacement();
                break;
            case "move north":
                player.Prow++;
                Displacement();
                break;
            case "move south":
                player.Prow--;
                Displacement();
                break;
            default:
                Console.WriteLine("Make sure the input is lowercased.");
                break;
        }
    }



    public void Run()
    {
        string direction;
        do
        {
            Console.WriteLine("Options are to move in each compass direction i.e. type, move east, to move 1 space to the right");
            Console.WriteLine($"(Row = {player.Prow}, Column = {player.PColumn})");
            Console.WriteLine(("What would you like to do: "));
            direction = Console.ReadLine();
            Status(direction);
        } while (fountain.isFound == false && fountain.isEnabled == false);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game();
        game.Run();
    }
}