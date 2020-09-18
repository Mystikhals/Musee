using System;
using System.Collections.Generic;

namespace Musee
{
    //---------------
    // Classe de TEST
    //---------------
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region CREER UN MUSEE

                string nom = "Musee des Celestins - VICHY";
                Musee celestins = new Musee(nom);
                Console.WriteLine("*** Création du musee {0} ***\n", nom);

                // -- Ajouter des ARTISTES
                Artiste monet = new Artiste("Monet", "Francaise");
                Artiste manet = new Artiste("Manet", "Francaise");
                Artiste vangogh = new Artiste("Van Gogh", "Neelandaise");
                Console.WriteLine(celestins.CreerArtiste(monet));
                Console.WriteLine(celestins.CreerArtiste(manet));
                Console.WriteLine(celestins.CreerArtiste(vangogh));

                // -- Ajouter des SALLES
                Salle francaise = new Salle("Francaise", 2000000);
                Salle neerlandaise = new Salle("Neerlandaise", 2000000);
                Console.WriteLine(celestins.CreerSalle(francaise));
                Console.WriteLine(celestins.CreerSalle(neerlandaise));

                // -- Ajouter des ETATS des OEUVRES
                Etat_Oeuvre bon = new Etat_Oeuvre("Bon", 365);
                Etat_Oeuvre moyen = new Etat_Oeuvre("Moyen", 180);
                Etat_Oeuvre mauvais = new Etat_Oeuvre("Mauvais", 30);

                // -- Ajouter des OEUVRES

                // MONET
                Oeuvre o1 = new Oeuvre_Achetee("Le Déjeuner sur l'herbe", 500000, new DateTime(2018,09,15), new DateTime(2018, 07, 15), moyen, monet); 
                Oeuvre o2 = new Oeuvre_Achetee("Au bord de l'eau", 350000, new DateTime(2018, 09, 15), new DateTime(2018, 05, 15), bon);
                Oeuvre o3 = new Oeuvre_Achetee("La Plage à Honfleur", 90000, new DateTime(2018, 09, 15), new DateTime(2018, 07, 1), mauvais, monet); // A expertiser
                Oeuvre o4 = new Oeuvre_Achetee("Quai du Louvre", 110000, new DateTime(2018, 09, 15), new DateTime(2018, 07, 15), mauvais, monet); // A expertiser

                // MANET
                Oeuvre o5 = new Oeuvre_Pretee("La Partie de croquet", "Museé d'Orsay", new DateTime(2018,05,03), new DateTime(2019,01,15));
                Oeuvre o6 = new Oeuvre_Pretee("Le Joueur de fifre", "Musée du Prado", new DateTime(2018, 08, 01), new DateTime(2019, 12, 31));
                Oeuvre o7 = new Oeuvre_Achetee("Le petit Lange", 110000, new DateTime(2018, 09, 15), new DateTime(2018, 08, 25), mauvais, manet);
                Oeuvre o8 = new Oeuvre_Achetee("L'Exécution de Maximilien", 250000, new DateTime(2018, 09, 15), new DateTime(2018, 08, 1), mauvais, manet); // A expertiser
                Oeuvre o9 = new Oeuvre_Achetee("Portrait d'Émile Zola", 95000, new DateTime(2018, 09, 15), new DateTime(2018, 06, 15), moyen, manet);

                // VAN GOGH
                Oeuvre o10 = new Oeuvre_Achetee("Tournesols dans un vase", 750000, new DateTime(2018, 09, 15), new DateTime(2018, 07, 15), mauvais); // A expertiser
                Oeuvre o11 = new Oeuvre_Pretee("Champ de ble avec cypres", "Metropolitan Museum", new DateTime(2016, 10, 24), new DateTime(2018, 10, 24));
                Oeuvre o12 = new Oeuvre_Achetee("Autoportrait", 1000000, new DateTime(2018, 09, 15), new DateTime(2018, 08, 30), mauvais);
                Oeuvre o13 = new Oeuvre_Achetee("Le Champ de blé aux iris", 95000, new DateTime(2018, 09, 15), new DateTime(2018, 07, 15), moyen);

                // SALLE FRANCAISE - MONET
                Console.WriteLine(celestins.CreerOeuvre(o1, celestins.GetSalle(0)));
                Console.WriteLine(celestins.CreerOeuvre(o2, monet, celestins.GetSalle(0)));
                Console.WriteLine(celestins.CreerOeuvre(o3, celestins.GetSalle(0)));
                Console.WriteLine(celestins.CreerOeuvre(o4, celestins.GetSalle(0)));

