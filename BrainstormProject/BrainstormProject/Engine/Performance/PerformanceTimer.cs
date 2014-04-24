using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrainstormProject.Engine.Performance
{
    public static sealed class PerformanceTimer
    {
        private static uint ElapsedTime;
        private static DateTime EventBegin;
        private static DateTime EventEnd;

        public PerformanceTimer()
        {
            ElapsedTime = 0;
        }

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