using System;
using System.Collections.Generic;

public static class Escape {
    private static int _vidasRestantes;
    private static string[] _incognitasSalas;
    public static string[] _nombreViews; // -, Habitacion1, Habitacion2 ..., Victoria
    public static int _estadoJuego = 0;

    public static int VidasRestantes
    {
        get {return _vidasRestantes;}
        set {_vidasRestantes = value;}
    }

    public static string[] nombreViews
    {
        get {return _nombreViews;}
    }

    public static int EstadoJuego
    {
        get {return _estadoJuego;}
        set {_estadoJuego = value;}
    }

    public static void InicialiazarJuego()
    {
        _incognitasSalas = new string[5];
        //La sala [0] es ignorada ya que indexamos desde el 1
        _incognitasSalas[1] = "admin1";
        _incognitasSalas[2] = "admin2";
        _incognitasSalas[3] = "admin3";
        _incognitasSalas[4] = "admin4";

        _nombreViews = new string[7];
        //La sala [0] es ignorada ya que indexamos desde el 1
        _nombreViews[1] = "../Habitaciones/Habitacion1";
        _nombreViews[2] = "../Habitaciones/Habitacion2";
        _nombreViews[3] = "../Habitaciones/Habitacion3";
        _nombreViews[4] = "../Habitaciones/Habitacion4";
        _nombreViews[5] = "../Habitaciones/Victoria"; //Self explanatory
        _nombreViews[6] = "../Habitaciones/Derrota"; //Self explanatory

        _estadoJuego = 1;
        _vidasRestantes = 3;
    }

    public static bool resolverSala(int sala, string incognita)
    {
        if(sala != _estadoJuego) return false;
        return _incognitasSalas[sala] == incognita;
    }
}