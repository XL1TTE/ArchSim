using Archsim.Server.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureCorsPolicies();
builder.ConfigureGrps();

var app = builder.Build();

app.UseRouting();
app.UseCors(Cors.ClientPolicy.ToString());
app.UseGrpcWeb();

app.UseHttpsRedirection();

app.MapGrpcService<NodeService>().EnableGrpcWeb().RequireCors(Cors.ClientPolicy.ToString());

app.Run();