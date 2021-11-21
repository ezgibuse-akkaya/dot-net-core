using AuthServer.Core.Configuration;
using AuthServer.Core.DTOs;
using AuthServer.Core.Models;

namespace AuthServer.Core.Service
{
    public interface ITokenService
    {
        //UserApp alacak. TokenDto dönecek.
        TokenDto CreateToken(UserApp userApp);

        ClientTokenDto CreateTokenByClient(Client client);
    }
}
