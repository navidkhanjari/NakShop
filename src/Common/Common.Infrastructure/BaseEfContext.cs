using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Domain;
using Common.Infrastructure.MediatR;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Common.Infrastructure
{
    public class BaseEfContext<T> : DbContext where T : DbContext
    {
        private readonly ICustomPublisher _publisher;
        public BaseEfContext(DbContextOptions<T> options,  ICustomPublisher publisher) : base(options)
        {
            _publisher = publisher;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var modifiedEntities = GetModifiedEntities();
            var res= await base.SaveChangesAsync(cancellationToken);
            await PublishEvents(modifiedEntities);
            return res;
        }

        private List<AggregateRoot> GetModifiedEntities() =>
            ChangeTracker.Entries<AggregateRoot>()
                .Where(x => x.State != EntityState.Detached)
                .Select(c => c.Entity)
                .Where(c => c.DomainEvents.Any()).ToList();

        private async Task PublishEvents(List<AggregateRoot> modifiedEntities)
        {
            foreach (var entity in modifiedEntities)
            {
                var events = entity.DomainEvents;
                foreach (var domainEvent in events)
                {
                    await _publisher.Publish(domainEvent,PublishStrategy.ParallelNoWait);
                    //await _mediator.Publish(domainEvent);
                }
            }
        }
    }
}