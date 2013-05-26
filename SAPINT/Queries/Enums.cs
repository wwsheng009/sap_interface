namespace SAPINT.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    #region Enumerations
    public enum Kind
    {
        SelectOption,
        Parameter
    }
    public enum RangeOption
    {
        Equals,
        NotEquals,
        GreaterThan,
        LessThan,
        GreaterThanOrEqualTo,
        LessThanOrEqualTo,
        Between,
        NotBetween,
        MatchesPattern,
        NotMatchesPattern
    }
    public enum Sign
    {
        Include,
        Exclude
    }
    public enum WorkSpace
    {
        StandardArea,
        GlobalArea
    }
    #endregion Enumerations
}
