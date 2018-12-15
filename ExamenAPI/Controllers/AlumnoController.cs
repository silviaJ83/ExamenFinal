using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExamenAPI.Models;

namespace ExamenAPI.Controllers
{
    public class AlumnoController
    {
        [Route("api/[controller]")]
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

            [HttpPut("{id}")]
            public IActionResult Update(long id, Alumno item)
            {
                var todo = _context.Alumnos.Find(id);
                if (todo == null)
                {
                    return NotFound();
                }

                todo.IsComplete = item.IsComplete;
                todo.Nombre = item.Nombre;

                _context.Alumnos.Update(todo);
                _context.SaveChanges();
                return NoContent();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(long id)
            {
                var todo = _context.Alumnos.Find(id);
                if (todo == null)
                {
                    return NotFound();
                }

                _context.Alumnos.Remove(todo);
                _context.SaveChanges();
                return NoContent();

            }
        }
    }
}
