using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.presenter
{
    public interface IPagePresenter
    {
        void ShowClasseHandler(object sender, EventArgs e);
        void ShowCoursHandler(object sender, EventArgs e);
        void ShowModuleHandler(object sender, EventArgs e);
        void ShowProfesseurHandler(object sender, EventArgs e);
        void ShowSalleHandler(object sender, EventArgs e);
        void LogoutHandler(object sender, EventArgs e);
        void ActiveMenuEventHandler();
    }
}
