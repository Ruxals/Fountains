using System;

    public class Fountain
    {
        public Fountain(int row, int column)
        {
            _frow = row;
            _fcol = column;
        }
        private int _frow;
        private int _fcol;
        public int Frow { get => _frow; set { } }
        public int Fcol { get => _fcol; set { } }

        public bool isFound = false;
        public int isEnabled = 0;
    }
