using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;

        public AlunoController(SmartContext contex)
        {
            this._context = contex;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this._context.Alunos);
        }

        //http://localhost:5015/api/aluno/byId/1 faz parte da rota
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = this._context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }

        //http://localhost:5015/api/aluno/byName?name=Marta Usando queryString
        //http://localhost:5015/api/aluno/byName?nome=Felipe&sobrenome=Augusto
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = this._context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = this._context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null)
                return BadRequest("Aluno não encontrado");
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = this._context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null)
                return BadRequest("Aluno não encontrado");
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = this._context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
                return BadRequest("Aluno não encontrado");
            _context.Remove(aluno);
            _context.SaveChanges();
            return Ok();
        }
    }
}
