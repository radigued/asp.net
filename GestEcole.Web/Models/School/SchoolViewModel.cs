using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestEcole.Web.Models.School
{
    public class SchoolViewModel : IComparable<SchoolViewModel>
    {
        #region Properties

        /// <summary>
        /// Affecte ou obtient l'identifiant de l'école
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Affecte ou obtient le nom de l'école
        /// </summary>
        [Display(Name = "Nom de l'école :")]
        [Required(ErrorMessage = "Le nom de l'école est obligatoire :")]
        public string SchoolName { get; set; }

        /// <summary>
        /// Affecte ou obtient la rue de l'école
        /// </summary>
        [Display(Name = "Adresse :")]
        [Required(ErrorMessage = "L'adresse est obligatoire")]
        public string Location { get; set; }

        /// <summary>
        /// Affecte ou obtient le code postal de la ville
        /// </summary>
        [Display(Name = "Code Postal :")]
        [Required(ErrorMessage = "Le code postal est obligatoire")]
        [MinLength(5, ErrorMessage = "Le code postal est erroné")]
        [MaxLength(5, ErrorMessage = "Le code postal est erroné")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Affecte ou obtient le nom de la ville
        /// </summary>
        [Display(Name = "Ville :")]
        [Required(ErrorMessage = "La ville est obligatoire")]
        public string City { get; set; }

        #endregion

        #region Methods

        public int CompareTo(SchoolViewModel other)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}