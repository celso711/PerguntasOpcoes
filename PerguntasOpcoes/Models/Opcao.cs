﻿namespace PerguntasOpcoes.Models
{
    public class Opcao
    {
        public int OpcaoID { get; set; }
        public string Texto { get; set; }
        public int OrdemExibicao { get; set; }
        public bool Ativa { get; set; }
        public Pergunta PerguntaSubsequente { get; set; }
    }
}
