﻿using System;
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
            // A COMPLETER
        }
        public Oeuvre(Oeuvre o)
        {
            // A COMPLETER
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
            // A COMPLETER
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
            this.SetPrixOeuvre(prix);
            this.dateAchat = achat;
            this.dateDerniereExpertise = expertise;
            this.etat = etat;

        }
        public Oeuvre_Achetee(string nom, float prix, Etat_Oeuvre etat) : base(nom)  //  Date achat et Date expertise = Date courante
        {
            this.SetNomOeuvre(nom);
            this.SetPrixOeuvre(prix);
            this.etat = etat;
        }
        public Oeuvre_Achetee(string nom, float prix, DateTime achat, DateTime expertise, Etat_Oeuvre etat, Artiste a) : base(nom, a)
        {
            this.SetNomOeuvre(nom);
            this.SetPrixOeuvre(prix);
            this.dateAchat = achat;
            this.dateDerniereExpertise = expertise;
            this.etat = etat;
            this.SetArtiste(a);
        }
        public Oeuvre_Achetee(Oeuvre o) : base(o)
        {

            this.SetNomOeuvre(o.GetNomOeuvre());
            this.SetArtiste(o.GetArtiste());
            this.aExpertiser = true;
            this.prixOeuvre = 0.0F;
            this.dateAchat = DateTime.Now;
            this.dateDerniereExpertise = DateTime.Now;
            this.etat = null;
        }

        // Accesseurs
        public float GetPrixOeuvre()
        { return this.prixOeuvre; }
        public void SetPrixOeuvre(float prix)
        { this.prixOeuvre = prix; }

        // Méthode permettant de savoir si une oeuvre est à expertiser.
        public bool estAExpertiser()
        {
            DateTime expiryDate = dateDerniereExpertise.AddDays(30);
            if (DateTime.Now > expiryDate)
            {
                return true;
            }
            return false;
        }

        // Formatage une chaine avec les informations de l'oeuvre
        // A COMPLETER
        public new string ToString()
        {
            string aRetourner = "";
            aRetourner += string.Format("\n\tAchetée le {0} et expertisée le {1}\n", this.dateAchat.ToShortDateString(), this.dateDerniereExpertise.ToShortDateString());
            aRetourner += string.Format("\tEtat {0}\n", this.etat.getLibelleEtatOeuvre());
            aRetourner += string.Format("\tPour {0} euros\n", this.prixOeuvre);

            return aRetourner;
        }
    }
    #endregion

    #region Classe OEUVRE PRETEE
    public class Oeuvre_Pretee
    {
        // Attribut spécifique
        private string preteur;
        private DateTime date_debut;
        private DateTime date_fin;

        // Constructeur (+surcharges)
        // Pour la dernière surcharge : 
        //  * Les dates seront initialisées à la date courante
        //  * Le prêteur sera initialisé à "inconnu"
        public Oeuvre_Pretee(string nom, string preteur, DateTime debut, DateTime fin)
        {
            // A COMPLETER
        }
        public Oeuvre_Pretee(string nom, string preteur, DateTime debut, DateTime fin, Artiste a)
        {
            // A COMPLETER
        }
        public Oeuvre_Pretee(Oeuvre o)
        {
            // A COMPLETER
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
            // A COMPLETER
        }

        // Formatage une chaine avec les informations de l'oeuvre
        // A COMPLETER
        public string ToString()
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
            this.nomSalle = s.GetNomSalle();
            this.montantAssurance = s.GetMontantAssurance();
            this.lesOeuvres = new List<Oeuvre>();
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
            foreach (Oeuvre o in this.lesOeuvres)
            {
                if (o.GetNomOeuvre().Equals(nom))
                {
                    return o;
                }
            } return null;
        }

        // Retourne vrai si l'Oeuvre dont le nom est passé en paramètre existe dans la salle, faux sinon.
        // (+ surcharge)
        public bool ExisteOeuvre(string nom)
        {
            if (nom != null)
            {
                foreach (Oeuvre o in this.lesOeuvres)
                {
                    if (o.GetNomOeuvre().Equals(nom))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool ExisteOeuvre(Oeuvre uneOeuvre)
        {
            if (uneOeuvre != null)
            {
                foreach (Oeuvre o in this.lesOeuvres)
                {
                    if (o.GetNomOeuvre().Equals(uneOeuvre.GetNomOeuvre()))
                    {
                        return true;
                    }
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
            // A COMPLETER
            return true;
        }

        // Enlève une Oeuvre dans la salle.
        // Retourne vrai si le retrait a eu lieu, faux si l'œuvre n'existe pas.
        public bool RetireOeuvre(Oeuvre uneOeuvre)
        {
            // A COMPLETER
            return true;
        }

        // Retourne la valeur totale des oeuvres stockées dans la salle
        public double ValeurSalle()
        {
            
            return 0F;
        }

        // Retourne l’écart entre le montant de la valeur déclarée 
        // à l’assurance et la valeur des Oeuvres.
        // Lorsque la valeur de la salle est égale à ZERO
        // (=que des oeuvres prêtées) alors on retourne ZERO.
        public double Ecart()
        {
            // A COMPLETER
            return 0F;
        }

        // Retourne l'ensemble des oeuvres devant faire l'objet d'une expertise
        public List<Oeuvre_Achetee> getLesOeuvresAExpertiser()
        {
            // A COMPLETER
            return null;
        }

        // Retourne une chaîne avec les caractéristiques de la salle 
        // (nom et montant de l’assurance) et des œuvres avec artiste.
        public override string  ToString()
        {
            string résultat = "";
            résultat += "********** Salle " + this.GetNomSalle() + " **********\n"
                + "Montant de l'assurance\n\n";
            foreach (Oeuvre o in this.lesOeuvres)
            {
                résultat += o.ToString() + " : " + o.GetArtiste().ToString();
            }
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
            this.lesSalles.Add(s);
            return null;
        }

        // Création d'un ARTISTE
        public string CreerArtiste(Artiste a)
        {
            this.lesArtistes.Add(a);
            return null;
        }

        // Création d'une OEUVRE avec un ARTISTE et une SALLE
        // (+ surcharge : OEUVRE avec l'ARTISTE déjà défini)
        public string CreerOeuvre(Oeuvre o, Artiste a, Salle s)
        {
            o.SetArtiste(a);
            return null;
        }
        public string CreerOeuvre(Oeuvre o, Salle s)
        {
            
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
            // A COMPLETER
            return null;
        }
        public Oeuvre GetOeuvre(int i)
        {
            
            return null;
        }
        public Salle GetSalle(int i)
        {
            // A COMPLETER
            return null;
        }

        // Retourne une collection DICTIONNAIRE avec la liste des OEUVRES
        // devant faire l'objet d'une expertise.
        // Chaque élément est de la forme :
        //  * Clé : objet SALLE
        //  * Valeur associée : collection d'oeuvres à expertiser
        public Dictionary<Salle, List<Oeuvre_Achetee>> getLesExpertisesAFAire()
        {
            // A COMPLETER
            return null;
        }

        // Formatte une chaîne avec les données du MUSEE
        public override string ToString()
        {
            string résultat = string.Format("\n***********************************\n");
            résultat += string.Format(" {0} \n", monMusee);
            résultat += string.Format("***********************************");

            // A COMPLETER

            // Liste des ARTISTES


            // Liste des OEUVRES


            // Liste et détail des SALLES


            return résultat;
        }
    }
    #endregion
}
