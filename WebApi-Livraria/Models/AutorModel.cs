using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi_Livraria.Models
{
    public class AutorModel
    {      
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Sobrenome { get; set; } = null!;

        [JsonIgnore]        
        public ICollection<LivroModel> Livros { get; set; } = null!;

    }
}
