using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test1
{
    class Automata_0i : SistemaFanucAntiguo
    {
        public Automata_0i()
        {
            m_FanucGlobalVariables.m_dTipoAutomata = 1;
        }
        public override bool FanucEnviarFicheroDataServer(ushort HandleLocal, string FicheroISO, Int32 dNumeroPrograma)
        {
            System.IO.File.WriteAllText("O4321", "O4321\nM30\n%");
            ftp ftpClient = new ftp(m_FanucGlobalVariables.IPDataServer, "TECOI", "TECOI");
            ftpClient.upload("O4321", "O4321");
            ret = (Focas1.focas_ret)Focas1.cnc_pdf_slctmain(HandleLocal, "//DATA_SV/O4321");
            ftpClient.delete("etc/test.txt");
            ftpClient.upload(FicheroISO, "O4321");
            ftpClient = null;
            FanucModoEdit();
            ret = (Focas1.focas_ret)Focas1.cnc_pdf_slctmain(HandleLocal, "//CNC_MEM/USER/PATH1/O1235");
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public override bool LeerAlarmasFanuc(ushort HandleLocal, ref string Texto)
        {
            return (true);
        }
    }
}
