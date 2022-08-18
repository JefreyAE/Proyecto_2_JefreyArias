using Microsoft.AspNetCore.Mvc;

namespace Front_Proyecto_2.Helpers
{
    public interface IProtectionRoutesService
    {
        public bool ProtectAction();
    }
}
