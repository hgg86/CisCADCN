using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test1
{
    class EjeRotatorio : EjeMaquina
    {
        public EjeRotatorio(int dIndiceEje)
        { 
            m_dTipoEje = 2;
            m_dIndiceEje = dIndiceEje;
        }
    }
}
