using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Data.Entities;
using Task1.Data.EntityFramework;
using Task1.Utilities;
using Task1.ViewModel;
using Task1.ViewModel.Pagination;
using Task1.ViewModel.Unit;

namespace Task1.Application
{
    public class UnitService : IUnitService
    {
        private readonly Task1DbContext _context;

        public UnitService(Task1DbContext context)
        {
            _context = context;
        }

        public UnitService()
        {
        }

        public async Task<int> Create(UnitCreateRequest request)
        {
            var unit = new Unit()
            {
                UnitName = request.UnitName,
                BossName = request.BossName,
                Created = DateTime.Now,
            };

            _context.Units.Add(unit);
            await _context.SaveChangesAsync();
            return unit.Id;
        }

        public async Task<int> Delete(int unitId)
        {
            var unit = await _context.Units.FindAsync(unitId);
            if (unit == null) throw new Task1Exception($"Cannot find unit: {unit}");

            _context.Units.Remove(unit);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(UnitUpdateRequest request)
        {
            var unit = await _context.Units.FindAsync(request.Id);
            if (unit == null) throw new Task1Exception($"Cannot find unit product: {unit}");

            // update
            unit.UnitName = request.UnitName;
            unit.BossName = request.BossName;

            _context.Units.Update(unit);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<UnitViewModel>> GetAll(PagedRequest request)
        {
            //1. Select join
            var query = _context.Units;
            //2. filter
            /* if (!string.IsNullOrEmpty(request.Keyword))
                 query = query.Where(x => x.pt.Name.Contains(request.Keyword));*/

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new UnitViewModel()
                {
                    Id = x.Id,
                    UnitName = x.UnitName,
                    BossName = x.BossName,
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<UnitViewModel>()
            {
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }
    }
}