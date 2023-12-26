namespace Api_Inventario;

public class UserModel
{
    public int Id { get; set; }
    public string Nome { get; set; }    
    public string Email { get; set; }
    public string Password { get; set; }

    public DateTime CreatedAt { get; set; }

}
