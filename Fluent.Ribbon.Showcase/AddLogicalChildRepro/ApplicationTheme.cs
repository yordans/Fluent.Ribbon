namespace FluentTest.AddLogicalChildRepro
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum ApplicationTheme
    {
        None, // Represent uninitialized state, this is not a valid theme and should not be used in production code. it serves as a placeholder to detect issues with the initialization of the theme system.
        Light,
        Dark
    }
}
