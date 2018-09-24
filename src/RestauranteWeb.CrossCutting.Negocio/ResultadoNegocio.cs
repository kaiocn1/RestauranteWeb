using System.Collections.Generic;

namespace RestauranteWeb.CrossCutting.Negocio
{
    public class ResultadoNegocio<T>
    {
        public bool Sucesso => DicionarioMensagens.Count == 0;
        public T Retorno { get; private set; }
        public Dictionary<string, List<string>> Mensagens => DicionarioMensagens;

        public ResultadoNegocio()
        {
            DicionarioMensagens = new Dictionary<string, List<string>>();
        }

        private Dictionary<string, List<string>> DicionarioMensagens { get; set; }

        public ResultadoNegocio<T> AdicioneErro(string mensagem)
        {
            AdicioneMensagem("Erro", mensagem);
            return this;
        }

        public ResultadoNegocio<T> AdicioneInconsistencia(string mensagem)
        {
            AdicioneMensagem("", mensagem);
            return this;
        }

        public ResultadoNegocio<T> AdicioneMensagem(string chave, string mensagem)
        {
            if (DicionarioMensagens == null)
            {
                DicionarioMensagens = new Dictionary<string, List<string>>();
            }

            if (!DicionarioMensagens.TryGetValue(chave, out var listaDeMesagens))
            {
                listaDeMesagens = new List<string>();
                DicionarioMensagens[chave] = listaDeMesagens;
            }

            if (listaDeMesagens.Contains(mensagem)) return this;

            listaDeMesagens.Add(mensagem);
            return this;
        }

        public ResultadoNegocio<T> TrateResultado(T resultado)
        {
            this.Retorno = resultado;
            return this;
        }
    }
}
