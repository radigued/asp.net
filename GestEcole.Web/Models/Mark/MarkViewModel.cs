using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestEcole.Web.Models.Mark
{
    public class MarkViewModel
    {

        #region Properties

        /// <summary>
        /// Affecte ou obtient l'identifiant de la note
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Affecte ou obtient la valeur de la note
        /// </summary>
        public decimal MarkValue { get; set; }

        /// <summary>
        /// Affecte ou obtient l'identifiant du devoir
        /// </summary>
        public int TestId { get; set; }

        #endregion

    }
}