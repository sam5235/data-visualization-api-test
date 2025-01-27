using data_visualization_api.Application.Indicators.Queries;

namespace data_visualization_api.Web.Endpoints;

public class Indicators : EndpointGroupBase
{
  public override void Map(WebApplication app)
  {
    app.MapGroup(this)
       .MapGet(GetIndicatorsByTopicId, "/indicators/{topicId:int:min(1)}");
  }

  public async Task<IResult> GetIndicatorsByTopicId(ISender sender, int topicId)
  {
    try
    {
      var indicators = await sender.Send(new GetIndicatorsByTopicIdQuery(topicId));
      return Results.Ok(indicators);
    }
    catch (Exception ex)
    {
      return Results.Problem(detail: ex.Message, statusCode: 500);
    }
  }
}
