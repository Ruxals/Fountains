using System;

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
