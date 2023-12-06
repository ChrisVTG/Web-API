using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using WebApplication1.Models;
using WebApplicationEntities;
using WebApplicationPersistence.DbContexts;

namespace WebApplication1.Controllers;

public class PcrTestsController : Controller
{
    private readonly ILogger<PcrTestsController> _logger;
    private readonly PcrContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IToastNotification _toastNotification;

    public PcrTestsController(ILogger<PcrTestsController> logger, PcrContext dbContext, IMapper mapper,
        IToastNotification toastNotification)
    {
        _logger = logger;
        _dbContext = dbContext;
        _mapper = mapper;
        _toastNotification = toastNotification;
    }

    public async Task<IActionResult> List(CancellationToken cancellationToken)
    {
        var pcrTests = await _dbContext.PcrTests
            .Include(pcrTest => pcrTest.Performer) // = left join in SQL query
            .ToListAsync(cancellationToken);
        // Console.WriteLine($"Found {pcrTests.Count} pcr tests with ids {string.Join(", ", pcrTests.Select(z => z.Id))}");

        var model = new PcrTestListViewModel();
        // this way is correct if we query the entire database.
        // since it could be a performance issue, we have to change the way to handle it
        // model.AnalyzedSamplesCount = pcrTests.Count(x => x.AnalysisDate != null);
        // put it in async way
        // model.AnalyzedSamplesCount = _dbContext.PcrTests.Count(x => x.AnalysisDate != null);
        model.AnalyzedSamplesCount =
            await _dbContext.PcrTests.CountAsync(x => x.AnalysisDate != null, cancellationToken);
        // option 1
        model.Items = _mapper.Map<List<PcrTestListItemViewModel>>(pcrTests);

        // option 2
        // _mapper.Map(pcrTests,  model.Items);

        // option 3
        // var myItems = new List<PcrTestListItemViewModel>();
        // _mapper.Map(pcrTests, myItems);
        // model.Items = myItems;

        // model.Items = new List<PcrTestListItemViewModel>();
        //
        // foreach (var pcrTest in pcrTests)
        // {
        //     model.Items.Add(new PcrTestListItemViewModel()
        //     {
        //         CreationDate = pcrTest.CreationDate,
        //         SamplingDate = pcrTest.SamplingDate,
        //         ReceptionDate = pcrTest.ReceptionDate,
        //         AnalysisDate = pcrTest.AnalysisDate,
        //         AnalysisResult = pcrTest.AnalysisResult,
        //         SampleNumber = pcrTest.SampleNumber,
        //         Id = pcrTest.Id,
        //         Performer = pcrTest.Performer is null ? "" : $"{pcrTest.Performer.FirstName} {pcrTest.Performer.LastName}",
        //     });
        // }

        // model.Items = new List<PcrTestListItemViewModel>()
        // {
        //     new()
        //     {
        //         CreationDate = new DateTime(2023, 10, 30, 12, 54, 30),
        //         SamplingDate = new DateTime(2023, 10, 30, 12, 54, 30),
        //         ReceptionDate = new DateTime(2023, 11, 1),
        //         AnalysisDate = new DateTime(2023, 11, 2),
        //         AnalysisResult = AnalysisResultEnum.Positive,
        //         SampleNumber = "ABCD1234",
        //         Id = 1,
        //         Performer = "Ludwig Lebrun"
        //     },
        //     new()
        //     {
        //         CreationDate = new DateTime(2023, 11, 21, 9, 31, 24),
        //         SamplingDate = new DateTime(2023, 11, 21, 9, 31, 24),
        //         ReceptionDate = new DateTime(2023, 11, 23),
        //         AnalysisDate = new DateTime(2023, 11, 24),
        //         AnalysisResult = AnalysisResultEnum.Negative,
        //         SampleNumber = "ZREZ5241",
        //         Id = 2,
        //         Performer = "Ludwig Leblanc"
        //     }
        // };

        return View(model);
    }

    public async Task<IActionResult> Edit(CancellationToken cancellationToken, int id = -1)
    {
        var model = new PcrTestEditViewModel() { SamplingDate = DateTime.Now };

        if (id != -1)
        {
            // retrieve from database matching pcr test
            var dbPcrTest =
                await _dbContext.PcrTests.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);

            if (dbPcrTest != null)
            {
                model = _mapper.Map<PcrTestEditViewModel>(dbPcrTest);
                // model = new PcrTestEditViewModel()
                // {
                //     SamplingDate = dbPcrTest.SamplingDate,
                //     ReceptionDate = dbPcrTest.ReceptionDate,
                //     AnalysisDate = dbPcrTest.AnalysisDate,
                //     AnalysisResult = dbPcrTest.AnalysisResult,
                //     SampleNumber = dbPcrTest.SampleNumber,
                //     Id = dbPcrTest.Id,
                //     PerformerId = dbPcrTest.PerformerId,
                //     Comment = dbPcrTest.Comment,
                // };
            }
        }

        var users = await _dbContext.Users.ToListAsync(cancellationToken);
        model.SliPerformers = users.Select(x => new SelectListItem()
        {
            Text = $"{x.FirstName} {x.LastName}",
            Value = x.Id.ToString()
        }).ToList();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(PcrTestEditViewModel model, CancellationToken cancellationToken)
    {
        PcrTest dbPcrTest = new PcrTest();

        if (model.Id > 0)
            dbPcrTest = await _dbContext.PcrTests.FirstOrDefaultAsync(x => x.Id == model.Id, cancellationToken) ??
                        new PcrTest();

        _mapper.Map(model, dbPcrTest);
        // dbPcrTest.SamplingDate = model.SamplingDate;
        // dbPcrTest.ReceptionDate = model.ReceptionDate;
        // dbPcrTest.AnalysisDate = model.AnalysisDate;
        // dbPcrTest.AnalysisResult = model.AnalysisResult;
        // dbPcrTest.SampleNumber = model.SampleNumber;
        // dbPcrTest.PerformerId = model.PerformerId;
        // dbPcrTest.Comment = model.Comment;

        if (dbPcrTest.Id <= 0)
        {
            // creation of new element
            dbPcrTest.CreationDate = DateTime.Now;
            await _dbContext.AddAsync(dbPcrTest, cancellationToken);
        }
        else
        {
            // update of existing element
            _dbContext.Update(dbPcrTest);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
        _toastNotification.AddSuccessToastMessage("Modifications sauvegardées avec succès !");

        return RedirectToAction("List");
    }

    public async Task<IActionResult> Delete(CancellationToken cancellationToken, int id = -1)
    {
        // if (id == -1) return RedirectToAction("List");
        //
        // var dbPcrTest = await _dbContext.PcrTests.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
        //
        // if (dbPcrTest == null) return RedirectToAction("List");
        //
        // _dbContext.Remove(dbPcrTest);
        // await _dbContext.SaveChangesAsync(cancellationToken);
        //
        // return RedirectToAction("List");

        if (id != -1)
        {
            var dbPcrTest =
                await _dbContext.PcrTests.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);

            if (dbPcrTest != null)
            {
                _dbContext.Remove(dbPcrTest);
                await _dbContext.SaveChangesAsync(cancellationToken);
                _toastNotification.AddSuccessToastMessage($"Elément supprimé avec succès");
            }
            else
            {
                _toastNotification.AddErrorToastMessage($"Aucun élément trouvé avec l'identifiant {id}");
            }
        }
        else
        {
            _toastNotification.AddWarningToastMessage("Il est nécessaire de fournir un identifiant pour le supprimer");
        }

        return RedirectToAction("List");
    }
}