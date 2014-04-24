using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrainstormProject.Engine.Performance
{
    public static class PerformanceTimer
    {
        private static DateTime EventBegin;
        private static DateTime EventEnd;

        public static void BeginPerformanceEvent()
        {
            EventBegin = DateTime.UtcNow;
        }
        public static void EndPerformanceEvent()
        {
            EventEnd = DateTime.UtcNow;
        }
        public static double GetElapsedMilliseconds()
        {
            return (EventEnd - EventBegin).TotalMilliseconds;
        }
        public static double GetElapsedTicks()
        {
            return (EventEnd - EventBegin).Ticks;
        }
    }
}