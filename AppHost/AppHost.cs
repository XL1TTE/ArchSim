var builder = DistributedApplication.CreateBuilder(args);

var server = builder.AddProject<Projects.ArchSimServer>("archsim-server", launchProfileName: null)
    .WithHttpEndpoint();

var webClient = builder.AddViteApp("archsim-webclient", "../Archsim/WebClient")
    .WithHttpEndpoint()
    .WithEnvironment("ARCHSIM_SERVER_URL", server.GetEndpoint("http"));

server.WithEnvironment("Cors:AllowedOrigins:0", webClient.GetEndpoint("http"));

builder.Build().Run();

