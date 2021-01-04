using Nancy;
using System;
using System.Collections.Generic;
using System.Text;

namespace NancyFx
{
    class Module : NancyModule
    {
        public Module()
        {
            Get("/", args => "Welcome to Nancy.");
            Get("/Test", args => "Test Message.");
            Get("/Hello", args => $"Hello {this.Request.Query["name"]}");
        }
    }
}
