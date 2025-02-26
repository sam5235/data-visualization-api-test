using data_visualization_api.Application.Charts.Commands.CreateChart;
using data_visualization_api.Application.Charts.Queries.GetCharts;
using data_visualization_api.Application.Charts.Queries.GetChartById;
using data_visualization_api.Application.Common.Models;
using data_visualization_api.Application.Charts.Commands.DeleteChart;
using data_visualization_api.Application.Charts.Commands.UpdateChart;

namespace data_visualization_api.Web.Endpoints;

public class Charts : EndpointGroupBase
{
  public override void Map(WebApplication app)
  {
    app.MapGroup(this)
        .MapGet(GetCharts)
        .MapPost(CreateChart)
        .MapGet(GetChartById, "/{id}")
        .MapDelete(DeleteChart, "/{id}")
        .MapPut(UpdateChart, "/{id}");
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

  public Task<Result<int>> UpdateChart(ISender sender, int id, UpdateChartCommand command)
  {
    if (id != command.Id)
    {
      return Task.FromResult(Result<int>.Failure("Id mismatch"));
    }
    return sender.Send(command);
  }

  public Task<Result<int>> DeleteChart(ISender sender, int id)
  {
    return sender.Send(new DeleteChartCommand { Id = id });
  }
}