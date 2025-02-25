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
  }

  public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
  {
    return await _context.Charts
        .AllAsync(c => c.ChartTitle != title, cancellationToken);
  }
}