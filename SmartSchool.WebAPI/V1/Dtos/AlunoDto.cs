using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.V1.Dtos
{
    public class AlunoDto
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public int Idade { get; set; }
        public DateTime DataIni { get; set; }
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; }
    }
}
