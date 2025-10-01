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

