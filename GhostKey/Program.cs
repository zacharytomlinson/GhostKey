﻿using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace GhostKey
{
    public partial class Crack
    {
        public static void Main()
        {
            while(true)
            {
                PreventSleep();
                Thread.Sleep(59000);
            }

            return;
        }

        [FlagsAttribute]
        public enum EXECUTION_STATE : uint
        {
            ES_SYSTEM_REQUIRED = 0x00000001,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
        }

        public static class SleepUtil
        {
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);
        }

        public static void PreventSleep()
        {
            SleepUtil.SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS 
                                            | EXECUTION_STATE.ES_DISPLAY_REQUIRED
                                            | EXECUTION_STATE.ES_SYSTEM_REQUIRED);
        }
    }
}
