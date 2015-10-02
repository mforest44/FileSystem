using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFileSystem
{
     public class Fichier
    {
         public Directory Parent=null;
         public string Nom {get;set;}
         public int permission = 4;
        
       

        public Fichier(string Nom, Directory Parent) {
            
            this.Nom = Nom;
            this.Parent = Parent;

        }



        public bool canWrite()
        {
            return (permission & 2) > 0;
        }
        public bool canExecute()
        {
            return (permission & 1) > 0;
        }
        public bool canRead()
        {
            return (permission & 4) > 0;
        }

        public void chmod(int permission)
        {

            this.permission = permission;
        }



        public bool isFile() 
        {
            if (this.GetType() == typeof(Fichier))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isDirectory(){
            if(this.GetType()==typeof(Directory))
            {
                return true;
            }
            else{
                return false;
            }
        }
        public virtual bool mkdir(string name) {
            return false;
        }

        public virtual bool cd(string name)
        {
            return false;
        }


        public Fichier getParent()
        {
            if (this.Nom != "/")
                return this.Parent;
            else
            {
                Console.WriteLine("Je suis la racine !");
                return this;
            }

        }

        public string getPath()
        {
            Fichier pathFile = this;
            string path = "";

            while (pathFile.Nom != "/")
            {

                path = pathFile.Nom + "/" + path;
                pathFile = pathFile.Parent;

            }

            return path;

        }

        public string getPermission()
        {
            string permission = "";
            if (this.canExecute())
            {
                permission = permission + "x";
            }
            else if (this.canRead())
            {
                permission = permission + "r";
            }
            else if (this.canWrite())
            {
                permission = permission + "w";
            }
            else
            {
                permission = permission + "-";
            }
            return permission;
        }




    }
}
