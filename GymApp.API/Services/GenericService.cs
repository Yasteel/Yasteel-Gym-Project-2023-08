using GymApp.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymApp.API.Services
{
    public class GenericService<T> : IGenericService<T>
        where T : class
    {
        private readonly ApplicationDbContext context;

        public GenericService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Task<List<T>> GetAll()
        {
            return this.context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await this.context.Set<T>().FindAsync(id);
        }

        public async Task<bool> Create(T entity)
        {

            try
            {
                this.context.Set<T>().Add(entity);
                await this.context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
            
        }

        public async Task<bool> Update(T entity)
        {
            try
            {
                this.context.Set<T>().Update(entity);
                await this.context.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var entity = this.context.Set<T>().Find(id);
                this.context.Set<T>().Remove(entity);
                await this.context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
