using data_visualization_api.Application.Topics.Queries.GetTopics;

namespace data_visualization_api.Web.Endpoints;

public class Topics : EndpointGroupBase
{
  public override void Map(WebApplication app)
  {
    app.MapGroup(this)
       .MapGet(GetTopics, "/topics");
  }

  public async Task<IResult> GetTopics(ISender sender)
  {
    try
    {
      var topics = await sender.Send(new GetTopicsQuery());
      return Results.Ok(topics);
    }
    catch (Exception ex)
    {
      return Results.Problem(detail: ex.Message, statusCode: 500);
    }
  }
}