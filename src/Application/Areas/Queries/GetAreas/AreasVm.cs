namespace data_visualization_api.Application.Areas.Queries.GetAreas
{
  public class AreasVm
  {
    public IReadOnlyCollection<AreaDto> Areas { get; init; } = Array.Empty<AreaDto>();
  }
}