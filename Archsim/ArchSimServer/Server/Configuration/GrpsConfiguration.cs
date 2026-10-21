namespace Archsim.Server.Configuration;

public static class GrpsConfiguration
{
    extension(IHostApplicationBuilder builder)
    {
        public IHostApplicationBuilder ConfigureGrps()
        {
            builder.Services.AddGrpc();
            return builder;
        }
    }
}