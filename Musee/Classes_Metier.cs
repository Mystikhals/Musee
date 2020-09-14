using System;
using System.Collections.Generic;

namespace Musee
{
    #region Classe ARTISTE
    public class Artiste
    {
        // Attributs 
        private string nomArtiste;
        private string nationalite;

        // Constructeur (+ surcharge)
        public Artiste(string nom, string nat)
        { this.nomArtiste = nom; this.nationalite = nat; }
        public Artiste(Artiste a)
        {
            if (a != null)
            {
                this.nomArtiste = a.nomArtiste;
                this.nationalite = a.nationalite;
            }
        }

        // Accesseurs
        public string GetNomArtiste()
        { return this.nomArtiste; }
        public string GetNationalité()
        { return this.nationalite; }
        public void SetNom(string nom)
        { this.nomArtiste = nom; }
        public void SetNationalité(string nat)
        { this.nationalite = nat; }

        // Retourne une chaine avec nom et nationalité de l’artiste)
        public override string ToString()
        { return string.Format("\t[" + this.nomArtiste + ", nationalité " + this.nationalite + "]"); }
    }
    #endregion

    # region Classe ETAT de l'OEUVRE
    public class Etat_Oeuvre
    {
        // Attributs
        private string libelle;
        private int nbJoursEntreExpertises;

        // Constructeur
        public Etat_Oeuvre(string l, int nb)
        {
            this.libelle = l;
            this.nbJoursEntreExpertises = nb;
        }

        // Accesseurs
        public string getLibelleEtatOeuvre()
        { return this.libelle; }
        public int getNbJoursEntreExpertises()
        { return this.nbJoursEntreExpertises; }
    }
    #endregion

    # region Classe OEUVRE
    public class Oeuvre
    {
        // Attributs communs
        private string nomOeuvre;
        private Artiste artisteOeuvre;

        // Constructeur (+ surcharges)
        public Oeuvre(string nom)
        {
            this.nomOeuvre = nom; 
            this.artisteOeuvre = null;
        }
        public Oeuvre(string nom, Artiste a)
        {
            this.nomOeuvre = nom;
            this.artisteOeuvre = a;
        }
        public Oeuvre(Oeuvre o)
        {
            this.nomOeuvre = o.nomOeuvre;
            this.artisteOeuvre = o.artisteOeuvre;
        }

        // Accesseurs
        public string GetNomOeuvre()
        { return this.nomOeuvre; }
        public void SetNomOeuvre(string nom)
        { this.nomOeuvre = nom; }

        // Accesseurs sur l'attribut 'artisteOeuvre'
        public Artiste GetArtiste()
        { return this.artisteOeuvre; }
        public void SetArtiste(Artiste a)
        {
            this.artisteOeuvre = a;
        }

        // Méthode redéfinie dans les classes DERIVEES
        public new string ToString()
        {
            string résultat = "\t[";
            résultat += nomOeuvre;
            résultat += "=> ";
            résultat += artisteOeuvre.GetNomArtiste();
            résultat += ", ";
            résultat += artisteOeuvre.GetNationalité();
            résultat += "]";

            return string.Format(résultat);
        }
    }
    #endregion

    #region Classe OEUVRE ACHETEE
    public class Oeuvre_Achetee : Oeuvre
    {
        // Attributs spécifiques
        private float prixOeuvre;
        private DateTime dateAchat;
        private Etat_Oeuvre etat;
        private DateTime dateDerniereExpertise;
        private bool aExpertiser;

        // Constructeur (+surcharges)
        public Oeuvre_Achetee(string nom, float prix, DateTime achat, DateTime expertise, Etat_Oeuvre etat) : base(nom)
        {
            this.SetNomOeuvre(nom);
            this.prixOeuvre = prix;
            this.dateAchat = achat;
            this.dateDerniereExpertise = expertise;
            this.etat = etat;
            
        }
        public Oeuvre_Achetee(string nom, float prix, Etat_Oeuvre etat) : base(nom)
        {
            this.SetNomOeuvre(nom);
            this.prixOeuvre = prix;
            this.dateAchat = DateTime.Now;
            this.dateDerniereExpertise = DateTime.Now;
            this.etat = etat;
        }
        public Oeuvre_Achetee(string nom, float prix, DateTime achat, DateTime expertise, Etat_Oeuvre etat, Artiste a) : base(nom,a)
        {
            this.SetNomOeuvre(nom);
            this.prixOeuvre = prix;
            this.dateAchat = achat;
            this.dateDerniereExpertise = expertise;
            this.etat = etat;
            this.SetArtiste(a);
        }
        public Oeuvre_Achetee(Oeuvre o) : base(o)
        {
            this.SetArtiste(o.GetArtiste());
            this.SetNomOeuvre(o.GetNomOeuvre());
            
        }

