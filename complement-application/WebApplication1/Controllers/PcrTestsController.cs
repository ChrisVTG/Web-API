using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Enums;
using WebApplication1.Models;
using WebApplication1.Persistence;

namespace WebApplication1.Controllers;

public class PcrTestsController : Controller
{
    private readonly ILogger<PcrTestsController> _logger;
    private readonly PcrContext _dbContext;

    public PcrTestsController(ILogger<PcrTestsController> logger, PcrContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task<IActionResult> List(CancellationToken cancellationToken)
    {
        var pcrTests = await _dbContext.PcrTests.ToListAsync(cancellationToken);
        Console.WriteLine($"Found {pcrTests.Count} pcr tests with ids {string.Join(", ", pcrTests.Select(z => z.Id))}");

        var model = new PcrTestListViewModel();
        model.AnalyzedSamplesCount = 59;
        model.Items = new List<PcrTestListItemViewModel>()
        {
            new()
            {
                CreationDate = new DateTime(2023, 10, 30, 12, 54, 30),
                SamplingDate = new DateTime(2023, 10, 30, 12, 54, 30),
                ReceptionDate = new DateTime(2023, 11, 1),
                AnalysisDate = new DateTime(2023, 11, 2),
                AnalysisResult = AnalysisResultEnum.Positive,
                SampleNumber = "ABCD1234",
                Id = 1,
                Performer = "Ludwig Lebrun"
            },
            new()
            {
                CreationDate = new DateTime(2023, 11, 21, 9, 31, 24),
                SamplingDate = new DateTime(2023, 11, 21, 9, 31, 24),
                ReceptionDate = new DateTime(2023, 11, 23),
                AnalysisDate = new DateTime(2023, 11, 24),
                AnalysisResult = AnalysisResultEnum.Negative,
                SampleNumber = "ZREZ5241",
                Id = 2,
                Performer = "Ludwig Leblanc"
            }
        };

        return View(model);
    }

    public IActionResult Edit(int id = -1)
    {
        var model = new PcrTestEditViewModel();

        if (id != -1)
        {
            // retrieve from database matching pcr test
            model = new PcrTestEditViewModel()
            {
                SamplingDate = new DateTime(2023, 10, 30, 12, 54, 30),
                ReceptionDate = new DateTime(2023, 11, 1),
                AnalysisDate = new DateTime(2023, 11, 2),
                AnalysisResult = AnalysisResultEnum.Positive,
                SampleNumber = "ABCD1234",
                Comment = "Ceci est mon commentaire",
                Id = id,
                Performer = "Ludwig Lebrun"
            };
        }

        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(PcrTestEditViewModel model)
    {
        return View();
    }
}