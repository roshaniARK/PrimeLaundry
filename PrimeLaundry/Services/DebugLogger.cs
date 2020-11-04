using System;
using System.Diagnostics;
using Prism.Logging;

namespace PrimeLaundry.Services
{
    public class DebugLogger
    {
        public void Log(string message, Category category, Priority priority)
        {
            Debug.WriteLine($"{category} - {priority}: {message}");
        }
    }
}
