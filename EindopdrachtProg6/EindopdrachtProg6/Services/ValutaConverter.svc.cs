using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EindopdrachtProg6.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ValutaConverter" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ValutaConverter.svc or ValutaConverter.svc.cs at the Solution Explorer and start debugging.
    public class ValutaConverter : IValutaConverter
    {
        decimal IValutaConverter.ConvertToJPY(decimal euro)
        {
            return (euro * (decimal)142.791);
        }

        decimal IValutaConverter.ConvertToUSD(decimal euro)
        {
            return (euro * (decimal)1.360);
        }
    }
}
