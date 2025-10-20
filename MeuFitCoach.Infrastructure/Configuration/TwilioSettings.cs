using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuFitCoach.Infrastructure.Configuration
{
    public  class TwilioSettings
    {
        public string AuthToken { get; set; }
        public string AccountSID { get; set; }
        public string WhatsappNumber { get; set; }

    }
}
