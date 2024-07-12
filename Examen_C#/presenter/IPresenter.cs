using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_C_.presenter
{
    public interface IPresenter
    {
        void ClickBtnAjouterHandler(object sender, EventArgs e);
        void ClickBtnEnregistrerHandler(object sender, EventArgs e);
        void SaisiePortableHandler(object sender, EventArgs e);
        void SaisieReferenceHandler(object sender, EventArgs e);
        void ActiveEventHandler();
        void loadData();

    }
}
