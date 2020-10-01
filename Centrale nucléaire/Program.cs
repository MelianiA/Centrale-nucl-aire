using System;
using System.Collections.Generic;

namespace Centrale_nucléaire
{
    class Centrale_nucleaire
    {
        Pompe_electrique pompes_Electrique = new Pompe_electrique();
        List<Pompe_hydrauliques> pompes_hydrauliques = new List<Pompe_hydrauliques>() 
        {
            new Pompe_hydrauliques(), 
            new Pompe_hydrauliques() 
        };

        public void seRefroidir()
        {
            pompes_Electrique.declencher();
            foreach (var pompe in pompes_hydrauliques)
            {
                pompe.declencher();
            }
        }
    }
    class Pompe_electrique
    {
        public bool active { get; private set; } = false;
        public void declencher()
        {
            active = true;
            Console.WriteLine("Pompe électrique lancée");
        }
    }
    class Pompe_hydrauliques
    {
        public bool active { get; private set; } = false;
        public void declencher()
        {
            active = true;
            Console.WriteLine("Pompe hydraulique lancée");
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
