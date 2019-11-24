using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Models;

namespace API.Models.InputFriend
{
    public class InputFriendBindingModel
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int[] Aniversario { get; set; }

        public Friend TransformInputIntoFriend(InputFriendBindingModel input)
        {
            Friend mockFriend = new Friend() {
                Aniversario = ConvertService(input.Aniversario),
                Email = input.Email,
                Nome = input.Nome,
                Sobrenome = input.Sobrenome,
                Telefone = input.Telefone
                
            };

         
            return mockFriend;
        }

        private DateTime ConvertService(int[] anoMesDia)
        {
            var ano = Convert.ToInt32(anoMesDia[0]);
            var mes = Convert.ToInt32(anoMesDia[1]);
            var dia = Convert.ToInt32(anoMesDia[2]);

            return new DateTime(ano, mes, dia);
        }
    }
}