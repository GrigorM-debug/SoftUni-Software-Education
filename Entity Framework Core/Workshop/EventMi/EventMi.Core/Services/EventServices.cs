using EventMi.Core.Contracts;
using EventMi.Core.Models;
using EventMi.Infrastructure.Common;
using EventMi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EventMi.Core.Services;

public class EventServices : IEventServices
{
    private readonly IRepository _repository;

    public EventServices(IRepository repository)
    {
        _repository = repository;
    }


    public async Task<int> CreateEventAsync(EventModel eventModel)
    {
        if (eventModel.Id > 0)
        {
            var exist = _repository.GetById<Event>(eventModel.Id) != null;

            throw new ArgumentException(Exceptions.Exceptions.ExistingEvent);
        }

        var newEvent = new EventModel
        {
            Name = eventModel.Name,
            Start = eventModel.Start,
            End = eventModel.End,
            Place = eventModel.Place
        };

        await _repository.AddAsync(newEvent);

        return await _repository.SaveChangesAsync();
    }

    public async Task<IEnumerable<EventModel>> GetAllEventsAsync()
    {
        var events = await _repository.AllReadonly<Event>().ToListAsync();

        return events.Select(e => new EventModel
        {
            Id = e.Id,
            Name = e.Name,
            Start = e.Start,
            End = e.End,
            Place = e.Place
        });
    }

    public async Task<EventModel> GetEventByIdAsync(int eventId)
    {
        var ev = await _repository.AllReadonly<Event>()
            .FirstOrDefaultAsync(e => e.Id == eventId);

        if (ev == null) throw new ArgumentException(Exceptions.Exceptions.UnExistingEvent);
        return new EventModel
        {
            Id = ev.Id,
            Name = ev.Name,
            Start = ev.Start,
            End = ev.End,
            Place = ev.Place
        };
    }

    public async Task<int> EditEventAsync(int eventId, EventModel updatedEvent)
    {
        var existingEvent = await _repository.All<Event>()
            .FirstOrDefaultAsync(e => e.Id == eventId);

        if (existingEvent == null) throw new ArgumentException(Exceptions.Exceptions.UnExistingEvent);

        existingEvent.Name = updatedEvent.Name;
        existingEvent.Start = updatedEvent.Start;
        existingEvent.End = updatedEvent.End;
        existingEvent.Place = updatedEvent.Place;

        return await _repository.SaveChangesAsync();
    }

    public async Task<int> DeleteEventAsync(int eventId)
    {
        var eventToDelete = await _repository.All<Event>()
            .FirstOrDefaultAsync(e => e.Id == eventId);

        if (eventToDelete == null) throw new ArgumentException(Exceptions.Exceptions.UnExistingEvent);

        _repository.Delete(eventToDelete);

        return await _repository.SaveChangesAsync();
    }
}