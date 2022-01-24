using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Guards
{
    public static class Guard
    {
        public static void AgainstNull(object nullableObject)
        {
            if (nullableObject == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
