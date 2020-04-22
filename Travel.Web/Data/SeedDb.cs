using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Web.Data.Entities;

namespace Travel.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckExpenseTypesAsync();
            await CheckCountriesAsync();
            await CheckEmployeesAsync();
        }

        private async Task CheckEmployeesAsync()
        {
            CityEntity city = _context.Citys.FirstOrDefault();
            if (!_context.Employees.Any())
            {
                _context.Employees.Add(new EmployeeEntity
                {
                    Document = "1122334455",
                    FirstName = "Juan",
                    LastName = "Gomez",
                    TripEntities = new List<TripEntity>
                    {
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(6000),
                            City = city,
                            TotalAmount = 20M
                        },
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(4000),
                            City = city,
                            TotalAmount = 40M
                        }
                    }
                });

                _context.Employees.Add(new EmployeeEntity
                {
                    Document = "12345678",
                    FirstName = "Camilo",
                    LastName = "Ruiz",
                    TripEntities = new List<TripEntity>
                    {
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(8000),
                            City = city,
                            TotalAmount = 15M
                        },
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(10000),
                            City = city,
                            TotalAmount = 10M
                        }
                    }
                });
                await _context.SaveChangesAsync();
            }
        }


        private async Task CheckExpenseTypesAsync()
        {
            if (!_context.ExpenseTypes.Any())
            {
                _context.ExpenseTypes.Add(new Entities.ExpenseTypeEntity { Name = "Alimentación" });
                _context.ExpenseTypes.Add(new Entities.ExpenseTypeEntity { Name = "Hospedaje" });
                _context.ExpenseTypes.Add(new Entities.ExpenseTypeEntity { Name = "Transporte" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countrys.Any())
            {
                _context.Countrys.Add(new Entities.CountryEntity
                {
                    Name = "PERU",
                    Cities = new List<CityEntity>
                    {
                        new CityEntity
                        {
                            Name = "LIMA"
                        },
                        new CityEntity
                        {
                            Name = "CUSCO"
                        },
                        new CityEntity
                        {
                            Name = "AREQUIPA"
                        }
                    }
                });
                _context.Countrys.Add(new Entities.CountryEntity
                {
                    Name = "COLOMBIA",
                    Cities = new List<CityEntity>
                    {
                        new CityEntity
                        {
                            Name = "BOGOTA"
                        },
                        new CityEntity
                        {
                            Name = "CALI"
                        },
                        new CityEntity
                        {
                            Name = "MEDELLIN"
                        }
                    }
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
