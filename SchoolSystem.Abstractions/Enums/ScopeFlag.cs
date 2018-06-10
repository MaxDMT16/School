using System;

namespace SchoolSystem.Abstractions.Enums
{
    [Flags]
    public enum ScopeFlag
    {
        Pupil = 1 << 0,
        Teacher = 1 << 1,
        Admin = 1 << 2,
        Master = 1 << 3
    }
}