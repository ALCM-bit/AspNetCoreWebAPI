using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        public List<Professor> Professores = new List<Professor>() {
            new Professor() { Id = 1, Nome = "Marcos"},
            new Professor() { Id = 2, Nome = "Jose"},
            new Professor() {Id = 3, Nome = "Mario"}
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Professores);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = Professores.FirstOrDefault(p => p.Id == id);
            if (professor == null) return BadRequest("Professor não encontrado");
            return Ok(professor);
        }
    }
}