                // SALLE FRANCAISE - MANET
                Console.WriteLine(celestins.CreerOeuvre(o5, manet, celestins.GetSalle(0)));
                Console.WriteLine(celestins.CreerOeuvre(o6, manet, celestins.GetSalle(0)));
                Console.WriteLine(celestins.CreerOeuvre(o7, celestins.GetSalle(0)));
                Console.WriteLine(celestins.CreerOeuvre(o8, celestins.GetSalle(0)));
                Console.WriteLine(celestins.CreerOeuvre(o9, celestins.GetSalle(0)));

                // SALLE NEERLANDAISE - VAN GOGH
                Console.WriteLine(celestins.CreerOeuvre(o10, vangogh, celestins.GetSalle(1)));
                Console.WriteLine(celestins.CreerOeuvre(o11, vangogh, celestins.GetSalle(1)));
                Console.WriteLine(celestins.CreerOeuvre(o12, vangogh, celestins.GetSalle(1)));
                Console.WriteLine(celestins.CreerOeuvre(o13, vangogh, celestins.GetSalle(1)));
                
                #endregion

                Console.ReadKey();
                Console.Clear();

                #region AFFICHER LE MUSEE
                Console.WriteLine(celestins.ToString());
                #endregion

                Console.ReadKey();
                Console.Clear();

                #region TESTS DES INDEXEURS
                
                // -- Sur le RANG
                Oeuvre uneOeuvre = francaise[1];
                if (uneOeuvre != null)
                    Console.WriteLine(uneOeuvre.GetNomOeuvre() + " TROUVEE");
                else
                    Console.WriteLine("Oeuvre non TROUVEE");

                uneOeuvre = francaise[10];
                if (uneOeuvre != null)
                    Console.WriteLine(uneOeuvre.GetNomOeuvre() + " TROUVEE");
                else
                    Console.WriteLine("Oeuvre non TROUVEE");

                // -- Sur le PRIX
                Console.WriteLine();
                Console.WriteLine("*** Oeuvres de la salle française de prix <= 500000 Euros");
                List<Oeuvre> lesOeuvres = francaise[500000F];
                if (lesOeuvres != null)
                    foreach (Oeuvre o in lesOeuvres)
                        Console.WriteLine(o.ToString());

                // -- Sur l'ARTISTE
                Console.WriteLine();
                Console.WriteLine("*** Oeuvres de MONET dans la salle française ");
                lesOeuvres = francaise[monet];
                if (lesOeuvres != null)
                    foreach (Oeuvre o in lesOeuvres)
                        Console.WriteLine(o.ToString());

                // -- Sur le NOM de l'ARTISTE
                Console.WriteLine();
                Console.WriteLine("*** Oeuvres de MANET dans la salle française ");
                lesOeuvres = francaise[manet.GetNomArtiste()];
                if (lesOeuvres.Count != 0)
                    foreach (Oeuvre o in lesOeuvres)
                        Console.WriteLine(o.ToString());

                Console.WriteLine();
                Console.WriteLine("*** Oeuvres de DAVOLIO dans la salle française");
                lesOeuvres = francaise["Davolio"];
                if (lesOeuvres.Count != 0)
                    foreach (Oeuvre o in lesOeuvres)
                        Console.WriteLine(o.ToString());
                
                #endregion

                Console.ReadKey();
                Console.Clear();

                #region TEST PREDICATS ET TRIS
                
                // Méthode "FIND".
                // Renvoie le PREMIER élement de la collection pour 
                // lequel le prédicat est VRAI...
                Console.WriteLine("\n\n*** Recherche des OEUVRES de VAN GOGH ***");
                Predicats.nomArtiste = "Van Gogh";

                // A COMPLETER

                // Utilisation de la méthode "Sort" pour TRIER
                // les élements de la collection d'OEUVRE suivant le NOM
                lesOeuvres = new List<Oeuvre>() {o1,o2,o3,o4,o5,o6,o7,o8,o9,o10,o11,o12,o13};

                lesOeuvres.Sort(Predicats.ComparerOeuvresParNom);
                Console.WriteLine("\n\n*** TRI par NOM ***");
                foreach (Oeuvre o in lesOeuvres)
                    Console.WriteLine(o.ToString());

                Console.WriteLine();

                // 05, 06 et o11 sont des oeuvres prêtées
                lesOeuvres = new List<Oeuvre>() { o1, o2, o3, o4, o7, o8, o9, o10, o12, o13 };
                lesOeuvres.Sort(Predicats.ComparerOeuvresParPrix);
                Console.WriteLine("\n\n*** TRI par Prix ***");
                foreach (Oeuvre o in lesOeuvres)
                    Console.WriteLine(o.ToString());

                #endregion

                Console.ReadKey();
                Console.Clear();

                #region TEST DES OEUVRES À EXPERTISER

                Console.WriteLine("*** OEUVRES A EXPERTISER (parmi l'ensemble des oeuvres de chause salle) ***\n\n");
                
                // A COMPLETER

                #endregion
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }

            Console.ReadKey();
        }
    }
}
