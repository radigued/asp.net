using GestEcole.Web.Models.School;
using GestEcole.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestEcole.Web.Controllers
{
    public class SchoolController : BaseController
    {
        private static readonly SchoolService schoolService = new SchoolService();

        /// <summary>
        /// Affiche la vue par défaut
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var schools = schoolService.GetAll();

            return View(schools);
        }

        /// <summary>
        /// Affiche la vue d'ajout d'une école
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Add(int? id)
        {
            if (id.HasValue)
            {
                List<SchoolViewModel> schools = schoolService.GetAll().ToList();
                var school = schools.SingleOrDefault(std => std.Id == id);

                if (school == null)
                {
                    ViewBag.Error = $"Aucune école ne correspond à cet identifiant";
                }
                else
                {
                    return View(school);
                }
            }
            SchoolViewModel schoolNew = new SchoolViewModel();
            return View(schoolNew);
        }

        /// <summary>
        /// Créé en base de données de l'école
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns>Redirection vers la page Index</returns>
        public ActionResult Create(SchoolViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", viewModel);
            }
            else
            {
                schoolService.Save(viewModel);

                // Ajout de l'école à la session en cours
                //Schools.Add(viewModel);
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Action de suppression
        /// </summary>
        /// <param name="id">Identifiant de l'école à supprimer</param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var school = schoolService.GetById(id);

            if (school == null)
                ViewBag.Error = $"Aucune école ne correspond à l'id {id}";

            if (school != null)
            {
                schoolService.Delete(id);
            }

            return View("Index", schoolService.GetAll());
        }
    }
}