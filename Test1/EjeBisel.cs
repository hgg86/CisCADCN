using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test1
{
    class EjeBisel : EjeMaquina
    {
        public EjeBisel(int dIndiceEje)
        { 
            m_dTipoEje = 3;
            m_dIndiceEje = dIndiceEje;
        }
    }
}
