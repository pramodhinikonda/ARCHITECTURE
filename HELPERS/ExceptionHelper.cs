using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y_HELPERS
{
    public class ExceptionHelper
    {
        public static Notification CreateBaseErrors(Exception ex)
        {
            Notification error = new Notification { description = ex.Message, stackTrace = ex.ToString(), type = NotificationType.Error };
            return error;
        }
    }
}
