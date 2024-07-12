using Exam.back.data.entities;
using Exam.back.services;
using Exam.front;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam.presenter.impl
{
    public class ArticlePresenter : IArticlePresenter
    {
        private readonly IClientService clientService;
        private readonly IArticleService articleService;
        private readonly IFormView view;
        private Client clientSelected;
        private Article articleSelected;
        private BindingSource bindingSourceArticle = new BindingSource();
        private List<Article> articles;

        public ArticlePresenter(IClientService clientService, IArticleService articleService, IFormView view)
        {
            this.clientService = clientService;
            this.articleService = articleService;
            this.view = view;
            articles = new List<Article>();
            LoadData();
            ActiveEventHandler();
            this.view.ShowForm();
        }

        private void ActiveEventHandler()
        {
            view.ClickBtnAddEvent += ClickBtnAddHandler;
            view.ClickBtnEnregistrerEvent += ClickBtnEnregistrerHandler;
            view.SaisiePortableEvent += FiltreClientHandler;
            view.SaisieReferenceEvent += FiltreArticleHandler;
        }

        public void ClickBtnAddHandler(object sender, EventArgs e)
        {
            int qte = view.QteSaisie;
            if (qte!=0)
            {
                int qteStock = articleSelected.QteStock;
                int qteCmd = articleSelected.QteCmd;
                if (qte <= qteStock)
                {
                    articleSelected.QteStock = qteStock - qte;
                    articleSelected.QteCmd = qteCmd + qte;
                    view.QteStock = articleSelected.QteStock;
                    articleSelected.Montant += qte * articleSelected.Prix;

                    view.Total = CalculTotal();


                    if (articles.Contains(articleSelected))
                    {
                        articles.Remove(articleSelected);
                    }
                    articles.Add(articleSelected);
                    view.EnableBtnEnregistrer();

                    bindingSourceArticle.DataSource = this.articles;
                    MessageBox.Show("Article Ajoutée");
                }
                else
                {
                    MessageBox.Show("Quantité insuffisante");
                }
            }
        }

        public void ClickBtnEnregistrerHandler(object sender, EventArgs e)
        {
            if (clientSelected!=null)
            {
                if (articles != null && articles.Count > 0)
                {
                    int id = 0;
                    try
                    {
                        foreach (var art in articles)
                        {
                            id = articleService.update(art);
                        }

                        if (id != 0)
                        {
                            MessageBox.Show("Enregistrement Réussi", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("ERREUR D'Enregistrement", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("VEUILLEZ CHOISISR LE CLIENT", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FiltreArticleHandler(object sender, EventArgs e)
        {
            string reference = this.view.ReferenceSaisie;
            if (!string.IsNullOrEmpty(reference) && reference.Length >= 4)
            {
                Article article = articleService.getByReference(reference);

                if (article != null)
                {
                    articleSelected = article;
                    view.Prix = article.Prix;
                    view.Libelle = article.Name;
                    view.QteStock = article.QteStock;
                    this.view.EnableAdd();
                }
            }
        }

        public void FiltreClientHandler(object sender, EventArgs e)
        {
            string tel = this.view.PortableSaisi;
            if (!string.IsNullOrEmpty(tel) && tel.Length >= 4)
            {
                Client client = clientService.getByPortable(tel);

                if (client != null)
                {
                    clientSelected = client;
                    view.Nom = client.Nom;
                    view.Prenom = client.Prenom;
                    view.PortableSaisi = tel;
                }
            }
        }

        public void LoadData()
        {
            
            bindingSourceArticle.DataSource = this.articles;
            this.view.setArticleBindingSource(bindingSourceArticle);
        }

        private double CalculTotal()
        {
            double total = 0;
            foreach (var art in articles)
            {
                total += art.Montant;
            }
            return total;
        }
    }
}
