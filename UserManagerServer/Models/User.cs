namespace UserManagerServer.Models
{
    public record User
    (
      int Id,
      string Username,
      string FirstName,
      string LastName,
      string Email,
      string Password);
}
