using Army.Core.DAL.Repositories;
using Army.Core.Infrastructure.Enums;
using Army.Core.Infrastructure.Models.Entites.Common;
using AutoMapper;

namespace Army.Core.BLL.Domains
{
    public class BaseDomain<TRepository, TEntity, TDTO> where TEntity : class
                                                     where TRepository : BaseRepository<TEntity>
                                                     where TDTO : class
    {
        protected readonly IMapper _mapper;
        protected readonly TRepository _repository;

        public BaseDomain(IMapper mapper, TRepository repository)
        {
            _mapper = mapper;
            _repository = repository;

        }

        public virtual async Task<ResultEntity<TDTO>> Insert(TDTO dto)
        {
            ResultEntity<TDTO> result = new();

            try
            {
                TEntity? entity = _mapper.Map<TDTO, TEntity>(dto);
                ResultEntity<TEntity>? repoResult = await _repository.Insert(entity);
                result = _mapper.Map<ResultEntity<TEntity>, ResultEntity<TDTO>>(repoResult);
            }
            catch (Exception ex)
            {
                result.Status = StatusEnum.Exception;
                result.Messages.Add(ex.Message);
                result.Details = ex.StackTrace;
            }

            return result;
        }

        public virtual async Task<ResultEntity<TDTO>> Update(TDTO dto)
        {
            ResultEntity<TDTO> result = new();

            try
            {
                TEntity? entity = _mapper.Map<TDTO, TEntity>(dto);
                ResultEntity<TEntity>? repoResult = await _repository.Update(entity);
                result = _mapper.Map<ResultEntity<TEntity>, ResultEntity<TDTO>>(repoResult);
            }
            catch (Exception ex)
            {
                result.Status = StatusEnum.Exception;
                result.Messages.Add(ex.Message);
                result.Details = ex.StackTrace;
            }

            return result;
        }

        public virtual async Task<ResultEntity<TDTO>> Delete(TDTO dto)
        {
            ResultEntity<TDTO> result = new();

            try
            {
                TEntity? entity = _mapper.Map<TDTO, TEntity>(dto);
                ResultEntity<TEntity>? repoResult = await _repository.Delete(entity);
                result = _mapper.Map<ResultEntity<TEntity>, ResultEntity<TDTO>>(repoResult);
            }
            catch (Exception ex)
            {
                result.Status = StatusEnum.Exception;
                result.Messages.Add(ex.Message);
                result.Details = ex.StackTrace;
            }

            return result;
        }

        public virtual async Task<ResultEntity<TDTO>> GetById(int id)
        {
            ResultEntity<TDTO> result = new();

            try
            {
                ResultEntity<TEntity>? repoResult = await _repository.GetById(id);
                result = _mapper.Map<ResultEntity<TEntity>, ResultEntity<TDTO>>(repoResult);
            }

            catch (Exception ex)
            {
                result.Status = StatusEnum.Exception;
                result.Messages.Add(ex.Message);
                result.Details = ex.StackTrace;
            }

            return result;
        }

        public virtual async Task<ResultList<TDTO>> GetAll()
        {
            ResultList<TDTO> result = new();

            try
            {
                ResultList<TEntity>? repoResult = await _repository.GetAll();
                result = _mapper.Map<ResultList<TEntity>, ResultList<TDTO>>(repoResult);
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

