using Core.Services;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Services
{
    public class ServiceLocator
    {
        private static Dictionary<Type, Type> Friend = new Dictionary<Type, Type>
        {
            [typeof(IFriend)] = typeof(FriendRepository)
        };

        internal static T GetInstanceOf<T>()
        {
            return Activator.CreateInstance<T>();
        }
    }
}