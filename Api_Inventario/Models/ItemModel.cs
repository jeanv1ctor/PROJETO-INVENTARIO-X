namespace Api_Inventario.Models
{
    public class ItemModel
    {

        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Descricao { get; set; }

        public int Quantidade { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
