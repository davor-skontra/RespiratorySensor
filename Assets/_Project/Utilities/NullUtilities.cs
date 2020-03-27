using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Utilities
{
    public static class NullUtilities
    {
        public static bool IsNullOrDefault<TAny>(this TAny item) =>
            EqualityComparer<TAny>.Default.Equals(item, default);
    }
}