        // Accesseurs
        public float GetPrixOeuvre()
        { return this.prixOeuvre; }
        public void SetPrixOeuvre(float prix)
        { this.prixOeuvre = prix; }

        // Méthode permettant de savoir si une oeuvre est à expertiser.
        public bool estAExpertiser()
        {
            if (DateTime.Now > dateDerniereExpertise.AddDays(30)) 
            {
                this.aExpertiser = true;
            }
            if (this.aExpertiser == true)
                return true;
            else
                return false;
        }

        // Formatage une chaine avec les informations de l'oeuvre
        // A COMPLETER
        public new string ToString()
        {
            string aRetourner="";
            aRetourner += string.Format("\n\tAchetée le {0} et expertisée le {1}\n", this.dateAchat.ToShortDateString(), this.dateDerniereExpertise.ToShortDateString());
            aRetourner += string.Format("\tEtat {0}\n", this.etat.getLibelleEtatOeuvre());
            aRetourner += string.Format("\tPour {0} euros\n", this.prixOeuvre);

            return aRetourner;
        }
    }
    #endregion

    #region Classe OEUVRE PRETEE
    public class Oeuvre_Pretee : Oeuvre
    {
        // Attribut spécifique
        private string preteur;
        private DateTime date_debut;
        private DateTime date_fin;

        // Constructeur (+surcharges)
        // Pour la dernière surcharge : 
        //  * Les dates seront initialisées à la date courante
        //  * Le prêteur sera initialisé à "inconnu"
        public Oeuvre_Pretee(string nom, string preteur, DateTime debut, DateTime fin) : base(nom)
        {
            this.SetNomOeuvre(nom);
            this.preteur = preteur;
            this.date_debut = debut;
            this.date_fin = fin;
        }
        public Oeuvre_Pretee(string nom, string preteur, DateTime debut, DateTime fin, Artiste a) : base(nom,a)
        {
            this.SetNomOeuvre(nom);
            this.preteur = preteur;
            this.date_debut = debut;
            this.date_fin = fin;
            this.SetArtiste(a);
        }
        public Oeuvre_Pretee(Oeuvre o) : base(o)
        {
            o.SetNomOeuvre(o.GetNomOeuvre());
            o.SetArtiste(o.GetArtiste());
            this.preteur = "inconnu";
            this.date_debut = DateTime.Now;
            this.date_fin = DateTime.Now;
        }

        // Accesseurs
        // Remarque : getDates retourne un TABLEAU avec les deux dates (début et fin)
        // et setDates reçoit en paramètre un tableau analogue.
        public string getPreteur()
        { return this.preteur; }
        public DateTime[] getDates()
        { return new DateTime[] { this.date_debut, this.date_fin }; }
        public void setPreteur(string p)
        { this.preteur = p; }
        public void setDates(DateTime[] dates)
        {
            this.date_debut = dates[0];
            this.date_fin = dates[1];
        }

        // Formatage une chaine avec les informations de l'oeuvre
        // A COMPLETER
        public new string ToString()
        {
            string aRetourner = "";
            aRetourner += string.Format("\n\tPrêtée par {0} pour {1} jours\n", this.preteur, (this.date_fin - this.date_debut).Days);
            return aRetourner;
        }
    }
    #endregion

    #region Classe SALLE
    public class Salle
    {
        // Attributs
        private string nomSalle;
        private float montantAssurance;
        private List<Oeuvre> lesOeuvres; // Objets POLYMORPHES

        // Constructeur (+ surcharges)
        public Salle(string nomSalle, float montant)
        {
            this.nomSalle = nomSalle;
            this.montantAssurance = montant;
            this.lesOeuvres = new List<Oeuvre>();
        }
        public Salle(Salle s)
        {
            this.nomSalle = s.nomSalle;
            this.montantAssurance = s.montantAssurance;
            this.lesOeuvres = s.lesOeuvres;
        }
        public Salle(string nomSalle, float montant, List<Oeuvre> l)
        {
            this.nomSalle = nomSalle;
            this.montantAssurance = montant;
            this.lesOeuvres = l;
        }

