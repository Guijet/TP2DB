﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_BD
{
    public class Stagiaire
    {
        private String name;
        private String lastname;
        private int id;

        public Stagiaire(String name, String lastname, int id)
        {
            this.name = name;
            this.lastname = lastname;
            this.id = id;
        }

        public String getName()
        {
            return this.name;
        }

        public String getLastname()
        {
            return this.lastname;
        }

        public int getID()
        {
            return this.id;
        }

    }
}
