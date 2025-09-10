using WorkSpace.Model;

namespace WorkSpace.Services
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
