using Microsoft.AspNetCore.Mvc;

namespace Front_Proyecto_2.Helpers
{
    public class ProtectionRoutesService:IProtectionRoutesService
    {
        private string token = TokenKeeper.Token;
        public ProtectionRoutesService()
        {

        }

        public bool ProtectAction()
        {
            if(this.token == null)
            {
                return false;  
            }

            return true;
        }
    }
}
