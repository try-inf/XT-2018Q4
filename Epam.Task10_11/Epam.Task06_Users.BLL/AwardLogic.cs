using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_Users.BLL.Interface;
using Epam.Task06_Users.DAL.Interface;
using Epam.Task06_Users.Entities;
using Epam.Task06_Users.Entities.Exceptions;

namespace Epam.Task06_Users.BLL
{
    public class AwardLogic : IAwardLogic
    {
        private const string ALL_AWARDS_CACHE_KEY = "GetAllAwards";
        private readonly IAwardDao _awardDao;
        private readonly ICacheLogic _cacheLogic;

        public AwardLogic(IAwardDao awardDao, ICacheLogic cacheLogic)
        {
            this._awardDao = awardDao;
            this._cacheLogic = cacheLogic;
        }

        public void Add(Award award)
        {
            try
            {
                if (award == null)
                {
                    throw new ValidationException("Award is null");
                }

                this._cacheLogic.Delete(ALL_AWARDS_CACHE_KEY);
                this._awardDao.Add(award);
            }
            catch
            {
                throw;
            }
        }

        public Award GetById(int id)
        {
            return this._awardDao.GetById(id);
        }

        public bool CheckById(int id)
        {
            return this._awardDao.CheckById(id);
        }

        public IEnumerable<Award> GetAll()
        {
            var cacheResult = this._cacheLogic.Get<IEnumerable<Award>>(ALL_AWARDS_CACHE_KEY);

            if (cacheResult == null)
            {
                var result = this._awardDao.GetAll();
                this._cacheLogic.Add(ALL_AWARDS_CACHE_KEY, result);

                return result;
            }

            return cacheResult;
        }

        public bool Delete(int id)
        {
            this._cacheLogic.Delete(ALL_AWARDS_CACHE_KEY);
            return this._awardDao.Delete(id);
        }
    }
}
