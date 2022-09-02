using Prism.Commands;
using PrismSampleApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSampleApp.ApplicationCommand
{
    public class ApplicationCommands : IApplicationCommands
    {
        private CompositeCommand _showAllCommand = new CompositeCommand();
        public CompositeCommand ShowAllCommand
        {
            get { return _showAllCommand; }
        }
    }
}
