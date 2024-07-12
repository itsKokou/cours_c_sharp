using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam.front
{
    public interface IFormView
    {
        double Total { get; set; }
        int QteSaisie { get; set; }
        string PortableSaisi {  get; set; }
        string ReferenceSaisie { get; set; }
        string Nom { get; set; }
        string Prenom { get; set; }
        double Prix { get; set; }
        string Libelle { get; set; }
        int QteStock { get; set; }


        event EventHandler SaisiePortableEvent;
        event EventHandler SaisieReferenceEvent;
        event EventHandler ClickBtnAddEvent;
        event EventHandler ClickBtnEnregistrerEvent;

        void EnableAdd();
        void DisableAdd();
        void EnableBtnEnregistrer();

        void ShowForm();

        void setArticleBindingSource(BindingSource articleCommandes);
    }
}
