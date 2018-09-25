using System;

namespace RestauranteWeb.CrossCutting.Utils
{
    public static class TypeUtil
    {
        public static bool HasValueByKey(this object valor)
        {
            switch (valor)
            {
                case long _long:
                    return _long > 0;
                case Guid _guid:
                    return _guid != Guid.Empty;
            }

            return false;
        }
    }
}
