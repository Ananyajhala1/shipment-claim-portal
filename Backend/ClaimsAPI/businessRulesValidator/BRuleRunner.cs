namespace ClaimsAPI.businessRulesValidator
{
    public class BRuleRunner
    {

        IList<string> Errors = new List<string>();



        private IList<BRuleBase> _Brules;


        public BRuleRunner(IList<BRuleBase> bRules)
        {
            _Brules = bRules;
        }



       public void ExecuteRules()
        {
            foreach ( var Brule in _Brules)
            {
                if (!Brule.Execute())
                {
                    Errors.Add(Brule.error);
                }

            }
        }



        public bool hasError(string error)
        {
            if(Errors != null && Errors.Count>0 )
            {
                return true;
            }

            else
            {
                return false;
            }
        }


        public IList<string> getErrorList()
        {

            return Errors;

        }











    }
}
