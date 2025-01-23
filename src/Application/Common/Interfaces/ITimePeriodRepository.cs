using data_visualization_api.Domain.Entities;
namespace data_visualization_api.Application.Common.Interfaces
{
  public interface ITimePeriodRepository
  {
    Task<List<TimePeriod>> GetTimePeriodsAsync();
    Task<TimePeriod> GetTimePeriodByIdAsync(int id);
    Task<TimePeriod> CreateTimePeriodAsync(TimePeriod timePeriod);
    Task UpdateTimePeriodAsync(TimePeriod timePeriod);
    Task DeleteTimePeriodAsync(TimePeriod timePeriod);
  }
}