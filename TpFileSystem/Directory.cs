using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFileSystem
{
      class Directory : Fichier
    {
        public List<Fichier> Fichiers = new List<Fichier>();

        public Directory(string Nom, Directory Parent) : base(Nom, Parent) {
            
        }



        public override bool mkdir(string nom)
        {
            Directory newDirectory = new Directory(nom, this);
            Fichiers.Add(newDirectory);
            Console.WriteLine("Directory créé");
            
            return true;
        }

        public Fichier cd(string name)
        {
            
            foreach (Fichier file in Fichiers)
            {
                if (file.Nom == name)
                {
                    return file;
                }
                
            }
            return null;
        }

        public virtual bool createNewFile(string name)
        {
            Fichier newFichier = new Fichier(name, this);
            Fichiers.Add(newFichier);
            Console.WriteLine("Fichier créé");
            return true;
        }

        public List<Fichier> ls()
        {
            return this.Fichiers;
        }
        public List<Fichier> search(string name)
        {
            List<Fichier> retour = null;


            retour = new List<Fichier>();

            foreach (Fichier searchDir in Fichiers)
            {

                if (searchDir.Nom == name)
                {
                    retour.Add(searchDir);
                }

                
                List<Fichier> retour2 = new List<Fichier>();
                Directory searchDir2 = (Directory)searchDir;
                retour2 = searchDir2.search(name);
                    foreach (Fichier courant in retour2)
                    {
                        retour.Add(courant);
                    }
            }
            return retour;
        }

        public bool rename(string nomFichier, string nouveauNom)
        {
            foreach (Fichier file in Fichiers)
            {
                if (file.Nom == nomFichier)
                {
                    file.Nom = nouveauNom;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool delete(string name)
        {
                foreach (Fichier file in Fichiers)
                {

                    if (file.Nom == name)
                    {
                        Fichiers.Remove(file);
                        return true;
                    }

                }
                return false;
        }


            
      }
    }
   
