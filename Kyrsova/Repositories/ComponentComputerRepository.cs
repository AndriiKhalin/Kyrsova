
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;

namespace Kyrsova.Repositories;

public class ComponentComputerRepository : IComponentComputerRepository
{
    private ComputerDbContext _context;

    public ComponentComputerRepository(ComputerDbContext context)
    {
        _context = context;
    }

    public async Task Add(ComponentComputer componentComputer)
    {


        componentComputer.Price = _context.HardDrives.First(x => x.Id == componentComputer.HardDriveId).Price
                                  + _context.Rams.First(x => x.Id == componentComputer.RamId).Price
                                  + _context.Processors.First(x => x.Id == componentComputer.ProcessorId).Price
                                  + _context.Units.First(x => x.Id == componentComputer.UnitId).Price
                                  + _context.VideoCards.First(x => x.Id == componentComputer.VideoCardId).Price
                                  + _context.MotherBoards.First(x => x.Id == componentComputer.MotherBoardId).Price;
        await _context.ComponentComputers.AddAsync(componentComputer);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var componentComputer = await _context.ComponentComputers.FirstOrDefaultAsync(p => p.Id == id);
        if (componentComputer != null)
        {
            _context.ComponentComputers.Remove(componentComputer);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<ComponentComputer>> GetAll()
    {
        var componentComputers = await _context.ComponentComputers
            .Include(x => x.Processor)
            .Include(x => x.HardDrive)
            .Include(x => x.MotherBoard)
            .Include(x => x.Ram)
            .Include(x => x.Unit)
            .Include(x => x.VideoCard)
            .ToListAsync();
        return componentComputers;
    }

    public async Task<ComponentComputer> GetById(int id)
    {
        return await _context.ComponentComputers.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<ComponentComputer> GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public async Task Update(ComponentComputer componentComputer)
    {
        var _componentComputer = await _context.ComponentComputers.FirstOrDefaultAsync(x => x.Id == componentComputer.Id);

        if (_componentComputer != null)
        {
            componentComputer.Price = _context.HardDrives.First(x => x.Id == componentComputer.HardDriveId).Price
                                      + _context.Rams.First(x => x.Id == componentComputer.RamId).Price
                                      + _context.Processors.First(x => x.Id == componentComputer.ProcessorId).Price
                                      + _context.Units.First(x => x.Id == componentComputer.UnitId).Price
                                      + _context.VideoCards.First(x => x.Id == componentComputer.VideoCardId).Price
                                      + _context.MotherBoards.First(x => x.Id == componentComputer.MotherBoardId).Price;
            _context.Entry(_componentComputer).CurrentValues.SetValues(componentComputer);

            await _context.SaveChangesAsync();
        }
    }
}