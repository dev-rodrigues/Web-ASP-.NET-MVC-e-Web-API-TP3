using Core.Models;
using Core.Services;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services {
    public class FriendRepository : IFriend {
        public bool Create(Friend friend) {
            try {
                DatabaseContext.Create().Friends.Add(friend);
                DatabaseContext.Create().SaveChanges();
                return true;
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public void Delete(int id) {
            Friend f = DatabaseContext.Create().Friends.Find(id);
            DatabaseContext.Create().Friends.Remove(f);
            DatabaseContext.Create().SaveChanges();
        }

        public Friend FindById(int id) {
            var amigos = DatabaseContext.Create().Friends.ToList();

            foreach(Friend friend in amigos) {
                if(friend.Id == id) {
                    return friend;
                }
            }
            return null;
        }

        public List<Friend> Friends() {
            var lista = new List<Friend>();
            lista = DatabaseContext.Create().Friends.ToList();
            return lista;
        }

        public bool Update(Friend friend) {
            try {
                DatabaseContext.Create().Entry<Friend>(friend).State = EntityState.Modified;
                DatabaseContext.Create().SaveChanges();
                return true;
            } catch {
                Console.WriteLine("error");
            }
            return false;
        }
    }
}
