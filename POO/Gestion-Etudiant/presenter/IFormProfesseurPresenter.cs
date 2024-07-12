using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant.presenter
{
    public interface IFormProfesseurPresenter
    {
        void LoadData();//charger les données de la vue
        void AjouterProfesseurHandler(object sender, EventArgs e);//sender : btn qui a appelé
        void SelectProfesseurHandler(object sender, EventArgs e);//sender : btn qui a appelé
        void EditProfesseurHandler(object sender, EventArgs e);
        void DeleteProfesseurHandler(object sender, EventArgs e);
        public void ActiveEventHandler();//Mapper le Handler à celui de la vue(invoke)
    }
}
