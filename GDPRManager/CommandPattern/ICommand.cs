using GDPRManager.ComponentPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.CommandPattern
{
    /// <summary>
    /// interface class ICommand
    /// </summary>
    public interface ICommand<T>
    {
        /// <summary>
        /// method for implementation
        /// </summary>
        /// <param name="t">Generic type we want to pass in</param>
        public void Execute(T t);
    }
}
