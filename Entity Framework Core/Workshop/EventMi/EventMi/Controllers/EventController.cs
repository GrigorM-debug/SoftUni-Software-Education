using EventMi.Core.Constants;
using EventMi.Core.Contracts;
using EventMi.Core.Models;
using EventMi.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventMi.Controllers;

public class EventController : Controller
{
    private readonly IEventServices _eventServices;
    private readonly ILogger<HomeController> _logger;

    public EventController(IEventServices eventServices, ILogger<HomeController> logger)
    {
        _eventServices = eventServices;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var model = await _eventServices.GetAllEventsAsync();

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var model = new EventModel();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(EventModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _eventServices.CreateEventAsync(model);

                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating event");
                ModelState.AddModelError(string.Empty, UserMessages.UnknownError);
            }
        }

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {

    }

    [HttpPost]
    public async Task<IActionResult> Edit(EventModel model)
    {

    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {

    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {

    }
}