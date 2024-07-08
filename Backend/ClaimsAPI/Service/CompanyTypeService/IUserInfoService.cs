using ClaimsAPI.Models.ViewModels;
using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Service.UserInfoService;

public interface IUserInfoService
{
     Task<IEnumerable<GetUserInfoDTO>>GetUserInfo(int? pageNumber, int? pageSize);
    Task<IEnumerable<GetUserInfoDTO>> CompanyUsers(int cid);
    Task<GetUserInfoDTO> UserDetails(int userId);
    Task<CreateUserInfoDTO> CreateUser(CreateUserInfoDTO userInfoDTO);
    Task<UpdateUserInfoDTO> UpdateUser(UpdateUserInfoDTO userInfoDTO);
    Task<UpdateUserInfoDTO> DeleteUser(UpdateUserInfoDTO userInfoDTO);




}
