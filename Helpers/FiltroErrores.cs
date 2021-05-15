using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace historial_blockchain.Helpers
{
    public class FiltroErrores : ExceptionFilterAttribute
    {
        private readonly ILogger<FiltroErrores> logger;

        public FiltroErrores(ILogger<FiltroErrores> logger)
        {
            this.logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            logger.LogError(context.Exception, context.Exception.Message);
            base.OnException(context);
        }
    }
}
