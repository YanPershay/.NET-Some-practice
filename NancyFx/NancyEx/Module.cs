using Nancy;

namespace NancyFx
{
    public class Module : NancyModule
    {
        public Module()
        {
            Get("/", args => "Welcome to Nancy.");
            Get("/Test", args => "Test Message.");
            Get("/Hello", args => $"Hello {this.Request.Query["name"]}");
        }
    }
}
