using data_visualization_api.Application.Areas.Queries.GetAreas;

namespace data_visualization_api.Web.Endpoints;

public class Areas : EndpointGroupBase
{
  public override void Map(WebApplication app)
  {
    app.MapGroup(this)
        .MapGet(GetAreas, "/areas");
  }

  public async Task<IResult> GetAreas(ISender sender)
  {
    try
    {
      var areas = await sender.Send(new GetAreasQuery());
      return Results.Ok(areas);
    }
    catch (Exception ex)
    {
      return Results.Problem(detail: ex.Message, statusCode: 500);
    }
  }
}