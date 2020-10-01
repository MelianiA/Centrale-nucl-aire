using System;
using System.Collections.Generic;
using System.Linq;

namespace Centrale_nucléaire
{
    class Centrale_nucleaire
    {
        List<IPompe> pompes = new List<IPompe>() 
        {
            new Pompe_electrique(),
            new Pompe_hydrauliques(), 
            new Pompe_hydrauliques() 
        };

        public void seRefroidir()
        {
          pompes.ForEach(p => p.declencher());
        }
    }
    interface IPompe
    {
        public void declencher();
    }
    class Pompe_electrique :IPompe
    {
        public bool active { get; private set; } = false;
        public void declencher()
        {
            active = true;
            Console.WriteLine("Pompe électrique lancée");
        }
    }
    class Pompe_hydrauliques : IPompe
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
