using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prime.RushHourAPI.Api.Mapper;
using Prime.RushHourAPI.Data;
using Prime.RushHourAPI.Data.Entities;
using Prime.RushHourAPI.Data.Repositories;
using Prime.RushHourAPI.Domain.Abstractions.Repositories;
using Prime.RushHourAPI.Domain.Abstractions.Services;
using Prime.RushHourAPI.Domain.Dtos.Provider;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Prime.RushHourAPI.Services.Test
{
    
        public class ProviderServiceTest : IDisposable
        {
            private readonly DbContextOptions<RushHourAPIDbContext> _dbContextOptions;
            private readonly IMapper _mapper;
            private readonly IProviderRepository _repository;
            private readonly IProviderService _providerService;
            private readonly RushHourAPIDbContext _context;

            public ProviderServiceTest()
            {
                _dbContextOptions = new DbContextOptionsBuilder<RushHourAPIDbContext>()
                    .UseInMemoryDatabase(databaseName: "RushHourAppDBBB")                                                                                                                                
                    .Options;

                if (_mapper == null)
                {
                    var mappingConfig = new MapperConfiguration(mc =>
                    {
                        mc.AddProfile(new MapperProfile());
                    });
                    IMapper mapper = mappingConfig.CreateMapper();
                    _mapper = mapper;
                }

                _context = new RushHourAPIDbContext(_dbContextOptions);      
                _repository = new ProviderRepository(_context, _mapper);
                _providerService = new ProviderService(_repository);
            }

            public async void Dispose()
            {
                await _context.Database.EnsureDeletedAsync();
            }

            

            [Fact]
            public async Task CheckIfCreated()
            {
                var newProvider = new ProviderDto();

            newProvider.Name = "testProvider";
            newProvider.Website = "TestWebsite";
            newProvider.Domain = "TestDomain";
            newProvider.Phone = "089590";
            newProvider.StartTime = DateTime.Now;
            newProvider.EndTime = DateTime.Now;
            newProvider.WorkingDays = new List<DayOfWeek>();

            await _providerService.CreateAsync(newProvider);

                Assert.Equal(1, await _context.Providers.CountAsync());
            }

            [Fact]
            public async Task CheckRead()
            {
            var newProvider = new ProviderDtoWithId();

            newProvider.Name = "testProvider";
            newProvider.Website = "TestWebsite";
            newProvider.Domain = "TestDomain";
            newProvider.Phone = "089590";
            newProvider.StartTime = DateTime.Now;
            newProvider.EndTime = DateTime.Now;
            newProvider.WorkingDays = new List<DayOfWeek>();
            var createdProvider = new ProviderDto();
            await _providerService.GetAllAsync(1, 5);
            Assert.Equal(1, await _context.Providers.CountAsync());
            }

            

            [Fact]
            public async Task CheckIfDeleted()
            {
            var newProvider = new ProviderDtoWithId();

            newProvider.Name = "testProvider";
            newProvider.Website = "TestWebsite";
            newProvider.Domain = "TestDomain";
            newProvider.Phone = "089590";
            newProvider.StartTime = DateTime.Now;
            newProvider.EndTime = DateTime.Now;
            newProvider.WorkingDays = new List<DayOfWeek>();
            var createdProvider = new ProviderDto();
            

            await _providerService.CreateAsync(createdProvider);

            await _repository.DeleteAsync(newProvider.Id);

                Assert.True(await _context.Providers.CountAsync() == 0);
            }

            
        }

    
}
