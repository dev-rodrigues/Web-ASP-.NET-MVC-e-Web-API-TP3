using Core.Models;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class FriendRepository : IFriend
    {
        public bool Create(Friend friend)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Friend friend)
        {
            throw new NotImplementedException();
        }

        public Task<Friend> FindById(string id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Friend friend)
        {
            throw new NotImplementedException();
        }
    }
}
