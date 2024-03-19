using Microsoft.EntityFrameworkCore.Infrastructure;

namespace StartupNNTM
{
    internal class SystemConstants
    {
        public const string ConnectString = "Data Source=.;Initial Catalog=NNTM;Integrated Security=True;Encrypt=true;TrustServerCertificate=true;";
        public const string Token = "Token";
        public const string BaseAddress = "BaseAddress";
    }
}
