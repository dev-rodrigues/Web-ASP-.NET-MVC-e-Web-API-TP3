using Core.Models;
using Core.Services;
using Data.Context;
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
            try
            {
                DatabaseContext.Create().Friends.Add(friend);
                DatabaseContext.Create().SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public bool Delete(Friend friend)
        {
            throw new NotImplementedException();
        }

        public Task<Friend> FindById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Friend> Friends()
        {
            var lista = new List<Friend>();
            lista = DatabaseContext.Create().Friends.ToList();
            return lista;
        }

        public bool Update(Friend friend)
        {
            throw new NotImplementedException();
        }
    }
}
