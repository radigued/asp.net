﻿using GestEcole.Web.Models.Student;
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
    public class StudentService : BaseService<StudentViewModel>, IService<StudentViewModel>
    {
        /// <summary>
        /// Obtient le fichier xml de sauvegarde des étudiants
        /// </summary>
        private static string FileName
        {
            get { return System.Web.HttpContext.Current.Server.MapPath("~/App_Data/students.xml"); }
        }

        /// <summary>
        /// Supprime un étudiant
        /// </summary>
        /// <param name="id">Etudiant à supprimer</param>
        public void Delete(int id)
        {
            List<StudentViewModel> students = GetAll().ToList();
            var foundStudent = students.SingleOrDefault(std => std.Id == id);

            if (foundStudent != null )
                students.Remove(foundStudent);

            // Sauvegarde
            Serialize(students, FileName);
        }

        /// <summary>
        /// Obtient l'ensemble des étudiants
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StudentViewModel> GetAll()
        {
            if (!File.Exists(FileName))
                return new List<StudentViewModel>();

            return Deserialize(FileName);
        }

        /// <summary>
        /// Obtient un étudiant depuis sont id
        /// </summary>
        /// <param name="id">Identifiant de l'étudiant</param>
        /// <returns></returns>
        public StudentViewModel GetById(int id)
        {
            var students = GetAll();
            return students.SingleOrDefault(std => std.Id == id);
        }
        
        /// <summary>
        /// Sauvegarde un étudiant
        /// </summary>
        /// <param name="obj"></param>
        public void Save(StudentViewModel obj)
        {
            var students = GetAll().OrderBy(std => std.Id).ToList();
            //if(!students.Any(std => std.Id == obj.Id))
            if (!students.Contains(obj))
            {
                // Gestion de l'incrément
                obj.Id = !students.Any() ? 1 : students.Max(std => std.Id) + 1;
                // Ajout de l'étudiant à la liste
                students.Add(obj);
            }
            else
            {
                // Mise à jour de l'objet
                var existingStudent = students.Single(std => obj.Equals(std));
                existingStudent.StudentBirthDate = obj.StudentBirthDate;
                existingStudent.StudentFirstName = obj.StudentFirstName;
                existingStudent.StudentName = obj.StudentName;
            }

            Serialize(students, FileName);
        }
    }
}
