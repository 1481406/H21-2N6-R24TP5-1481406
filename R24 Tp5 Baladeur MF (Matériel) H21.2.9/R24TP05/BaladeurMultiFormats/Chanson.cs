using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    public abstract class Chanson : IChanson
    {

        private int m_année;
        private string m_artiste;
        private string m_nomFichier;
        private string m_titre;






        public int Annee
        {
            get { return m_année; }
        }

        public string Artiste
        {
            get { return m_artiste; }
        }

        public abstract string Format
        {
            get;
            
           
        }

        public string NomFichier
        {
            get { return m_nomFichier; }
        }

        public string Paroles
        {

            get
            {
                if (!File.Exists(m_nomFichier))
                {
                    StreamReader Objalire = new StreamReader(m_nomFichier);
                    string paroles = LireParoles(Objalire);
                    Objalire.Close();



                    return paroles;
                }
                else
                    throw new FileNotFoundException();
            } 
        }   

        public string Titre
        {
            get { return m_titre; }
        }

        public void Ecrire(string pParoles)
        {
            StreamWriter EcritParoles = new StreamWriter("Chanson\\" + m_nomFichier);
            EcrireEntete(EcritParoles);
            EcrireParoles(EcritParoles,pParoles);


            EcritParoles.Close();

            
        }

        public abstract void EcrireEntete(StreamWriter pobjFichier);

        public abstract void EcrireParoles(StreamWriter pobjFichier, string pParoles);

        public abstract void LireEntete();


        public abstract string LireParoles(StreamReader pobjfichier);
        

        public void SauterEntete(StreamReader pobjFichier)
        {
            pobjFichier.ReadLine();
        }

        public Chanson(string pNomFichier)
        {
            LireEntete();
            m_nomFichier = pNomFichier;
        }

        public Chanson(string pRepertoire, string pArtiste, string pTitre, int pAnnée)
        {
            m_année = pAnnée;
            m_artiste = pArtiste;
            m_nomFichier = pRepertoire.Substring(9); 
            m_titre = pTitre;
    }


    }
}
