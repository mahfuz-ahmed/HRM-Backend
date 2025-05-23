﻿using HRM.Domain;

namespace HRM.Applicatin
{
    public interface IHolidaysRepository
    {
        Task<Holidays> AddHolidaysAsync(Holidays holidays);
        Task<Holidays> UpdateHolidaysAsync(int holidaysId, Holidays holodays);
        Task<bool> DeleteHolidaysAsync(int holidaysId);
        Task<Holidays> GetHolidaysByIdAsync(int id);
        Task<List<Holidays>> GetHolidaysByName(string name);
        Task<IEnumerable<Holidays>> GetHolidaysAsync();
    }
}
