using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

 
namespace Centrale_nucléaire
{
    public delegate void declencherdel(PompeEventArgs e);
    class Centrale_nucleaire
    {
        public ArrayList pompes = null;
        public event declencherdel listdel;
        public int temperature = 3000;

        public Centrale_nucleaire()
        {
            pompes = new ArrayList()
                {
                    new Pompe_electrique(),
                    new Pompe_hydrauliques(),
                    new Pompe_hydrauliques() ,
                    new Pompe_manuelle()
                };
       
            listdel += ((Pompe_electrique)pompes[0]).declencher;
            listdel += ((Pompe_hydrauliques)pompes[1]).declencher;
            listdel += ((Pompe_hydrauliques)pompes[2]).declencher;
            listdel += ((Pompe_manuelle)pompes[3]).declencher;
        }
        PompeEventArgs tmp = new PompeEventArgs() {temperature = 5000, pression= 155};
        public void seRefroidir()
        {
            listdel(tmp);
        }
    }

    public class PompeEventArgs : EventArgs
    {
        public int temperature { get; set; }
        public int pression { get; set; }
    }
    class Pompe_electrique  
    {
        public void declencher(PompeEventArgs ev)
        {
            Console.WriteLine("Pompe hydraulique lancée, [Température: " + ev.temperature + ", Pression = "+ev.pression+" bar]");
        }
    }
    class Pompe_hydrauliques
    {
        public void declencher(PompeEventArgs ev)
        {
            Console.WriteLine("Pompe hydraulique lancée, [Température: " + ev.temperature + ", Pression = " + ev.pression + " bar]");
        }
    }
    class Pompe_manuelle  
    {
        public void declencher(PompeEventArgs ev)
        {
            Console.WriteLine("Pompe hydraulique lancée, [Température: " + ev.temperature + ", Pression = " + ev.pression + " bar]");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Centrale_nucleaire ctn = new Centrale_nucleaire();
            ctn.seRefroidir();
            Console.ReadKey();
        }
    }
}
