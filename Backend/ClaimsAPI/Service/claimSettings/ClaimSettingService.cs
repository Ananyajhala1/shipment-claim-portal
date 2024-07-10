using ClaimsAPI.Models;
using ClaimsAPI.Models.DTO.ClaimSettingsDTO;
using ClaimsAPI.Models.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClaimsAPI.Service.claimSettings
{
    public class ClaimSettingService: IClaimSettings
    {
        private readonly ShipmentClaimsContext shipmentClaimsContext;
        public ClaimSettingService(ShipmentClaimsContext shipmentClaimsContext)
        {
            this.shipmentClaimsContext = shipmentClaimsContext;
        }

        public async Task<IEnumerable<ClaimSetting>> GetClaimSettings()
        {
            var claimSettings = await shipmentClaimsContext.ClaimSettings.ToListAsync();
            if (claimSettings == null)
            {
                return Enumerable.Empty<ClaimSetting>();
            }
            return claimSettings;
        }

        public async Task<ClaimSetting> GetClaimSettingById(int id)
        {
            var claimSetting = await shipmentClaimsContext.ClaimSettings.FirstOrDefaultAsync(x => x.SettingsId == id);
            if (claimSetting == null)
            {
                return null;
            }
            return claimSetting;
        }

        public async Task<ClaimSetting> PostClaimSetting(ClaimSettingsPostDTO claimSetting)
        {
            var claimsetting = new ClaimSetting()
            {
                ClaimId = claimSetting.ClaimId,
                CompanyId = claimSetting.CompanyId,
                DocId = claimSetting.DocId,
                IsRequired = claimSetting.IsRequired,
                Claim = claimSetting.Claim,
                Company = claimSetting.Company,
                Doc = claimSetting.Doc
            };
            shipmentClaimsContext.ClaimSettings.Add(claimsetting);
            await shipmentClaimsContext.SaveChangesAsync();
            return claimsetting;
        }

        public async Task<ClaimSetting> UpdateClaimSetting(int id, ClaimSettingsUpdateDTO claimSetting)
        {
            if (id != claimSetting.SettingsId)
            {
                throw new Exception("id didn't match");
            }
            var claimsetting =await shipmentClaimsContext.ClaimSettings.FirstOrDefaultAsync(x => x.SettingsId==id);
            if (claimsetting == null)
            {
                return null;
            }
            return claimsetting;
        }

        public async Task<ClaimSetting> DeleteClaimSetting(int id)
        {
            var claimSetting =await shipmentClaimsContext.ClaimSettings.FirstOrDefaultAsync(x => x.SettingsId == id);
            if (claimSetting == null)
            {
                return null;
            }
            shipmentClaimsContext.ClaimSettings.Remove(claimSetting);
            await shipmentClaimsContext.SaveChangesAsync();
            return claimSetting;
        }
    }
}
