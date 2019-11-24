using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IFriend
    {
        bool Create(Friend friend);

        bool Update(Friend friend);

        void Delete(int id);

        Friend FindById(int id);

        List<Friend> Friends();
    }
}
