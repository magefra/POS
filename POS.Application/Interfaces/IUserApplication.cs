using POS.Application.Base;
using POS.Application.Dtos.User.Request;

namespace POS.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<BaseResponse<bool>> RegisterUser(UserRequestDto requestDto);
        Task<BaseResponse<string>> GenerateToken(TokenRequestDto tokenDto);
    }
}
