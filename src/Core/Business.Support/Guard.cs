using System;

namespace VouDeVan.Core.Business.Support
{
    public static class Guard
    {
        public static void IsNullOrWhiteSpace(string str, string message = "")
        {
            var expression = string.IsNullOrWhiteSpace(str);
            Argument(expression, message);
        }


        public static void IsNotNull(object obj, string message = "Is not null")
        {
            Argument(obj != null, message);
        }

        public static void Argument(bool expression, string message)
        {
            if (expression)
            {
                throw new ArgumentException(message);
            }
        }


        public static void Business(bool expression, string message)
        {
            if (!expression)
            {
                throw new BusinessException(message);
            }
        }

        public static void Business<T>(bool expression)
            where T : BusinessException, new()
        {
            if (!expression)
            {
                throw new T();
            }
        }
    }
}