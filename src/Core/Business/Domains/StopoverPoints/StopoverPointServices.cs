using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using VouDeVan.Core.Business.Support;

namespace VouDeVan.Core.Business.Domains.StopoverPoints
{
    public class StopoverPointServices
    {
        private readonly DataBaseContext _dataBaseContext;

        public StopoverPointServices(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task<StopoverPoint> FindById(Guid id)
        {
            return await _dataBaseContext.StopoverPoints.FirstOrDefaultAsync(tc => tc.Id == id);
        }

        public async Task<GridResult<StopoverPoint>> FindAllToGrid(int page, int rowsPerPage = 10)
        {
            var skip = (page - 1) * rowsPerPage;

            var query = _dataBaseContext.StopoverPoints.OrderByDescending(tc => tc.CreatedAt);

            var total = query.Count();
            var stopoverPoints = await query.Skip(skip)
                .Take(rowsPerPage)
                .ToListAsync();

            return new GridResult<StopoverPoint>(stopoverPoints, total, rowsPerPage);
        }

        public async Task<StopoverPoint> Create(StopoverPoint stopoverPoint)
        {
            if (HasStopoverPointSameName(stopoverPoint.Name))
            {
                throw new BusinessException("Não pode existir duas empresas com o mesmo CNPJ.");
            }

            stopoverPoint.Id = Guid.NewGuid();
            stopoverPoint.Status = Status.Active;

            _dataBaseContext.StopoverPoints.Add(stopoverPoint);

            await _dataBaseContext.SaveChangesAsync();

            return stopoverPoint;
        }

        public bool HasStopoverPointSameName(string name, Guid? id = null)
        {
            var query = _dataBaseContext.StopoverPoints.Where(sp => sp.Name == name);

            if (id != null)
            {
                query = query.Where(sp => sp.Id != id);
            }

            return query.Any();
        }
    }
}
