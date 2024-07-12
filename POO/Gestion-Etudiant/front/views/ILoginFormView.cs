using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant.front.views
{
    public interface ILoginFormView
    {
        string Message { get; set; }
        string Login { get; set; }
        string Password { get; set; }

        event EventHandler ClickBtnConnexion;

        void HideForm();
    }
}
