
namespace CirneSports.LojaVirtual.Dominio.Entidade
{
    public class EmailConfiguracoes
    {
        public bool UsarSsl = false;
        public string ServidorSmtp = "smtp.cirnesports.com.br";
        public int ServidorPorta = 587;
        public string Usuario = "cirnesports";
        public bool EscreverArquivo = false;
        public string PastaArquivo = @"c:\EnvioEmail";
        public string De = "atendimento@cirneesports.com.br";
        public string Para = "pedido@cirnesports.com.br";
    }
}
