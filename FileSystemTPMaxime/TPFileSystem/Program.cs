using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Fichier courant = new Directory("/", null);
            string saisie;
           




            do
            {
           
                Console.Write( "|"+courant.Nom+"|");
                string argument = null;
                string commande = null;
                string argument2 = null;
                saisie = Console.ReadLine();
                string[] str = saisie.Split(' ');
                if (str.Length == 1) {
                    commande = str[0];
                    argument = null;
                }
                else if (str.Length == 2)
                {

                    commande = str[0];
                    argument = str[1];
                }
                else if (str.Length == 3)
                {
                    commande = str[0];
                    argument = str[1];
                    argument2 = str[2];
                }

                if (courant.isDirectory() == true)
                {
                    Directory courantDir = (Directory)courant;


                    switch (commande)
                    {
                        case "mkdir":
                            courantDir.mkdir(argument);

                            break;

                        case "cd":
                            Fichier cdDir = courantDir.cd(argument);
                            if (cdDir == null || !cdDir.canRead())
                            {
                                Console.WriteLine("Vous ne pouvez pas faire ça");
                            }
                            else
                            {
                                courant = cdDir;
                            }
                            break;

                        case "ls":
                            if (courantDir.canRead())
                            {
                                List<Fichier> liste = courantDir.ls();
                                if (courant.isDirectory() == true)
                                {
                                    foreach (Fichier file in liste)
                                    {
                                        Console.WriteLine(file.Nom);
                                    }
                                }
                                else if (courant.isFile() == true)
                                {
                                    Console.WriteLine("Vous êtes dans un file");
                                }
                            }
                            else {
                                Console.WriteLine("Vous n'avez pas la permission");
                            }
                            break;

                        case "create":
                            courantDir.createNewFile(argument);
                            break;
                        case "parent":
                            courant = courant.getParent();

                            break;
                        case "search":
                            List<Fichier> resultat = courantDir.search(argument);
                            if (resultat != null)
                                {
                                    foreach (Fichier file in resultat)
                                        Console.WriteLine(file.getPath());
                                }
                            else
                                {
                                    Console.WriteLine("Vous n'avez pas les droits de lire dans ce dossier");
                                }
                            break;
                        case "path":
                        string path  = courant.getPath();
                        Console.WriteLine(path);
                            break;
                        case"chmod":
                            int permi = int.Parse(argument);
                            courant.chmod(permi);
                            break;
                         case"rename":
                        courantDir.rename(argument,argument2);
                            break;
                        case"file":
                            if (courant.isFile())
                            {
                                Console.WriteLine("C'est un fichier");
                            }
                            else
                            {
                                Console.WriteLine("Ce n'est pas un fichier");
                            }
                            break;
                        case"directory":
                            if (courant.isDirectory())
                            {
                                Console.WriteLine("C'est un répertoire");
                            }
                            else
                            {
                                Console.WriteLine("Ce n'est pas un répertoire");
                            }
                            break;
                        case"delete":
                            courantDir.delete(argument);
                            break;


                    }
                }
             
                
            } while (saisie != "exit");
        }
    }
}

