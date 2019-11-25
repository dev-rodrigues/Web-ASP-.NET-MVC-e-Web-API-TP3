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
        }

        public Friend FindById(int id) {
            var amigos = Database.GetInstance.Friends.ToList();

            foreach(Friend f in amigos) {
                if(f.Id == id) {
                    return f;
                }
            }

            //Friend amigo = (Friend) Database.GetInstance.Friends.Where(x => x.Id == id);
            return null;
        }

        public List<Friend> Friends() {
            var lista = new List<Friend>();
            lista = Database.GetInstance.Friends.ToList();
            return lista;
        }

        public bool Update(Friend friend) {
            try {
                Database.GetInstance.Entry<Friend>(friend).State = EntityState.Modified;
                Database.GetInstance.SaveChanges();
                return true;
            } catch {
                Console.WriteLine("error");
            }
            return false;
        }
    }
}
