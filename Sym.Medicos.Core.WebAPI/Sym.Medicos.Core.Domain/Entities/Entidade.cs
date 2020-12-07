using System.Collections.Generic;
using System.Linq;

namespace Sym.Medicos.Core.Domain.Entities
{
    public abstract class Entidade
    {
        /// <summary>
        /// Propriedade do Tipo Lista
        /// </summary>
        private List<string> _mensagensValidacao { get; set; }

        /// <summary>
        /// Instânciando _mensagensValidacao sem necessidade de um Construtor
        /// </summary>
        private List<string> mensagemValidacao
        {
            get { return _mensagensValidacao ?? (_mensagensValidacao = new List<string>()); }
        }

        /// <summary>
        /// Limpar mensagem de validações realizadas
        /// </summary>
        protected void LimparMensagemValidacao()
        {
            mensagemValidacao.Clear();
        }

        /// <summary>
        /// Adicionar Critica de validações
        /// </summary>
        /// <param name="mensagem"></param>
        protected void AdicionarCritica(string mensagem)
        {
            mensagemValidacao.Add(mensagem);
        }

        /// <summary>
        /// Obter mensagens de validações
        /// </summary>
        /// <returns></returns>
        public string ObterMensagensValidacao()
        {
            return string.Join(". ", mensagemValidacao);
        }

        public abstract void Validate();

        /// <summary>
        /// Verifica de é valido a mensagem de validação
        /// </summary>
        public bool EhValido
        {
            get { return !mensagemValidacao.Any(); }
        }
    }
}
