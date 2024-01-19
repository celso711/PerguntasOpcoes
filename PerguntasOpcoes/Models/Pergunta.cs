namespace PerguntasOpcoes.Models
{
    public class Pergunta
    {
        public int PerguntaID { get; set; }
        public int CategoriaID { get; set; }
        public string Texto { get; set; }
        public int TipoPergunta { get; set; }
        public int OrdemExibicao { get; set; }
        public bool Ativa { get; set; }
        public List<Opcao> Opcoes { get; set; } = new List<Opcao>();
    }
}
