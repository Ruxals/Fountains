using System;


public class Fountain
{
    private int _frow = 0;
    private int _fcol = 2;
    public int Frow { get => _frow; set { } }
    public int Fcol { get => _fcol; set { } }

    public bool isFound = false;
    public int isEnabled = 0;
}