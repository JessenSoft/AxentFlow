using Microsoft.EntityFrameworkCore;
using JessenSoft.AxentFlow.Application.Interfaces;
using JessenSoft.AxentFlow.Core.Models;
using JessenSoft.AxentFlow.Infrastructure.Persistence;

namespace JessenSoft.AxentFlow.Infrastructure.Services;

/// <summary>
/// Provides CRUD operations for workflow definitions using EF Core.
/// </summary>
public class WorkflowService : IWorkflowService
{
    private readonly AxentFlowDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="WorkflowService"/> class.
    /// </summary>
    /// <param name="context">The EF Core database context.</param>
    public WorkflowService(AxentFlowDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<WorkflowDefinition>> GetAllAsync()
    {
        return await _context.Workflows
            .Include(w => w.Steps)
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<WorkflowDefinition?> GetByIdAsync(Guid id)
    {
        return await _context.Workflows
            .Include(w => w.Steps)
            .FirstOrDefaultAsync(w => w.Id == id);
    }

    /// <inheritdoc />
    public async Task<WorkflowDefinition> CreateAsync(WorkflowDefinition definition)
    {
        _context.Workflows.Add(definition);
        await _context.SaveChangesAsync();
        return definition;
    }

    /// <inheritdoc />
    public async Task UpdateAsync(WorkflowDefinition definition)
    {
        _context.Workflows.Update(definition);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Workflows.FindAsync(id);
        if (entity != null)
        {
            _context.Workflows.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}