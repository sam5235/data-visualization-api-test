using data_visualization_api.Application.Charts.Commands.CreateChart;
using data_visualization_api.Application.Charts.Queries.GetCharts;

namespace data_visualization_api.Web.Endpoints;

public class Charts : EndpointGroupBase
{
  public override void Map(WebApplication app)
  {
    app.MapGroup(this)
        .MapGet(GetCharts)
        .MapPost(CreateChart);
  }

  public Task<ChartsVm> GetCharts(ISender sender)
  {
    return sender.Send(new GetChartsQuery());
  }

  // Get charts by id


  public Task<int> CreateChart(ISender sender, CreateChartCommand command)
  {
    return sender.Send(command);
  }
}