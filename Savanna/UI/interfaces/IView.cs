using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    /// <summary>
    /// Game output.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Show current field state.
        /// </summary>
        void Display(Field field);
    }
}
