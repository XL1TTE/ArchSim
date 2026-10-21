
using ArchSim.Server.Proto.Api.v1;
using Grpc.Core;

namespace Archsim.Server.Configuration;

public class NodeService : Nodes.NodesBase
{
    public override Task<GetPreviewsResponse> GetPreviews(GetPreviewsRequest request, ServerCallContext context)
    {
        var response = new GetPreviewsResponse();

        response.Previews.Add(new NodePreview
        {
            TypeId = "service",
            Name = "Compute Service",
            Description = "Stateless execution node with processing pipeline"
        });

        response.Previews.Add(new NodePreview
        {
            TypeId = "database",
            Name = "Database",
            Description = "Finite connection pool storage node"
        });

        return Task.FromResult(response);
    }

}