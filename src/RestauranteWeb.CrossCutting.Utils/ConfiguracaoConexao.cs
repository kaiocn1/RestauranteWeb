namespace RestauranteWeb.CrossCutting.Utils
{
    public class ConfiguracaoConexao
    {
        private static ConfiguracaoConexao _singleton;
        private static string _stringConexao;
        private static string _execucaoTesteUnitario;

        private ConfiguracaoConexao() { }

        public bool ExecucaoTesteUnitario => _execucaoTesteUnitario == "1";
        public string StringConexao => _stringConexao;

        public static ConfiguracaoConexao Crie()
        {
            var chaveStringConexao = "ConexaoProducao";

#if DEBUG
            chaveStringConexao = "ConexaoDesenvolvimento";
#endif

            if (string.IsNullOrEmpty(_stringConexao))
            {
                var valor = ConfiguracaoAplicacao.ObterStringConexao(chaveStringConexao);
                _stringConexao = valor ?? @"para causar erro de conexao!!";
            }
            if (string.IsNullOrEmpty(_execucaoTesteUnitario))
            {
                _execucaoTesteUnitario = ConfiguracaoAplicacao.ObterConfiguracao("Ambiente:TesteUnitario");
            }

            return _singleton ?? (_singleton = new ConfiguracaoConexao());
        }
    }
}
