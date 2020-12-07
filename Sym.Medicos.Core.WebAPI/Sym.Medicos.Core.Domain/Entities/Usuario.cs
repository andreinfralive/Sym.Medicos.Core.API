namespace Sym.Medicos.Core.Domain.Entities
{
    public class Usuario : Entidade
    {
        public int IdUsuario { get; set; }

        public string NomeUsuario { get; set; }

        public string SobreNomeUsuario { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public bool EhAdministrador { get; set; }

        /// <summary>
        /// Validações
        /// </summary>
        public override void Validate()
        {
            if (string.IsNullOrEmpty(Email))
                AdicionarCritica("E-mail não informado.");

            if (string.IsNullOrEmpty(Senha))
                AdicionarCritica("Senha não foi informada.");
        }
    }
}
