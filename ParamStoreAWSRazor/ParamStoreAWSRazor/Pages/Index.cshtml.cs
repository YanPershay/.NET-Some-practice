using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ParamStoreAWSRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;
        private readonly MetaOptions Options;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, IOptionsSnapshot<MetaOptions> options)
        {
            Options = options.Value;
            _logger = logger;
            _configuration = configuration;
        }

        public void OnGet()
        {
            ViewData["Name"] = Options.QueueNamePrefix;
            ViewData["Surname"] = _configuration.GetSection("MetaOptions")["FirstName"];
        }
    }
}