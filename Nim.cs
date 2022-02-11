/*
 * Nim: Juego donde se tienen N fichas(entre 10 y 20). 
 * Se van retirando por turnos de 1 a 3 fichas. 
 * El jugador compite contra la máquina(con dos niveles de dicultad).
 * Pierde el que retira la última ficha.
 * 
 * Sila Sánchez Violero
 * */
using System;
using System.Threading;
 
class Nim
{
    static void Main()
    {
        int fichas = 0, nivel = 0;
        int turnoInicial;
        bool ganador;
        
        PedirNumFichasIniciales(ref fichas);
        nivel = PreguntarNivel(nivel);
        Console.WriteLine(
        "Iniciando juego Nim con {0} fichas iniciales, nivel {1}.",
            fichas, nivel);
        
        Random turno = new Random();
        turnoInicial = turno.Next(1, 3);    
        Console.WriteLine("...Sorteando el primer turno...");
        Thread.Sleep(2000);
        do
        {
            if (turnoInicial ==1) 
            {            
                TurnoUsuario(ref fichas);
                ganador = true;
                if(fichas > 1)
                {                                
                    TurnoOrdenador(ref fichas, nivel);  
                    ganador = false;
                }               
            }
            else
            {
                TurnoOrdenador(ref fichas, nivel);  
                ganador = false;    
                if(fichas > 1)
                {                
                    TurnoUsuario(ref fichas);
                    ganador = true;
                }               
            }
        }
        while(fichas > 1);
        
        if(ganador == true)
        {
            Console.WriteLine("GANA EL USUARIO");               
        }
        else
        {       
            Console.WriteLine("GANA LA MAQUINA");
        }
     }
     
    static void TurnoOrdenador(ref int fichas, int nivel)
    {
        Random fRet = new Random();
        
        Console.WriteLine();
        Console.WriteLine("¡Juega la máquina!");  
        if(nivel == 1)
        {
            fichas -= (fichas = fRet.Next(1, 4));
            Console.WriteLine("Quedan {0} fichas en la mesa.", fichas);
        }
        else
        {
            if(fichas > 1)
            {
                JugadaNivel2(ref fichas);
                Console.WriteLine("Quedan {0} fichas en la mesa.", fichas);
            }       
        }
    }
     
    static void JugadaNivel2(ref int fichas)
    {
        switch(fichas)
        {
            case 2: 
            case 5: 
            case 6: 
            case 9: 
            case 11: 
            case 12: 
            case 14: 
            case 15:              
                fichas -= 1;
                break;
             
            case 3: 
            case 7: 
            case 10: 
            case 13: 
            case 16: 
            case 17:  
                fichas -= 2; 
                break;
             
            case 4: 
            case 8: 
            case 18: 
            case 19: 
            case 20:
                fichas -= 3; 
                break;
        }
    }
     
    static void TurnoUsuario(ref int fichas)
    {
        int fichasARetirar;
        bool fichasCorrectas;
        
        Console.WriteLine();
        Console.WriteLine("¡Juega el usuario! ");
        do
        {
            Console.Write("Elige número de fichas a retirar: ");
            if (Int32.TryParse(Console.ReadLine(), out fichasARetirar) &&
            fichasARetirar >= 1 && fichasARetirar <= 3)
            {
                fichas -= fichasARetirar;
                Console.WriteLine("Ahora quedan {0} fichas.", fichas);
                fichasCorrectas = true;
            }
            else
            {
                Console.WriteLine("Número de fichas incorrecto.");
                fichasCorrectas = false;
            }
        }
        while(!fichasCorrectas);
    }
     
    static void PedirNumFichasIniciales(ref int fichas)
    {   
        bool numeroCorrecto;        
        do
        {
            Console.Write("Escribe el número de fichas para empezar: ");
            if (Int32.TryParse(Console.ReadLine(), out fichas) &&
            fichas >= 10 && fichas <= 20)
            {   
                numeroCorrecto = true;
            }
            else
            {
                Console.WriteLine("Número de fichas incorrecto");
                numeroCorrecto = false;
            }
        }
        while(!numeroCorrecto);     
    }
     
    static int PreguntarNivel(int nivel)
    {   
        bool nivelCorrecto;
        do
        {
            Console.Write("Escribe el nivel de dificultad: ");
            if (Int32.TryParse(Console.ReadLine(), out nivel) &&
                nivel >= 1 && nivel <= 2)
            {
                nivelCorrecto = true;
            }
            else
            {
                Console.WriteLine("Nivel incorrecto.");
                nivelCorrecto = false;
            }
        }
        while(!nivelCorrecto);
        
        return nivel;
    }
 }
