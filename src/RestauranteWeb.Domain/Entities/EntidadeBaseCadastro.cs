using System;

namespace RestauranteWeb.Domain.Entities
{
    public abstract class EntidadeBaseCadastro<TChave> : EntidadeBase<TChave>
    {
        public byte StatusRegistro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public Guid UsuarioCriador { get; set; }
        public DateTime DataHoraInativacao { get; set; }
        public Guid UsuarioInativacao { get; set; }
    }
}
