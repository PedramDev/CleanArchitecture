using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Tools.Exceptions
{
    [Serializable]
    public class UserFriendlyException : Exception
    {
        public UserFriendlyException() { }

        public UserFriendlyException(string message)
            : base(message) { }
    }
}
