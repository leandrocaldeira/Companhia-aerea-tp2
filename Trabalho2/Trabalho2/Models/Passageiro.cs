namespace Trabalho2.Models
{
    class Passageiro
    {
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string endereco { get; set; }
        public string telefone { get; set; }
        public string cpf { get; set; }
        public int status { get; set; } // 0 - Aguardando | 1 - Confirmado
    }
}
