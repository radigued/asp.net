using GestEcole.Web.Models.School;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace GestEcole.Web.Services
{
    public class SchoolService : BaseService<SchoolViewModel>, IService<SchoolViewModel>
    {
        /// <summary>
        /// Obtient le fichier xml de sauvegarde des écoles
        /// </summary>
        private static string FileName
        {
            get { return System.Web.HttpContext.Current.Server.MapPath("~/App_Data/school.xml"); }
        }

        /// <summary>
        /// Supprime une école
        /// </summary>
        /// <param name="id">Ecole à supprimer</param>
        public void Delete(int id)
        {
            List<SchoolViewModel> schools = GetAll().ToList();
            var foundStudent = schools.SingleOrDefault(std => std.Id == id);

            if (foundStudent != null)
                schools.Remove(foundStudent);

            // Sauvegarde
            Serialize(schools, FileName);
        }

        /// <summary>
        /// Obtient l'ensemble des écoles
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SchoolViewModel> GetAll()
        {
            if (!File.Exists(FileName))
                return new List<SchoolViewModel>();

            return Deserialize(FileName);
        }

        /// <summary>
        /// Obtient une école depuis sont id
        /// </summary>
        /// <param name="id">Identifiant de l'école</param>
        /// <returns></returns>
        public SchoolViewModel GetById(int id)
        {
            var schools = GetAll();
            return schools.SingleOrDefault(std => std.Id == id);
        }

        /// <summary>
        /// Sauvegarde une école
        /// </summary>
        /// <param name="obj"></param>
        public void Save(SchoolViewModel obj)
        {
            var schools = GetAll().OrderBy(std => std.Id).ToList();
            //if(!schools.Any(std => std.Id == obj.Id))
            if (!schools.Contains(obj))
            {
                // Gestion de l'incrément
                obj.Id = !schools.Any() ? 1 : schools.Max(std => std.Id) + 1;
                // Ajout de l'étudiant à la liste
                schools.Add(obj);
            }
            else
            {
                // Mise à jour de l'objet
                var existingSchool = schools.Single(std => obj.Equals(std));
                existingSchool.SchoolName = obj.SchoolName;
                existingSchool.Location = obj.Location;
                existingSchool.PostalCode = obj.PostalCode;
                existingSchool.City = obj.City;
            }

            Serialize(schools, FileName);
        }
    }
}
