using Core.Models;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database = Data.Context.Database;

namespace Data.Services {
    public class FriendRepository : IFriend {
        public bool Create(Friend friend) {
            try {

                Database.GetInstance.Friends.Add(friend);
                Database.GetInstance.SaveChanges();
                return true;
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public void Delete(int id) {
            Friend f = Database.GetInstance.Friends.Find(id);
            Database.GetInstance.Friends.Remove(f);
            Database.GetInstance.SaveChanges();

            //Friend f = DatabaseContext.Create().Friends.Find(id);
            //DatabaseContext.Create().Friends.Remove(f);
            //DatabaseContext.Create().SaveChanges();
        }

        public Friend FindById(int id) {

            Friend amigo = (Friend) Database.GetInstance.Friends.Where(x => x.Id == id);
            //var amigos = DatabaseContext.Create().Friends.ToList();

            //foreach(Friend friend in amigos) {
            //    if(friend.Id == id) {
            //        return friend;
            //    }
            //}
            return amigo;
        }

        public List<Friend> Friends() {
            var lista = new List<Friend>();
            lista = Database.GetInstance.Friends.ToList();
            return lista;
        }

        public bool Update(Friend friend) {
            try {
                Database.GetInstance.Entry<Friend>(friend).State = EntityState.Modified;
                //DatabaseContext.Create().Entry<Friend>(friend).State = EntityState.Modified;
                //DatabaseContext.Create().SaveChanges();
                Database.GetInstance.SaveChanges();
                return true;
            } catch {
                Console.WriteLine("error");
            }
            return false;
        }
    }
}
