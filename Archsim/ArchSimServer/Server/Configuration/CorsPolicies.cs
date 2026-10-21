namespace Archsim.Server.Configuration;

public enum Cors : byte { ClientPolicy }

public static class CorsConfiguration
{
    extension(IHostApplicationBuilder builder)
    {
        public IHostApplicationBuilder ConfigureCorsPolicies(string EnvSection = "Cors:AllowedOrigins")
        {
            var allowed = builder.Configuration
                .GetSection(EnvSection)
                .Get<string[]>() ?? [];

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(Cors.ClientPolicy.ToString(), policy =>
                {
                    policy.WithOrigins(allowed)
                            .WithMethods("POST", "OPTIONS")
                            .WithHeaders("Content-Type", "x-grpc-web", "x-user-agent")
                            .WithExposedHeaders("grpc-status", "grpc-message", "grpc-encoding", "grpc-accept-encoding");
                });
            });

            return builder;
        }
    }
}
