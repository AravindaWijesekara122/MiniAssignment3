using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Enums
{
    public static class KWAllowedExtensions
    {
        public static decimal GetBasePrice(this KWAllowed kwAllowed)
        {
            switch (kwAllowed)
            {
                case KWAllowed.KW_4:
                    return 499m;

                case KWAllowed.KW_6:
                    return 699m;

                case KWAllowed.KW_8:
                    return 1099m;

                default:
                    throw new ArgumentOutOfRangeException(nameof(kwAllowed), kwAllowed, null);
            }
        }
    }
}
