using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GSAppLogic.DTO
{
    public class UserDTO : BaseModelDTO, IDataErrorInfo
    {
        public override string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatingPassword { get; set; }

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case "Password":
                        {
                            if (Password?.Length <= 5)
                            {
                                error = "Минимальная длина пароля = 6";
                            }
                            break;
                        }
                    case "Name":
                        {
                            if (UnitOfWork.userRepository.Get(Name) != null)
                            {
                                error = "Имя уже существует";
                                break;
                            }
                            if (Name?.Length <= 2)
                            {
                                error = "Минимальная длина имени = 3";
                                break;
                            }
                            if (Int32.TryParse(Name, out int x))
                            {
                                error = "Имя должно состоять не только из цифр";
                                break;
                            }
                            break;
                        }
                    case "Email":
                        {
                            if (UnitOfWork.userRepository.GetByEmail(Email) != null)
                            {
                                error = "Такой адрес уже существует";
                                break;
                            }

                            if (!Regex.IsMatch(Email ?? string.Empty, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                            {
                                error = "Введите корректный адрес";
                                break;
                            }
                            break;
                        }
                    case "RepeatingPassword":
                        {
                            if (RepeatingPassword != Password)
                            {
                                error = "Пароли не совпадают";
                                break;
                            }
                            break;
                        }
                }
                return error;
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        
    }
}
