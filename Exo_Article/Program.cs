using Exo_Article;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

class Programm
{
    //attributs

    Collection<Article> _articles;

    //constructeur
    public Programm() {
        _articles = new Collection<Article>();
    }

    
    //Main, point d'entrée
    public static void Main()
    {

        Programm prog = new Programm();
       

        
        string choixString="";
        int choixInt = 0;

        string refArechercherString = "";
        int refArechercherINT = 0;

        string DesignationArti = "";
     

        string PrixArticString = "";
        float PrixArticIFloat = 0.00f;

        string refArticleAjoutString = "";
        int refArticleAjoutInt = 0;

        string ChoixAffString = "";
        string RefArtSupString = "";
        int RefArtSupInt = 0;

        string ChoixArtModifString = "";
        int ChoixArtModifInt = 0;

        string NewRefString = "";
        int NewRefInt = 0;
        string NewNomString = "";
      
        string NewPrixString = "";
        float NewPrixFloat = 0;

        string NomRecherche = "";
        string tmp_choix = "";

        string choixMinString = "";
        int choixMinInt = 0;

        string choixMaxString = "";
        int choixMaxInt = 0;

    //affichage Menu
    getkey1:
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Bonjour que souhaitez-vous faire?\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("     0)   Créer un article avec des valeurs par défaut");
        Console.WriteLine("     1)   Rechercher un article par référence");
        Console.WriteLine("     2)   Ajouter un article au stock en vérifiant l’unicité de la référence.");
        Console.WriteLine("     3)   Supprimer un article par référence.");
        Console.WriteLine("     4)   Modifier un article par référence.");
        Console.WriteLine("     5)   Rechercher un article par nom.");
        Console.WriteLine("     6)   Rechercher un article par intervalle de prix de vente.");
        Console.WriteLine("     7)   Afficher tous les articles.");
        Console.WriteLine("     8)   Quitter\n");

        choixString=Console.ReadLine();

        if (string.IsNullOrEmpty(choixString))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vous avez saisi une valeur nulle ou vide");
            Console.ForegroundColor = ConsoleColor.White;
            goto getkey1;
        }
        else
        {
            try
            {
               choixInt = int.Parse(choixString);
            }catch(FormatException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Veuillez saisir une valeur entre 0 et 8");
                Console.ForegroundColor = ConsoleColor.White;
                goto getkey1;
            }
            if ((choixInt < 0) || (choixInt > 8))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Veuillez saisir une valeur entre 0 et 8");
                Console.ForegroundColor = ConsoleColor.White;
                goto getkey1;
            }
        }

        //selon choixINt

        switch (choixInt)
        {


            case 0:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Vous avez choisi de créer un article avec des valeurs par défaut.");
                Article CreatedArticle=new Article();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Un article par défault vient d'être créé avec succes");
                Console.ForegroundColor = ConsoleColor.White;

                getkey2:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Souhaitez-vous afficher les informations de l'article créé? (O/N)");
                ChoixAffString = Console.ReadLine();
                if (string.IsNullOrEmpty(ChoixAffString)) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Je n'ai pas compris votre choix");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto getkey2;
                }
                else
                {
                    ChoixAffString = ChoixAffString.ToUpper();
                 
                    if ((ChoixAffString != "O") && (ChoixAffString != "N")) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Je n'ai pas compris votre choix");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto getkey2;
                    }
                    else { 
                    if (ChoixAffString == "O")
                    {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Voici les informations liés à l'article créé précédement: ");
                            Console.WriteLine(CreatedArticle.ToString());
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Penser à l'ajouter au stock...\n");
                            Console.ForegroundColor = ConsoleColor.White;

                          
                    }
                    }

                }


                break;

            case 1:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Vous avez choisi de rechercher un article par référence.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Veuillez indiquer la référence de l'objet recherché (ex:1234) ");
                Console.ForegroundColor = ConsoleColor.White;
                refArechercherString=Console.ReadLine();


                if (string.IsNullOrEmpty(refArechercherString))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Saisie incorrecte\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto case 1;

                }
                else
                {
                    try
                    {
                        refArechercherINT = int.Parse(refArechercherString);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("réf a rechercher : " + refArechercherINT);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch(FormatException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Saisie incorrecte\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case 1;
                    }
                
                    if (prog.RechercherParRef(refArechercherINT)){
                        Console.ForegroundColor= ConsoleColor.Green;
                        Console.WriteLine("Saisie trouvée au moins une fois\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        getkey3:
                        Console.WriteLine("Souhaitez-vous afficher la ou les correspondances (O/N) ?");
                        string ChoixCorres=Console.ReadLine();

                        if (string.IsNullOrEmpty(ChoixCorres))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Je n'ai pas compris votre choix");
                            Console.ForegroundColor = ConsoleColor.White;
                            goto getkey3;

                        }else
                            ChoixCorres=ChoixCorres.ToUpper();

                        if ( (ChoixCorres!="O") && (ChoixCorres!="N") )
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Je n'ai pas compris votre choix");
                            Console.ForegroundColor = ConsoleColor.White;
                            goto getkey3;
                        }else if(ChoixCorres=="O")
                        {

                            foreach (var item in prog._articles)
                            {
                                if(item.Ref== refArechercherINT)
                                {
                                    Console.ForegroundColor = (ConsoleColor)ConsoleColor.Green;
                                    Console.WriteLine(item.Ref.ToString()+" "+item.Nom.ToString() + " "+item.PrixVente.ToString());
                                    Console.ForegroundColor = ConsoleColor.White;   
                                }
                            }
                        }




                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Référence introuvable\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                  
                }


                break;

                case 2:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Vous avez choisi d'ajouter un article au stock en vérifiant l'unicité de la réf.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Veuillez renseigner la désignation de l'article, son prix de vente ainsi que la référence.");
                Console.WriteLine("Désignation de l'article : ");
                DesignationArti=Console.ReadLine();
                if (string.IsNullOrEmpty(DesignationArti))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erreur de saisie , veuillez recommencer");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto case 2;
                }
              
                Console.WriteLine("Prix de l'article : \n");
                PrixArticString=Console.ReadLine();
                if (string.IsNullOrEmpty(PrixArticString)) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erreur de saisie , veuillez recommencer");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto case 2;
                }
                else { 
                try
                {
                    PrixArticIFloat = float.Parse(PrixArticString);

                }catch(FormatException e) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Erreur de saisie , veuillez recommencer");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case 2;
                }
                Console.WriteLine("Veuillez saisir la référence de l'article ( ex: 123) ");
                    refArticleAjoutString = Console.ReadLine();
                    if (string.IsNullOrEmpty(refArticleAjoutString))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Erreur de saisie , veuillez recommencer");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case 2;

                    }
                    else
                    {
                        try
                        {
                           refArticleAjoutInt = int.Parse(refArticleAjoutString);
                        }catch(FormatException e)
                        {
                            Console.WriteLine(e.ToString());
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Erreur de saisie , veuillez recommencer");
                            Console.ForegroundColor = ConsoleColor.White;
                            goto case 2;
                        }
                        if (prog.RechercherParRef(refArticleAjoutInt))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("une référence de cet article existe déjà");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("référence introuvable, l'article vient donc d'être ajouté au stock!!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Article articleAdd = new Article();
                            articleAdd.Ref = refArticleAjoutInt;
                            articleAdd.Nom = DesignationArti;
                            articleAdd.PrixVente = PrixArticIFloat;

                            prog._articles.Add(articleAdd);
                        

                        }

                    }


                }

                break;

                case 3:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Vous avez choisi de supprimer un article par référence ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Merci de saisir la référence de l'article à supprimer");
              RefArtSupString=Console.ReadLine();

                if (string.IsNullOrEmpty(RefArtSupString))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Vous avez saisi une valeur nulle ou vide");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto case 3;


                }else
                    try
                    {
                        RefArtSupInt = int.Parse(RefArtSupString);
                    }catch(FormatException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Erreur de saisie , veuillez recommencer");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case 3;

                    }

                if (prog.RechercherParRef(RefArtSupInt))
                {
                    if (prog.SupprimerParef(RefArtSupInt))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Article supprimé avec succes");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Echec de la suppression");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("référence introuvable");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                break;

            case 4:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Vous avez choisi de modifier un article par référence.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Veuillez saisir la référence de l'article à modifier.");
                ChoixArtModifString=Console.ReadLine();

                if (string.IsNullOrEmpty(ChoixArtModifString))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erreur de saisie , veuillez recommencer");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto case 4;

                }
                else
                {
                    try
                    {
                        ChoixArtModifInt = int.Parse(ChoixArtModifString);
                    }catch (FormatException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Erreur de saisie , veuillez recommencer");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case 4;
                    }
                }

                if (prog.RechercherParRef(ChoixArtModifInt))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("article trouvé");
                    Console.ForegroundColor = ConsoleColor.White;
                getkey4:
                    Console.WriteLine("Veuillez renseigner la nouvelle référence (ex: 123) ");
                    NewRefString=Console.ReadLine();

                    if (string.IsNullOrEmpty(NewRefString))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Erreur de saisie , veuillez recommencer");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto getkey4;
                    }
                    else
                    {
                        try
                        {
                            NewRefInt = int.Parse(NewRefString);
                        }catch(FormatException e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Erreur de saisie , veuillez recommencer");
                            Console.ForegroundColor = ConsoleColor.White;
                            goto getkey4;

                        }
                    }
                    getkey5:
                    Console.WriteLine("Veuillez renseigner la nouvelle désignation de l'article ");
                    NewNomString = Console.ReadLine();
                    if (string.IsNullOrEmpty(NewNomString))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Erreur de saisie , veuillez recommencer");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto getkey5;
                    }

                    getkey6:
                    Console.WriteLine("Veuillez saisir le nouveau prix");
                    NewPrixString= Console.ReadLine();

                    if (string.IsNullOrEmpty(NewPrixString))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Erreur de saisie , veuillez recommencer");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto getkey6;

                    }
                    else
                    {
                        try
                        {
                            NewPrixFloat = float.Parse(NewPrixString);
                           
                        }
                        catch (FormatException e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Erreur de saisie , veuillez recommencer");
                            Console.ForegroundColor = ConsoleColor.White;
                            goto getkey6;
                        }
                    }


                    Console.ForegroundColor = ConsoleColor.Green;
                    prog.ModifierArticle(NewRefInt,NewNomString, NewPrixFloat, ChoixArtModifInt);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Référence introuvable, désolé");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                break;

            case 5:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Vous avez choisi de rechercher un article par son nom.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Veuillez saisir le nom de l'article à rechercher");
                NomRecherche=Console.ReadLine();

                if (string.IsNullOrEmpty(NomRecherche))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erreur de saisie , veuillez recommencer");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto case 5;
                }
                else if(prog.RechercherParNom(NomRecherche))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Nom d'article trouvé au moin une fois\n");
                    Console.ForegroundColor = ConsoleColor.White;
                   
                    getkey6:
                    Console.WriteLine("Souhaitez-vous afficher les informations de l'article ? (O/N)");
                    tmp_choix=Console.ReadLine();

                    if (string.IsNullOrEmpty(tmp_choix))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Erreur de saisie , veuillez recommencer");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto getkey6;
                    }
                    else
                    {
                        tmp_choix = tmp_choix.ToUpper();
                        if ((tmp_choix != "O") && (tmp_choix != "N"))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Erreur de saisie , veuillez recommencer");
                            Console.ForegroundColor = ConsoleColor.White;
                            goto getkey6;

                        }
                        else if (tmp_choix == "O")
                        {

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Voici les informations liés à l'article créé précédement: ");

                            foreach (var item in prog._articles)
                            {
                                if (item.Nom == NomRecherche)
                                {
                                    Console.ForegroundColor = (ConsoleColor)ConsoleColor.Green;
                                    Console.WriteLine(item.Ref.ToString() + " " + item.Nom.ToString() + " " + item.PrixVente.ToString());
                                    Console.ForegroundColor = ConsoleColor.White;
                                }

                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                    }


                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nom introuvable");
                    Console.ForegroundColor = ConsoleColor.White;
                }


                break;

            case 6:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Vous avez choisi de rechercher un article par intervalle de prix de vente.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("veuillez saisir un prix de vente MINIMUN");
                choixMinString = Console.ReadLine();
                if(string.IsNullOrEmpty(choixMinString))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erreur de saisie , veuillez recommencer");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto case 6;

                }
                else
                {
                    try
                    {
                        choixMinInt = int.Parse(choixMinString);
                    }catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Erreur de saisie , veuillez recommencer");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case 6;
                    }
                    if (choixMinInt < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("La valeur MINIMUN doit être supérieur à 0");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case 6;
                    }
                    else
                    {
                        getkey7:
                        Console.WriteLine("veuillez saisir un prix de vente MAXIMUN");
                        choixMaxString = Console.ReadLine();
                        if (string.IsNullOrEmpty(choixMaxString))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Erreur de saisie , veuillez recommencer");
                            Console.ForegroundColor = ConsoleColor.White;
                            goto getkey7;

                        }
                        else
                        {
                            try
                            {
                                choixMaxInt = int.Parse(choixMaxString);
                            }
                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Erreur de saisie , veuillez recommencer");
                                Console.ForegroundColor = ConsoleColor.White;
                                goto case 6;
                            }
                            if( (choixMaxInt < 0) || (choixMaxInt < choixMinInt))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("La valeur maximun ne peut être inférieur à la valeur maximun ou à 0");
                                Console.ForegroundColor = ConsoleColor.White;
                                goto getkey7;

                            }
                            else
                            {
                               Console.WriteLine(prog.afficheInterval(choixMinInt, choixMaxInt));

                            }
                           
                        }

                        }
                }

                break;

            case 7:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Vous avez choisi l'affichage de tous les articles.");
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine(prog.afficheALL());
                Console.ForegroundColor = ConsoleColor.White;
                break;

            case 8:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Au revoir");
                 Environment.Exit(0);
                break;

        }
        goto getkey1;
    }

    public bool  RechercherParRef(int _ref)
    {
        bool find = false;
        int compteur = 0;

        try {

                foreach (Article article in _articles)
                {
                    if(article.Ref == _ref)
                {
                    compteur += 1;
                }

                }

                     if(compteur > 0)
                         {
                            find= true;
                         }
                            else
                                 {
                                    find=false;
                                  }
       

       
        }catch (FormatException e) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("liste vide actuellement");
            Console.ForegroundColor = ConsoleColor.White;
        }
        return find;
    }

    public bool SupprimerParef(int _ref)
    {
        bool sup = false;

        foreach (Article item in this._articles.ToList())
        {
            if(item.Ref == _ref)
            {
                this._articles.Remove(item); 
                sup= true;
            }
        }


        return sup;
    }

    public void ModifierArticle(int _ref,string _nom,float _prix,int lastref)
    {
       
        foreach (Article item in this._articles.ToList())
        {
            if (item.Ref == lastref)
            {
                item.Ref = _ref;
                item.Nom = _nom;
                item.PrixVente = _prix;
                Console.WriteLine("modification effectuée");

            }
        }
    }

    public bool RechercherParNom(string _nom)
    {
        bool find = false;
        int compteur = 0;

        try
        {
            foreach (Article article in _articles)
            {
                if (article.Nom == _nom)
                {
                    compteur += 1;
                }
            }

            if (compteur > 0)
            {
                find = true;
            }
            else
            {
                find = false;
            }



        }
        catch (FormatException e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("liste vide actuellement");
            Console.ForegroundColor = ConsoleColor.White;
        }
        return find;
    }

    public string afficheInterval(int min,int max)
    {
        string mes = "";
      

  

        if (this._articles.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            mes="il y a actuellement 0 article en stock, veuillez en ajouter (saisir 2 au menu principale)";
        }
        else
        {
            foreach (Article item in this._articles)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if ((item.PrixVente >= min) && (item.PrixVente <= max)){ 
                mes += "Nom de l'article : " + item.Nom + "\nReférence de l'article: " + item.Ref + "\nPrix de l'article: " + item.PrixVente + "\n\n";
                   
                }
        
            }

        }
        return mes;

    }



    public string afficheALL()
    {
        string mes = "";


        if(this._articles.Count == 0)
        {
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("il y a actuellement 0 article en stock, veuillez en ajouter (saisir 2 au menu principale)");
        }
        else { 
        foreach (Article item in this._articles.ToList())
        {
                mes+= "Nom de l'article : "+item.Nom+"\nReférence de l'article: "+item.Ref+"\nPrix de l'article: "+item.PrixVente+"\n\n";
        }
        }

        return mes;
    }

}