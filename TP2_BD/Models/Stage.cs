using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_BD
{
    public class Stage
    {
        private int id;
        private int id_moniteur;
        private int id_stagiaire;
        private int id_entreprise;
        private String description;
        private String TypeESTG;
        private String Languages;
        private String Plateformes;


        public Stage(int id, int id_moniteur,int id_stagiaire, int id_entreprise, String description,String TypeESTG,String Languages, String Plateformes)
        {
            this.id = id;
            this.id_moniteur = id_moniteur;
            this.id_stagiaire = id_stagiaire;
            this.id_entreprise = id_entreprise;
            this.description = description;
            this.TypeESTG = TypeESTG;
            this.Languages = Languages;
            this.Plateformes = Plateformes;
        }

        public int getId()
        {
            return this.id;
        }

        public int getid_moniteur()
        {
            return this.id_moniteur;
        }

        public int getid_stagiaire()
        {
            return this.id_stagiaire;
        }

        public int getid_entreprise()
        {
            return this.id_entreprise;
        }

        public String getdescription()
        {
            return this.description;
        }

        public String getTypeESTG()
        {
            return this.TypeESTG;
        }

        public String getLanguages()
        {
            return this.Languages;
        }

        public String getPlateformes()
        {
            return this.Plateformes;
        }


    }
}
