using ClaimsAPI.Models;

namespace ClaimsAPI.businessRulesValidator
{
    public class ClientValidatorBRule : BRuleBase
    {

        private readonly RequestTokenInfo _requestTokenInfo;
        private readonly ShipmentClaimsContext _shipmentClaimsContext;
        private int _clientid;


        public ClientValidatorBRule(ShipmentClaimsContext shipmentClaimsContext, int clientid, RequestTokenInfo requestTokenInfo) : base(shipmentClaimsContext)
        {

            _shipmentClaimsContext = shipmentClaimsContext;
            _clientid = clientid;
            _requestTokenInfo = requestTokenInfo;



        }

        public override bool Execute()
        {
          
             if(_clientid.ToString() != _requestTokenInfo.clientId)
            {
                this.error = "aupplied client id doesnt match with login user";
                return false;
            }

             else
            {
                return true;
            }

         }




    }
}
