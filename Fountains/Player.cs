using System;

    public class Player
    {
        public Grid<int> _compareGrid = new Grid<int>(0,0);
        
        public Player(Grid<int> compareGrid)
        {
            _compareGrid = compareGrid;
        }

    private int _prow = 0;
    private int _pcolumn = 0;


        public int Prow
        {
            get { return _prow; }
            set
            {
                if (_prow < 0 || _prow > _compareGrid.Row)
                {
                    Console.WriteLine("Out of bounds.");
                    {
                        if (_prow < 0) { _prow = 0; }
                        else { _prow = _compareGrid.Row; }
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
                if (_pcolumn < 0 || _pcolumn > _compareGrid.Column)
                {
                    Console.WriteLine("Out of bounds.");
                    {
                        if (_pcolumn < 0) { _pcolumn = 0; }
                        else { _pcolumn = _compareGrid.Column; }
                    }
                }
                else
                    _pcolumn = value;
            }
        }
    }
