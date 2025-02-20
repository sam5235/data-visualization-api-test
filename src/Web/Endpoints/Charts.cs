using data_visualization_api.Application.Charts.Queries.GetCharts;
using data_visualization_api.Application.Charts.Queries.GetChartById;
using data_visualization_api.Application.Charts.Commands.CreateChart;

namespace data_visualization_api.Web.Endpoints;

public class Charts : EndpointGroupBase
{
  public override void Map(WebApplication app)
  {
    app.MapGroup(this)
        .MapPost(CreateChart)
        .MapGet(GetCharts, "/charts")
        .MapGet(GetChartById, "/charts/{chartId}");
  }
  private async Task<IResult> CreateChart(CreateChartCommand command, ISender sender)
  {
    try
    {
      var chardId = await sender.Send(command);
      return Results.Ok(chardId);
    }
    catch (Exception ex)
    {
      return Results.Problem(detail: ex.Message, statusCode: 500);
    }
  }

  private async Task<IResult> GetCharts(ISender sender)
  {
    try
    {
      var charts = await sender.Send(new GetChartsQuery());
      return Results.Ok(charts);
    }
    catch (Exception ex)
    {
      return Results.Problem(detail: ex.Message, statusCode: 500);
    }
  }

  private async Task<IResult> GetChartById(ISender sender, int chartId)
  {
    try
    {
      var charts = await sender.Send(new GetChartByIdQuery(chartId));
      return Results.Ok(charts);
    }
    catch (NotFoundException ex)
    {
      return Results.NotFound(ex.Message);
    }
    catch (Exception ex)
    {
      return Results.Problem(detail: ex.Message, statusCode: 500);
    }
  }
}

