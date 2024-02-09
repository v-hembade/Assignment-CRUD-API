using JwtRoleBase.Model;

namespace JwtRoleBase.Interfaces
{
    public interface IUserService
    {
        Task<List<Users>> GetUsersDetails();
        Task<Users> GetUser(string id);
        Task<Users> AddUser(Users user);
        Task<Users> UpdateUser(string id , Users user);
        Task<Users> DeleteUser(string id);

    }
}
