using data_visualization_api.Application.Charts.Commands.CreateChart;
using data_visualization_api.Application.Charts.Queries.GetCharts;
using data_visualization_api.Application.Charts.Queries.GetChartById;
using data_visualization_api.Application.Common.Models;

namespace data_visualization_api.Web.Endpoints;

public class Charts : EndpointGroupBase
{
  public override void Map(WebApplication app)
  {
    app.MapGroup(this)
        .MapGet(GetCharts)
        .MapPost(CreateChart)
        .MapGet(GetChartById, "/{id}");
  }

  public Task<ChartsVm> GetCharts(ISender sender)
  {
    return sender.Send(new GetChartsQuery());
  }
  public async Task<ChartDto> GetChartById(ISender sender, int id)
  {
    return await sender.Send(new GetChartByIdQuery(id));
  }

  public Task<Result<int>> CreateChart(ISender sender, CreateChartCommand command)
  {
    return sender.Send(command);
  }
}