        // Accesseurs sur le nom de la salle et le montant de l'assureance
        public string GetNomSalle()
        { return this.nomSalle; }
        public float GetMontantAssurance()
        { return this.montantAssurance; }
        public void SetNomSalle(string nom)
        { this.nomSalle = nom; }
        public void SetMontantAssurance(float mtt)
        { this.montantAssurance = mtt; }

        // Retourne le nombre d'oeuvres
        public int GetNbOeuvres()
        { return this.lesOeuvres.Count; }

        // Retourne l’oeuvre dont le nom est passé en paramètre ou "null" sinon trouvée.
        public Oeuvre GetOeuvre(string nom)
        {
            foreach (Oeuvre o in lesOeuvres) 
            {
                if (o.GetNomOeuvre() == nom) 
                {
                    return o;
                }
            
            }
            return null;
        }

        // Retourne vrai si l'Oeuvre dont le nom est passé en paramètre existe dans la salle, faux sinon.
        // (+ surcharge)
        public bool ExisteOeuvre(string nom)
        {
            foreach (Oeuvre o in lesOeuvres)
            {
                if (o.GetNomOeuvre() == nom)
                {
                    return true;
                }

            }
            return false;
        }
        public bool ExisteOeuvre(Oeuvre uneOeuvre)
        {
            foreach (Oeuvre o in lesOeuvres)
            {
                if (o.GetNomOeuvre() == uneOeuvre.GetNomOeuvre())
                {
                    return true;
                }

            }
            return false;
        }

        // INDEXEURS en LECTURE (=accès à(aux) oeuvre(s) de la salle)
        // * Sur le rang de l'OEUVRE dans la COLLECTION
        // * Sur le prix (retourne toutes les oeuvres dont le prix est <= à celui cherché)
        // * Sur la référence (objet) artiste(retourne toutes les oeuvres de l'artiste cherché)
        // * Sur le nom d'un artiste (retourne toutes les oeuvres de l'artiste cherché)

        // A ECRIRE (4 indexeurs)


        // Ajoute une Oeuvre dans la salle, 
        // Retourne vrai si l’ajout a eu lieu, faux si l'œuvre existe déjà.
        public bool AjouteOeuvre(Oeuvre uneOeuvre)
        {
            if (!ExisteOeuvre(uneOeuvre)) 
            {
                return true;
            }
            return false;
        }

        // Enlève une Oeuvre dans la salle.
        // Retourne vrai si le retrait a eu lieu, faux si l'œuvre n'existe pas.
        public bool RetireOeuvre(Oeuvre uneOeuvre)
        {
            if (ExisteOeuvre(uneOeuvre))
            {
                lesOeuvres.Remove(uneOeuvre);
                return true;
            }
            return false;
        }

        // Retourne la valeur totale des oeuvres stockées dans la salle
        public double ValeurSalle()
        {
            float total = 0F;
            foreach (Oeuvre_Achetee o in lesOeuvres)
            {
                total += o.GetPrixOeuvre();

            }
            return total;
        }

        // Retourne l’écart entre le montant de la valeur déclarée 
        // à l’assurance et la valeur des Oeuvres.
        // Lorsque la valeur de la salle est égale à ZERO
        // (=que des oeuvres prêtées) alors on retourne ZERO.
        public double Ecart()
        {
            float total;
            total = (float)ValeurSalle() - this.GetMontantAssurance(); 
            return total;
        }

        // Retourne l'ensemble des oeuvres devant faire l'objet d'une expertise
        public List<Oeuvre_Achetee> getLesOeuvresAExpertiser()
        {
            List<Oeuvre_Achetee> AExpertiser = new List<Oeuvre_Achetee>();
            foreach (Oeuvre_Achetee o in lesOeuvres)
            {
                if (o.estAExpertiser()) 
                {
                    AExpertiser.Add(o);
                }
            }
            return AExpertiser;
        }

        // Retourne une chaîne avec les caractéristiques de la salle 
        // (nom et montant de l’assurance) et des œuvres avec artiste.
        public override string  ToString()
        {
            string résultat = "";
            résultat += ("La Salle "+this.nomSalle);
            résultat += ("Contient des Oeuvre assurer pour un montant de " + this.montantAssurance + "$");
            return résultat;
        }
    }
    #endregion

