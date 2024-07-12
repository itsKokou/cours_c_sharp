using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_C_.front
{
    public interface IFormView
    {
        string Portable {  get; set; }
        string Nom {  get; set; }
        string Prenom { get; set; }
        string Reference { get; set; }
        string Libelle { get; set; }
        double Prix { get; set; }
        int QteStock { get; set; }
        int QteCmde { get; set; }
        double Total { get; set; }

        event EventHandler ClickBtnAjouter;
        event EventHandler ClickBtnEnregistrer;
        event EventHandler SaisiePortable;
        event EventHandler SaisieReference;

        void EnableBtnAjouter();
        void DisableBtnAjouter();
        void EnableBtnEnregistrer();


        void setCommandeBindingSource(BindingSource listeArticle);

    }
}
