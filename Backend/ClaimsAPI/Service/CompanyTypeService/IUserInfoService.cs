using ClaimsAPI.Models.ViewModels;
using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Service.UserInfoService;

public interface IUserInfoService

{



    Task<IList<GetUserInfoDTO>> GetUserInfo(int? pageNumber, int? pageSize);
    Task<IList<GetUserInfoDTO>> CompanyUsers(int cid);
    Task<GetUserInfoDTO> UserDetails(int userId);
    Task<CreateUserInfoDTO> CreateUser(CreateUserInfoDTO userInfoDTO);
    Task<UpdateUserInfoDTO> UpdateUser(UpdateUserInfoDTO userInfoDTO);
    Task<UpdateUserInfoDTO> DeleteUser(UpdateUserInfoDTO userInfoDTO);




}
