using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSampleApp.Services.Interfaces
{
    public interface ILogManager
    {
        ILogger GetLog([System.Runtime.CompilerServices.CallerFilePath] string callerFilePath = "");
    }
}