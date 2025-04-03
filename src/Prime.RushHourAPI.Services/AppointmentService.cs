using Prime.RushHourAPI.Domain.Abstractions.Repositories;
using Prime.RushHourAPI.Domain.Abstractions.Services;
using Prime.RushHourAPI.Domain.Dtos;
using Prime.RushHourAPI.Domain.Dtos.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository repository;

        public AppointmentService(IAppointmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }
        public async Task CreateAsync(AppointmentDto appointmentDto)
        {
            await repository.CreateAsync(appointmentDto);
        }
        public async Task<PaginatedResult<AppointmentDtoWithOthers>> GetAllAsync(int pageNumber, int pageSize)
        {
            var activity = await repository.GetAllAsync<AppointmentDtoWithOthers>(pageNumber, pageSize);
            return activity;

        }
        public async Task<AppointmentDtoWithId> GetAsync(Guid id)
        {
            var appointment = await repository.GetByIdAsync<AppointmentDtoWithId>(id);
            return appointment;
        }

        public async Task UpdateAsync(AppointmentDtoWithId appointment)
        {
            await repository.UpdateAsync(appointment);
        }
    }
}
