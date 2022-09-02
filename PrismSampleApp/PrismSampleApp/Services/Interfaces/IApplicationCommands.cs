using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSampleApp.Services.Interfaces
{
    public interface IApplicationCommands
    {
        CompositeCommand ShowAllCommand { get; }
    }
}
