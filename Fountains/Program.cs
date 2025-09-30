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

    private int _prow;
    private int _pcolumn;

    
    public int Prow
    {
        get { return _prow; }
        set
        {
            if (_prow < 0 || _prow > compareGrid.Row)
            {
                Console.WriteLine("Out of bounds.");
                {
                    if (_prow < 0) { _prow = 0; }
                    else { _prow = compareGrid.Row; }
                }
            }
            else
            _prow = value;
        }
    }
    public int PColumn
    {
        get { return _pcolumn; }
        set
        {
            if (_pcolumn < 0 || _pcolumn > compareGrid.Column)
            {
                Console.WriteLine("Out of bounds.");
                {
                    if (_pcolumn < 0) { _pcolumn = 0; }
                    else { _pcolumn = compareGrid.Column; }
                }
            }
            else
                _pcolumn = value;
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
    public int isEnabled = 0;
}

public class Game
{

    public Grid<int> grid = new Grid<int>(4, 4);
    public Player player = new Player();
    public Fountain fountain = new Fountain();

    public void EnableFountain()
    {
        string choice;

        if (fountain.isFound)
        {
            Console.WriteLine("Type 'yes' to End and Enable the Fountain or 'no' if you want to stay:");
            choice = Console.ReadLine();
            if (choice == "yes") { Console.WriteLine("The fountain is flowing and running! Thanks for Playing!\n"); fountain.isEnabled = 1; }
            else if (choice == "no") { Console.WriteLine("You may continue to explore the caverns although it's kind of dangerous.\n"); fountain.isEnabled = 0; }
        }
        else
            Console.WriteLine("Fountain not Found Let's Continue.");

    }

    public void Setting(int distance)
    {
     

        switch (distance)
        {
            case 0:
                Console.WriteLine("You have found the fountain!\n");
                fountain.isFound = true;
                EnableFountain();
                return;
            case 1:
                Console.WriteLine("Within the caverns you hear droplets from a near. You must be close.\n");
                return;
           case 2:
                Console.WriteLine("It seems you are in the deeper cavern with no sheds of light. It's a midnight zone here.\n");
                return;
          case 3:
                Console.WriteLine("You lie in the deep abyss, this is no place for you.\n");
                return;
            default:
                Console.WriteLine("You hear the cavern's emanations. Continue Onward.\n");
                return;


        }
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
                player.Prow+= 1;
                Displacement();
                break;
            case "move west":
                player.Prow--;
                Displacement();
                break;
            case "move north":
                player.PColumn+= 1;
                Displacement();
                break;
            case "move south":
                player.PColumn+= 1;
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
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Options are to move in each compass direction i.e. type, move east, to move 1 space to the right. \n");
            Console.WriteLine($"(Row = {player.Prow}, Column = {player.PColumn}) \n ");
            Console.WriteLine("What would you like to do: ");
            direction = Console.ReadLine();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            Status(direction);   
        } while (!(fountain.isFound && fountain.isEnabled == 1)); // isFound = false, enable = false, !(false) = true, loop continues, loop fails when fully true. 


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