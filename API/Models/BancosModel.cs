using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Bancos")]
    public class BancosModel
    {
        public string BancoCodigo { get; set; }
        public string BancoAgencia { get; set; }
        public string BancoAgenciaDig { get; set; }
        [Key]
        public string BancoConta { get; set; }
        public string BancoContaDig { get; set; }
        public string BancoNome { get; set; }
        public string BancoLiberado { get; set; }
    }
}
