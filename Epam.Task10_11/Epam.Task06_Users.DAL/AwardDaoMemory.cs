using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_Users.DAL.Interface;
using Epam.Task06_Users.Entities;

namespace Epam.Task06_Users.DAL
{
    public class AwardDaoMemory : IAwardDao
    {
        private static readonly Dictionary<int, Award> _repoAwards = new Dictionary<int, Award>();

        public void Add(Award award)
        {
            var lastId = _repoAwards.Any()
                ? _repoAwards.Keys.Max()
                : 0;

            award.Id = ++lastId;

            _repoAwards.Add(award.Id, award);
        }

        public Award GetById(int id)
        {
            return _repoAwards.TryGetValue(id, out var user)
                ? user
                : null;
        }

        public bool CheckById(int id)
        {
            return _repoAwards.ContainsKey(id);
        }

        public IEnumerable<Award> GetAll()
        {
            return _repoAwards.Values;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
