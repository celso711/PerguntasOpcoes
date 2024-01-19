using System.Collections.Generic;
using System.Threading.Tasks;
using PerguntasOpcoes.Models;
using PerguntasOpcoes.Repositories;

namespace PerguntasOpcoes.Services
{
    public class PerguntaService
    {
        private readonly IPerguntaRepository _perguntaRepository;
        private readonly IPerguntaOpcaoRepository _perguntaOpcaoRepository;
        private readonly IRelacaoOpcaoPerguntaRepository _relacaoOpcaoPerguntaRepository;
        private readonly IOpcaoRepository _opcaoRepository; 

        public PerguntaService(
            IPerguntaRepository perguntaRepository,
            IPerguntaOpcaoRepository perguntaOpcaoRepository,
            IRelacaoOpcaoPerguntaRepository relacaoOpcaoPerguntaRepository,
            IOpcaoRepository opcaoRepository)  
        {
            _perguntaRepository = perguntaRepository;
            _perguntaOpcaoRepository = perguntaOpcaoRepository;
            _relacaoOpcaoPerguntaRepository = relacaoOpcaoPerguntaRepository;
            _opcaoRepository = opcaoRepository;  
        }

        public async Task<Pergunta> GetPerguntaComOpcoesAsync(int perguntaId)
        {
            var pergunta = await _perguntaRepository.GetPerguntaByIdAsync(perguntaId);
            if (pergunta.TipoPergunta == 2)
            {
                await AssociarOpcoesEProcurarSubsequentes(pergunta);
            }
            return pergunta;
        }

        private async Task AssociarOpcoesEProcurarSubsequentes(Pergunta pergunta)
        {
            var todasOpcoes = await _opcaoRepository.GetAllAsync();
            var perguntasOpcoes = await _perguntaOpcaoRepository.GetAllAsync();
            var relacaoOpcaoPergunta = await _relacaoOpcaoPerguntaRepository.GetAllAsync();

            var opcoesIds = perguntasOpcoes
                .Where(po => po.PerguntaID == pergunta.PerguntaID)
                .Select(po => po.OpcaoID).ToList();

            pergunta.Opcoes = todasOpcoes.Where(o => opcoesIds.Contains(o.OpcaoID)).ToList();

            foreach (var opcao in pergunta.Opcoes)
            {
                var perguntaSubsequenteId = relacaoOpcaoPergunta
                    .FirstOrDefault(rop => rop.OpcaoID == opcao.OpcaoID)?.PerguntaSubsequenteID;

                if (perguntaSubsequenteId != null)
                {
                    var perguntaSubsequente = await _perguntaRepository.GetPerguntaByIdAsync(perguntaSubsequenteId.Value);
                    if (perguntaSubsequente != null && perguntaSubsequente.TipoPergunta == 2)
                    {
                        await AssociarOpcoesEProcurarSubsequentes(perguntaSubsequente);
                    }
                    opcao.PerguntaSubsequente = perguntaSubsequente;
                }
            }
        }

        public async Task<IEnumerable<Pergunta>> GetAllPerguntasAsync()
        {
            var perguntas = await _perguntaRepository.GetAllAsync();

            foreach (var pergunta in perguntas)
            {
                if (pergunta.TipoPergunta == 2)
                {
                    await AssociarOpcoesEProcurarSubsequentes(pergunta);
                }
            }

            return perguntas;
        }
    }
}
