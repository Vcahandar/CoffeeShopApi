using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Common.Constants
{
    public class ExceptionResponseMessages
    {
        public const string ExistMessage = "Data already exist";
        public const string NotFoundMessage = "Data not found";
        public const string ParametrNotFoundMessage = "Parametr not found";
        public const string FailedMessage = "Failed";
        public const string WrongMessage = "Email or password is wrong";
        public const string UserFailedMessage = "User could not be created";
        public const string UserSuccesMessage = "User created";
        public const string SuccesMessage = "Success";
        public const string DeleteFailedMessage = "İtem must be minimum one";
    }
}
