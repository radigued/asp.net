using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestEcole.Web.Models.Teacher
{
    public class TeacherViewModel
    {

        #region Properties

        /// <summary>
        /// Affecte ou obtient l'identifiant du professeur
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Affecte ou obtient le nom de famille du professeur
        /// </summary>
        [Display(Name = "Nom de famille :")]
        [Required(ErrorMessage = "Le nom du professeur est obligatoire")]
        [StringLength(30, ErrorMessage = "La longueur du nom du professeur doit-être de 30 caractères au maximum")]
        public string TeacherName { get; set; }

        /// <summary>
        /// Affecte ou obtient le prénom du professeur
        /// </summary>
        [Display(Name = "Prénom :")]
        [StringLength(30, ErrorMessage = "La longueur du prénom du professeur doit-être de 30 caractères au maximum")]
        public string TeacherFirstName { get; set; }

        /// <summary>
        /// Affecte ou obtient la date de naissance du professeur
        /// </summary>
        public DateTime TeacherBirthDate { get; set; }


        #endregion

    }
}