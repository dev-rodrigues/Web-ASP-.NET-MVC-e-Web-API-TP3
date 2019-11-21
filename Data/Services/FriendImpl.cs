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
    class FriendImpl : IFriend
    {


        public bool Create(Friend friend)
        {
            try
            {
                Database.GetInstance.Users.Add(friend);
                Context.Database.GetInstance.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            return false;
        }




        public bool Delete(Friend friend)
        {
            throw new NotImplementedException();
        }




        public Task<Friend> FindById(string id)
        {
            Friend friend = null;

            //TODO: precisa criar a lista FriendList no db context

            List<Friend> friends = await Database.GetInstance.FriendList.Where(x => x.Id.ToString().Equals(id)).ToListAsync();

            foreach (Friend u in friends)
            {
                if (u.Id.ToString().Equals(id))
                {
                    friend = u;
                    break;
                }
            }
            return friend;
        }




        public bool Update(Friend friend)
        {
            string nascimento = $"{friend.Aniversario.Day}-{friend.Aniversario.Month}-{friend.Aniversario.Year}";

            string query = $"Update dbo.FriendList Set " +
                            $"Nome = '{friend.Nome}', " +
                            $"Email = '{friend.Email}', " +
                            $"Aniversário = {nascimento}, " +
                            $"Sobrenome = {friend.Sobrenome}, " +
                            $"Telefone = '{friend.Telefone}' " +
                            $"where Email = '{friend.Email}' ";

            try
            {
                Database
                    .GetInstance
                    .Database
                    .ExecuteSqlCommand(query);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
    }
}
