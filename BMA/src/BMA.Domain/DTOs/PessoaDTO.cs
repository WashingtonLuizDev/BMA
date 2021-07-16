namespace BMA.Domain.DTOs
{
    public class PessoaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; } = 0;
        public string Sexo { get; set; }
        public double Peso { get; set; }
        public double? Altura { get; set; }
        public bool Idoso => Idade >= 60;
    }
}