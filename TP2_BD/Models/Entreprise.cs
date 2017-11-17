using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_BD
{
    public class Entreprise
    {
        private int id;
        private String nom;
        public Entreprise(int id,String nom)
        {
            this.id = id;
            this.nom = nom;
        }

        public int getID()
        {
            return this.id;
        }

        public String getName()
        {
            return this.nom;
        }

    }
}
