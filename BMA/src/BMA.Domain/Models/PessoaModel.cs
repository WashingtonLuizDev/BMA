namespace BMA.Domain.Models
{
    public class PessoaModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; } = 0;

        public string Sexo { get; set; }

        public double Peso { get; set; }

        public double? Altura { get; set; }

        public bool Idoso { get; set; }
    }
}