﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.front.views
{
    public interface ILoginPage
    {
        string ErrorMessage { get; set; }
        string Login { get; set; }
        string Password { get; set; }

        event EventHandler ClickBtnConnexion;
    }
}
