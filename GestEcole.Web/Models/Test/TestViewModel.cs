using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestEcole.Web.Models.Test
{
    public class TestViewModel
    {
        #region Properties

        /// <summary>
        /// Affecte ou obtient l'identifiant du professeur
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Affecte ou obtient le nom du devoir
        /// </summary>
        [Display(Name = "Nom du devoir :")]
        [Required(ErrorMessage = "Le nom du devoir est obligatoire")]
        [StringLength(30, ErrorMessage = "La longueur du nom du devoir doit-être de 30 caractères au maximum")]
        public string TestName { get; set; }

        /// <summary>
        /// Affecte ou obtient la date du devoir
        /// </summary>
        [Required(ErrorMessage = "La date du devoir est obligatoire")]
        public DateTime TestDate { get; set; }

        /// <summary>
        /// Affecte ou obtient l'identifiant du professeur
        /// </summary>
        public int TeacherId { get; set; }

        /// <summary>
        /// Obtien l'id de(s) classe(s) du professeur
        /// </summary>
        public int ClassId { get; set; }

        #endregion
    }
}