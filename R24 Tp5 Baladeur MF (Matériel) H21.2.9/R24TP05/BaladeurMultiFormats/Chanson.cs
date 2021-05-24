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
        // les informations de la chanson.
        public int m_année;
        public string m_artiste;
        public string m_nomFichier;
        public string m_titre;




        // retourne l'année de la chanson

        public int Annee
        {
            get { return m_année; }
        }
        // retourne Lartiste de la chanson
        public string Artiste
        {
            get { return m_artiste; }
        }
        // retourne le format de la chanson
        public abstract string Format
        {
            get;
            
           
        }

        // retourne le nom du fichier de la chanson
        public string NomFichier
        {
            get { return m_nomFichier; }
        }
        // retourne les paroles de la chanson
        public string Paroles
        {

            get
            {
                // si le fichier existe 
                if (!File.Exists(m_nomFichier))
                {
                    //vas lire les paroples du fichier
                    StreamReader Objalire = new StreamReader(m_nomFichier);
                    string paroles = LireParoles(Objalire);
                    Objalire.Close();


                    // retourne les paroles
                    return paroles;
                }

                // sinon envois une érreur que le fichier n'existe pas.
                else
                    throw new FileNotFoundException();
            } 
        }   

        public string Titre
        {
            // retourne le titre de la chanson
            get { return m_titre; }
        }

        // écrit les paroles
        public void Ecrire(string pParoles)
        {
            // load un fichier pour écrire dedans
              StreamWriter EcritParoles = new StreamWriter("Chanson\\" + m_nomFichier);
           // Lentête de la chanson dans le fichier
            EcrireEntete(EcritParoles);
            // écrit les paroles dans le fichier de la chanson

            EcrireParoles(EcritParoles,pParoles);

            //ferme le nouveau fichier.
            EcritParoles.Close();

            
        }

        // classes abstraites pour les formats différents de la chanson dépendament des formats
        public abstract void EcrireEntete(StreamWriter pobjFichier);

        public abstract void EcrireParoles(StreamWriter pobjFichier, string pParoles);

        public abstract void LireEntete();


        public abstract string LireParoles(StreamReader pobjfichier);
        
        // Saute L'entête du ficher chanson pour aller lire les paroles 
        public void SauterEntete(StreamReader pobjFichier)
        {
            pobjFichier.ReadLine();
        }
        // constructeur Chanson
        public Chanson(string pNomFichier)
        {
            //Lit l'entête de la chanson
            LireEntete();
            // assigne le nom du fichier a m_nomfichier
            m_nomFichier = pNomFichier;
        }
        // constructeur chanson
        public Chanson(string pRepertoire, string pArtiste, string pTitre, int pAnnée)
        {
            // assigne les valeurs de la chanson aux m_* respectif
            m_année = pAnnée;
            m_artiste = pArtiste;
            m_nomFichier = pRepertoire.Substring(9); 
            m_titre = pTitre;
    }


    }
}