    #region Classe MUSEE
    public class Musee
    {
        // Attributs
        private string monMusee;                // Nom du musée
        private List<Artiste> lesArtistes;      // Liste des artistes
        private List<Salle> lesSalles;          // Liste des salles
        private List<Oeuvre> lesOeuvres;        // Liste des oeuvres;

        // Constructeur : création d'un musée
        public Musee(string nom)
        {
            this.monMusee = nom;
            this.lesArtistes = new List<Artiste>();
            this.lesSalles = new List<Salle>();
            this.lesOeuvres = new List<Oeuvre>();
        }

        // Création d'une SALLE
        public string CreerSalle(Salle s)
        {
            Salle uneSalle = new Salle(s);
            lesSalles.Add(s);
            return "Salle ajouter avec succès";
        }

        // Création d'un ARTISTE
        public string CreerArtiste(Artiste a)
        {
            Artiste unArtiste = new Artiste(a);
            lesArtistes.Add(a);
            return "Artiste creer avec succès";
        }

        // Création d'une OEUVRE avec un ARTISTE et une SALLE
        // (+ surcharge : OEUVRE avec l'ARTISTE déjà défini)
        public string CreerOeuvre(Oeuvre o, Artiste a, Salle s)
        {
            Oeuvre oeuvre = new Oeuvre(o.GetNomOeuvre(), a);
            s.AjouteOeuvre(oeuvre);
            return null;
        }
        public string CreerOeuvre(Oeuvre o, Salle s)
        {
            Oeuvre oeuvre = new Oeuvre(o);
            s.AjouteOeuvre(o);
            return null;
        }

        // Accesseurs
        public List<Oeuvre> GetLesOeuvres()
        { return this.lesOeuvres; }
        public List<Salle> GetLesSalles()
        { return this.lesSalles; }
        public List<Artiste> GetLesArtistes()
        { return this.lesArtistes; }
        public Artiste GetArtiste(int i)
        {
            return this.lesArtistes[i];
        }
        public Oeuvre GetOeuvre(int i)
        {
            return this.lesOeuvres[i];
        }
        public Salle GetSalle(int i)
        {
            return this.lesSalles[i];
        }

        // Retourne une collection DICTIONNAIRE avec la liste des OEUVRES
        // devant faire l'objet d'une expertise.
        // Chaque élément est de la forme :
        //  * Clé : objet SALLE
        //  * Valeur associée : collection d'oeuvres à expertiser
        public Dictionary<Salle, List<Oeuvre_Achetee>> getLesExpertisesAFAire()
        {
            Dictionary<Salle, List<Oeuvre_Achetee>> dico = new Dictionary<Salle, List<Oeuvre_Achetee>>();
            List<Oeuvre_Achetee> LesOeuvresaExpertiser = new List<Oeuvre_Achetee>();
            // Boucle Erreur
            foreach (Salle s in this.lesSalles)
            {
                foreach (Oeuvre_Achetee o in this.lesOeuvres)
                {
                    if (o.estAExpertiser() == true)
                    {
                        LesOeuvresaExpertiser.Add(o);


                    }
                }
                dico.Add(s,LesOeuvresaExpertiser);
            }

            return dico;
        }

        // Formatte une chaîne avec les données du MUSEE
        public override string ToString()
        {
            string résultat = string.Format("\n***********************************\n");
            résultat += string.Format(" {0} \n", monMusee);
            résultat += string.Format("***********************************");

            
            foreach (Artiste a in lesArtistes) 
            {
                résultat += a.GetNomArtiste();
                résultat += string.Format("\n***********************************\n");
            }

            résultat += string.Format("\n***********************************\n");
            résultat += string.Format("Les Oeuvres");
            résultat += string.Format("\n***********************************\n");
            
            foreach (Oeuvre o in lesOeuvres) 
            {
                résultat += o.GetNomOeuvre();
                résultat += string.Format("\n***********************************\n");

            }

            résultat += string.Format("\n***********************************\n");
            résultat += string.Format("Les Salles");
            résultat += string.Format("\n***********************************\n");
            
            foreach (Salle s in lesSalles)
            {
                résultat += s.GetNomSalle();
                résultat += string.Format("\n***********************************\n");

            }

            return résultat;
        }
    }
    #endregion
}
