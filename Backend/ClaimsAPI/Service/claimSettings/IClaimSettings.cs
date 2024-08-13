using ClaimsAPI.Models.DTO.ClaimSettingsDTO;
using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Service.claimSettings
{
    public interface IClaimSettings
    {
        Task<IEnumerable<ClaimSetting>> GetClaimSettings();
        Task<ClaimSetting> GetClaimSettingById(int id);
        Task<ClaimSetting> PostClaimSetting(ClaimSettingsPostDTO claimSetting);
        Task<ClaimSetting> UpdateClaimSetting(int id, ClaimSettingsUpdateDTO claimSetting);
        Task<ClaimSetting> DeleteClaimSetting(int id);
    }
}
