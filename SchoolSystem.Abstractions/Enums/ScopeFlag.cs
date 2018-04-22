using System;

namespace SchoolSystem.Abstractions.Enums
{
    [Flags]
    public enum ScopeFlag
    {
        Teacher = 1 << 0,
        Admin = 1 << 1,
        Master = 1 << 2
    }
}