namespace Api_Inventario.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public IList<UserModel> Users { get; set; }
    }
}
