using AuthServer.Core.DTOs;
using SharedLibrary.Dtos;
using System.Threading.Tasks;

namespace AuthServer.Core.Service
{
    public interface IUserService
    {
        //Geriye UserAppDto dönecek. CreateUserDto alacak.
        Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);

        Task<Response<UserAppDto>> GetUserByNameAsync(string userName);
    }
}
