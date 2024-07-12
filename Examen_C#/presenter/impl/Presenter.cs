using Examen_C_.back.data.dto;
using Examen_C_.back.data.entities;
using Examen_C_.back.services;
using Examen_C_.front;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_C_.presenter.impl
{
    public class Presenter : IPresenter
    {
        private readonly IFormView view;
        private readonly IClientService clientService;
        private readonly IArticleService articleService;
        private readonly ICommandeService commandeService;

        private BindingSource bindingSourceArticle;
        private List<ArticleDto> articlesDtos; // les articles commandés
        private Client clientSelected; // Client de la commande
        private Article articleSelected; // Article qu'il est en train d'ajouter
        private Commande commandeEnCours;
         
        public Presenter(IFormView view, IClientService clientService, IArticleService articleService, ICommandeService commandeService)
        {
            this.view = view;
            this.clientService = clientService;
            this.articleService = articleService;
            this.commandeService = commandeService;
            ActiveEventHandler();
            loadData();

            commandeEnCours = new Commande();
            articlesDtos = new List<ArticleDto>();
        }

        public void ActiveEventHandler()
        {
            view.ClickBtnAjouter += ClickBtnAjouterHandler;
            view.ClickBtnEnregistrer += ClickBtnEnregistrerHandler;
            view.SaisiePortable += SaisiePortableHandler;
            view.SaisieReference += SaisieReferenceHandler;
        }

        public void ClickBtnAjouterHandler(object sender, EventArgs e)
        {
            int qteCmde = view.QteCmde;
            if (qteCmde>0)
            {
                if (qteCmde > articleSelected.QteStock)
                {
                    MessageBox.Show("Stock insuffisant", "INfos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //Montant de l'article
                    double montant = articleSelected.Prix * qteCmde;
                    //Mise à jour stock
                    int stock = articleSelected.QteStock;
                    articleSelected.QteStock = (stock - qteCmde);
                    //Mettre article dans la commande
                    commandeEnCours.Articles.Add(articleSelected);
                    //Calculer le montant total du panier de commande
                    commandeEnCours.Montant += montant;
                    //Calculer la qteTotal Commandée
                    commandeEnCours.QteCmde += qteCmde;
                    //Envoyer le montant total ddu panier à la vue
                    view.Total = commandeEnCours.Montant;
                    //Ajouter l'article dans le panier de la vue
                    ArticleDto dto = new ArticleDto() 
                    {
                        Reference = articleSelected.Reference,
                        Libelle = articleSelected.Libelle,
                        Prix =  articleSelected.Prix,
                        Montant = montant,
                        QteCmde = qteCmde
                    };
                    articlesDtos.Add(dto);
                    loadData();
                    view.EnableBtnEnregistrer();
                }
            }
            else
            {
                MessageBox.Show("Veuillez choisir une quantité supérieure à zéro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ClickBtnEnregistrerHandler(object sender, EventArgs e)
        {
            if (clientSelected!=null)
            {
                try
                {
                    int id = commandeService.save(commandeEnCours);

                    if (id != 0)
                    {
                        MessageBox.Show("Commande enregistré avec succès", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erreur d'enregistrement", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception)
                {

                    MessageBox.Show("Erreur d'insertion de la commande", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez chosir le client", "INFOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void loadData()
        {
            bindingSourceArticle = new BindingSource();
            bindingSourceArticle.DataSource = articlesDtos;
            view.setCommandeBindingSource(bindingSourceArticle);
        }

        public void SaisiePortableHandler(object sender, EventArgs e)
        {
            string portable = view.Portable;
            if ( !string.IsNullOrEmpty(portable) && portable.Length >=4)
            {
                Client client = clientService.getClientByPortable(portable);
                if (client!=null)
                {
                    clientSelected = client; // Mettre ce client comme client de la commande
                    // Envoyer le nom et le prenom à la vue
                    view.Nom = client.Nom;
                    view.Prenom = client.Prenom;
                    
                    //Mettre le client à la commande
                    commandeEnCours.Client = clientSelected;
                }
                else
                {
                    clientSelected = null;
                    view.Nom = "";
                    view.Prenom = "";
                    
                }
            }
        }

        public void SaisieReferenceHandler(object sender, EventArgs e)
        {
            string reference = view.Reference;
            if (!string.IsNullOrEmpty(reference) && reference.Length >= 4)
            {
                Article article = articleService.getArticleByReference(reference);
                if (article != null)
                {
                    // Envoyer les informations de l'article à la vue
                    view.Libelle = article.Libelle;
                    view.Prix = article.Prix;
                    view.QteStock = article.QteStock;
                    articleSelected = article; // Mettre l'article comme article à ajouter au panier
                    // Article existe donc on active le btn ajouter
                    view.EnableBtnAjouter();
                }
                else
                {
                    articleSelected = null;
                    view.Libelle = "";
                    view.Prix = 0;
                    view.QteStock = 0;
                    // Article n'existe pas  on désactive le btn ajouter
                    view.DisableBtnAjouter();
                }
            }
        }
    }
}
