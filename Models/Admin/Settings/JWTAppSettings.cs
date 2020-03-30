using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Admin.Settings
{
    public class JWTAppSettings
    {
        public string Secret { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
    }
}
