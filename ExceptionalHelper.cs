using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMWTEST
{
    public static class ExceptionalHelper
    {
        
            public static int LineNumber(this Exception e)
            {
                int linenum = 0;
                try
                {
                    linenum = Convert.ToInt32(e.StackTrace.Substring(e.StackTrace.LastIndexOf(":line") + 5));
                }
                catch
                {

                }

                return linenum;
            }
        
    }
}
