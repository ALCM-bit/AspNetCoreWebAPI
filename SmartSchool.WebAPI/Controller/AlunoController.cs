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
        public readonly IRepository _repo;

        public AlunoController(SmartContext contex, IRepository repo)
        {
            this._repo = repo;
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
            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não cadastrado");
            
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = this._context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null)
                return BadRequest("Aluno não encontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não Atualizado");
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = this._context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null)
                return BadRequest("Aluno não encontrado");
            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não Atualizado");
        }

        

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = this._context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
                return BadRequest("Aluno não encontrado");

            _repo.Delete(aluno);
            if (_repo.SaveChanges())
            {
                return Ok("Aluno deletado");
            }
            return BadRequest("Aluno não Deletado");
        }
    }
}
