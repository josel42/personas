using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using personas.Models;

namespace personas.Controllers
{
    public class ImcController : Controller
    {
        // Lista estática para almacenar los datos temporalmente
        public static List<PersonaModel> personas = new List<PersonaModel>();

        // Acción GET para cargar la vista del formulario
        public IActionResult Index()
        {
            return View(new PersonaModel()); // Pasar un modelo vacío a la vista
        }

        // Acción POST para procesar el formulario
        [HttpPost]
        public IActionResult Index(PersonaModel model)
        {
            if (ModelState.IsValid)
            {
                personas.Add(model); // Agregar el modelo a la lista
                return RedirectToAction("Lista"); // Redirigir a la lista
            }

            return View(model); // Si hay errores, devolver la vista con los datos ingresados
        }

        // Acción para mostrar la lista de personas
        public IActionResult Lista()
        {
            return View(personas); // Pasar la lista de personas a la vista
        }
    }
}
