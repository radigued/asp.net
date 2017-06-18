using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestEcole.Web.Models.Home
{
    public class LoginViewModel
    {

        #region Properties

        /// <summary>
        /// Affecte ou obtient le nom de l'utilisateur
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Affecte ou obtient le mot de passe de l'utilisateur
        /// </summary>
        public string Password { get; set; }

        #endregion

    }
}