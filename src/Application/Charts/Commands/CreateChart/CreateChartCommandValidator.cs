using FluentValidation;
using data_visualization_api.Application.Common.Interfaces;

namespace data_visualization_api.Application.Charts.Commands.CreateChart;

public class CreateChartCommandValidator : AbstractValidator<CreateChartCommand>
{
  private readonly IApplicationDbContext _context;

  public CreateChartCommandValidator(IApplicationDbContext context)
  {
    _context = context;

    RuleFor(v => v.SelectedChartType)
        .NotEmpty()
        .WithMessage("Chart type is required.");
    RuleFor(v => v.ChartTitle)
        .NotEmpty()
        .MaximumLength(200);
    RuleFor(x => x.SelectedChartType).NotEmpty().WithMessage("Chart type is required.");
    RuleFor(x => x.SelectedIndicatorName).NotEmpty().WithMessage("Indicator name is required.");
    RuleFor(x => x.ChartTitle).NotEmpty().WithMessage("Chart title is required.");
    RuleFor(x => x.SelectedCountriesData)
        .NotEmpty().WithMessage("At least one country must be selected.");
    RuleFor(x => x.SelectedIndicators)
        .NotEmpty().WithMessage("At least one indicator must be selected.");
    RuleFor(x => x.SelectedTopics)
        .NotEmpty().WithMessage("At least one topic must be selected.");
    RuleFor(x => x.LegendOptions)
        .NotEmpty().WithMessage("Legend options are required.");

  }

  public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
  {
    return await _context.Charts
        .AllAsync(c => c.ChartTitle != title, cancellationToken);
  }
}