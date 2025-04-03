using Prime.RushHourAPI.Domain.Dtos;
using Prime.RushHourAPI.Domain.Dtos.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Domain.Abstractions.Services
{
    public interface IAppointmentService
    {
        public Task CreateAsync(AppointmentDto appointmentDto);
        public Task<AppointmentDtoWithId> GetAsync(Guid id);

        public Task<PaginatedResult<AppointmentDtoWithOthers>> GetAllAsync(int pageNumber, int pageSize);

        public Task UpdateAsync(AppointmentDtoWithId appointmentDto);

        public Task DeleteAsync(Guid id);
    }
}
