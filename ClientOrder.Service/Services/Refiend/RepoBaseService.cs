using ClientOrder.Data.Context;
using ClientOrder.Domain.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ClientOrder.Service.ClientServicies
{
    public abstract class RepoBaseService
    {
        protected readonly ClientOrderContext Context;
        protected RepoBaseService(ClientOrderContext context)
        {
            this.Context = context;

            //Add this to ignore tracking in memory for entities.
            //This is usfull in application dat have a continues link with the database.
            //In web apps is recomanded to have a disconsinues connection, because we don't now when and if we will get any changes for an object.
            //For this pourpose we are traking each entitie when it was las modify and we have an proportie on our entities IsDirty that keeps this info.
            this.Context.ChangeTracker.QueryTrackingBehavior
                = QueryTrackingBehavior.NoTracking;
        }


        protected void Save<TEntity>(TEntity entity) where TEntity : ClientChangeTracker
        {
            Context.ChangeTracker.TrackGraph(entity, e => SetState(e.Entry));
        }

        protected void CascadeDelete<TEntity>(TEntity entity) where TEntity : ClientChangeTracker
        {
            Context.Entry(entity).State = EntityState.Deleted; //TRACKING
            Context.SaveChanges();
        }

        private void SetState(EntityEntry entry)
        {
            if (entry.IsKeySet)
            {
                if (((ClientChangeTracker)entry.Entity).IsDirty)
                {
                    entry.State = EntityState.Modified;
                }
                else
                {
                    entry.State = EntityState.Unchanged;
                }
            }
            else
            {
                entry.State = EntityState.Added;
            }
        }
    }
}