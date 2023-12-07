﻿using EventMI.Core.Models;

namespace EventMI.Core.Contracts;

public interface IEventServices
{
    Task<int> CreateEventAsync(EventModel eventModel);

    Task<IEnumerable<EventModel>> GetAllEventsAsync();

    Task<EventModel> GetEventByIdAsync(int eventId);

    Task<int> EditEventAsync(int eventId, EventModel updatedEvent);

    Task<int> DeleteEventAsync(int eventId);
}