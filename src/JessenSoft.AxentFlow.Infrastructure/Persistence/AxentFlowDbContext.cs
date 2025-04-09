using Microsoft.EntityFrameworkCore;
using JessenSoft.AxentFlow.Core.Models;

namespace JessenSoft.AxentFlow.Infrastructure.Persistence
{
    /// <summary>
    /// EF Core database context for AxentFlow.
    /// </summary>
    public class AxentFlowDbContext : DbContext
    {
        public DbSet<WorkflowDefinition> Workflows => Set<WorkflowDefinition>();
        public DbSet<WorkflowStep> Steps => Set<WorkflowStep>();

        public AxentFlowDbContext(DbContextOptions<AxentFlowDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkflowDefinition>()
                .HasMany(w => w.Steps)
                .WithOne(s => s.WorkflowDefinition!)
                .HasForeignKey(s => s.WorkflowDefinitionId);

            base.OnModelCreating(modelBuilder);
        }
    }
}