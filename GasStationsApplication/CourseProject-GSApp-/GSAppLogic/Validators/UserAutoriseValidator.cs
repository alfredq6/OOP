using GSAppLogic.DTO;
using GSAppLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSAppLogic.Validators
{
    public class UserAutoriseValidator
    {
        private UserDTO user;

        public UserAutoriseValidator(UserDTO _user)
        {
            user = _user;
        }

        public bool IsAutoriseDataValid()
        {
            return UnitOfWork.userRepository.Get(user.Name) != null && Crypto.VerifyHashedPassword(UnitOfWork.userRepository.Get(user.Name).Password, user.Password);
        }

        public bool IsDataFieldsValid()
        {
            return user["Name"] == string.Empty && user["Email"] == string.Empty && user["Password"] == string.Empty && user["RepeatingPassword"] == string.Empty;
        }
    }
}
