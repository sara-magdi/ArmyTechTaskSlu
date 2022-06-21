
using Army.Core.Infrastructure.Enums;
using Army.Core.Infrastructure.Models.Entites.Common;
using Microsoft.EntityFrameworkCore;

namespace Army.Core.DAL.Repositories
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        protected readonly ArmyTechContext _db;

        public BaseRepository(ArmyTechContext db)
        {
            _db = db;
        }

        public virtual async Task<ResultEntity<TEntity>> Delete(TEntity entity)
        {
            ResultEntity<TEntity> result = new();

            try
            {
                _db.Entry(entity).State = EntityState.Modified;

                _db.Remove(entity);
                await _db.SaveChangesAsync();

                result.Status = StatusEnum.Success;
            }
            catch (Exception ex)
            {
                result.Status = StatusEnum.Exception;
                result.Messages.Add(ex.Message);
                result.Details = ex.StackTrace;
            }

            return result;
        }

        public virtual async Task<ResultList<TEntity>> GetAll()
        {
            ResultList<TEntity> result = new();

            try
            {
                List<TEntity>? list = await _db.Set<TEntity>().ToListAsync();

                if (list.Count != 0)
                {
                    result.Items = list;
                    result.Status = StatusEnum.Success;
                }
                else
                {
                    result.Status = StatusEnum.Warning;
                }
            }
            catch (Exception ex)
            {
                result.Status = StatusEnum.Exception;
                result.Messages.Add(ex.Message);
                result.Details = ex.StackTrace;
            }

            return result;
        }

        public virtual async Task<ResultEntity<TEntity>> GetById(int id)
        {
            ResultEntity<TEntity> result = new();

            try
            {
                TEntity? entity = await _db.Set<TEntity>().FindAsync(id);
                _db.Entry(entity).State = EntityState.Detached;

                if (entity != null)
                {
                    result.Entity = entity;
                    result.Status = StatusEnum.Success;
                }
                else
                {
                    result.Status = StatusEnum.Warning;
                }
            }
            catch (Exception ex)
            {
                result.Status = StatusEnum.Exception;
                result.Messages.Add(ex.Message);
                result.Details = ex.StackTrace;
            }

            return result;
        }

        public virtual async Task<ResultEntity<TEntity>> Insert(TEntity entity)
        {
            ResultEntity<TEntity> result = new();

            try
            {
                _db.Set<TEntity>().Add(entity);
                await _db.SaveChangesAsync();


                result.Entity = entity;
                result.Status = StatusEnum.Success;
            }
            catch (Exception ex)
            {
                result.Status = StatusEnum.Exception;
                result.Messages.Add(ex.Message);
                result.Details = ex.StackTrace;
            }

            return result;
        }

        public virtual async Task<ResultEntity<TEntity>> Update(TEntity entity)
        {
            ResultEntity<TEntity> result = new();

            try
            {
                _db.Entry(entity).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                result.Entity = entity;
                result.Status = StatusEnum.Success;
            }
            catch (Exception ex)
            {
                result.Status = StatusEnum.Exception;
                result.Messages.Add(ex.Message);
                result.Details = ex.StackTrace;
            }

            return result;
        }
    }
}
