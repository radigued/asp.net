using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestEcole.Web.Models.Class
{
    public class ClassViewModel
    {
        #region Properties

        /// <summary>
        /// Affecte ou obtient l'identifiant de la classe
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Affecte ou obtient le nom de la classe
        /// </summary>
        [Display(Name = "Nom de la classe :")]
        [Required(ErrorMessage = "Le nom de la classe est requis")]
        [StringLength(20, ErrorMessage = "La longueur du nom de la classe ne doit pas excéder 20 caractères")]
        public string ClassName { get; set; }

        /// <summary>
        /// Affecte ou obtient le niveau de la classe
        /// </summary>
        [Display(Name = "Niveau de la classe :")]
        [Required(ErrorMessage = "Le niveau de la classe est requis")]
        [StringLength(20, ErrorMessage = "La longueur du nom de la classe ne doit pas excéder 20 caractères")]
        public string Grade { get; set; }


        /// <summary>
        /// Obtient l'identifiant
        /// </summary>
        public int School_id { get; set; }

        #endregion



    }
}