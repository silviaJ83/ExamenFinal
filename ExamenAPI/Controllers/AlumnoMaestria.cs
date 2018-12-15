using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExamenAPI.Models;

namespace ExamenAPI.Controllers
{
    public class AlumnoMaestria
    {
        [Route("api/maestria")]
        [ApiController]
        public class TodoController : ControllerBase
        {
            private readonly AlumnoContext _context;

            public TodoController(AlumnoContext context)
            {
                _context = context;

                if (_context.Alumnos.Count() == 0)
                {

                    _context.Alumnos.Add(new Alumno { Nombre = "Item1" });
                    _context.SaveChanges();
                }
            }

            [HttpGet]
            public ActionResult<List<Alumno>> GetAll()
            {
                return _context.Alumnos.ToList();
            }

            [HttpGet("{id}", Name = "GetTodo")]
            public ActionResult<Alumno> GetById(long id)
            {
                var item = _context.Alumnos.Find(id);
                if (item == null)
                {
                    return NotFound();
                }
                return item;
            }

            [HttpPost]
            public IActionResult Create(Alumno item)
            {
                _context.Alumnos.Add(item);
                _context.SaveChanges();

                return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
            }

        }
    }
}
