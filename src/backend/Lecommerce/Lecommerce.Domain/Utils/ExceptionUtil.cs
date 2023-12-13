using System.Text;

namespace Lecommerce.Domain.Utils
{
    public static class ExceptionUtil
    {
        public static string GetAllMessages(this Exception exception) 
        {
            StringBuilder msg = new StringBuilder();
            msg.Append(exception.Message);

            Exception innerException = exception.InnerException;
            int indexInner = 1;

            while (innerException != null)
            {
                msg.Append($" | Inner{indexInner}: {innerException.Message}");

                innerException = innerException.InnerException;
            }

            return msg.ToString();
        }
    }
}
