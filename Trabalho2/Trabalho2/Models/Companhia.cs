using System.Collections.Generic;
using System.Linq;
using System;

namespace Trabalho2.Models
{
    class Companhia
    {
        public List<Voo> listaDeVoos { get; set; }
        // public ICollection<Voo> listaDeVoos;

        public Companhia()
        {
            this.listaDeVoos = new List<Voo>();
        }

        public void exibirVoos()
        {
            foreach (var voos in this.listaDeVoos)
            {
                Console.WriteLine("Codigo: " + voos.codigo + " | Descricão: " + voos.descricao);
            }
            Console.WriteLine("-------------------------------------");
        }

    }
}
