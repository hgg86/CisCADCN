using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test1
{
    class Automata_30i : SistemaFanucAntiguo
    {
        #region Definición de variables
        Focas1.ODBALMMSG2 odbalmmsg2 = new Focas1.ODBALMMSG2();
        string [] szErrores = 
        {
        	"SV", "PW", "IO", "PS", "OT", "OH", "SV", "RS", "MC", "SP",
                "DS", "IE", "BG", "SN", "  ", "EX", "  ", "  ", "  ", "PC",
                "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ",
                "  "
        };
        #endregion

        public Automata_30i()
        {
            m_FanucGlobalVariables.m_dTipoAutomata = 2;
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
            ret = (Focas1.focas_ret)Focas1.cnc_pdf_slctmain(HandleLocal, "//DATA_SV/O1234");
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public override bool LeerAlarmasFanuc(ushort HandleLocal, ref string Texto)
        {
            short dNumAlarma = 10;
            int alarmBits;
            ret = (Focas1.focas_ret)Focas1.cnc_alarm2(HandleLocal, out alarmBits);
            if (alarmBits == 0)
                return (true);
            for (short i = 0; i < 32; i++)
            {
                if ((alarmBits & (1 << i)) != 0)  // If active)
                {
                    try
                    {
                        dNumAlarma = 10;
                        ret = (Focas1.focas_ret)Focas1.cnc_rdalmmsg2(HandleLocal, i, ref dNumAlarma, odbalmmsg2);
                        if (ret != Focas1.focas_ret.EW_OK)
                            continue;
                        for (short j = 0; j <= dNumAlarma; j++)
                        {
                            if (j == 0 && odbalmmsg2.msg1.msg_len > 0)
                                Texto += string.Format("{0}: ", odbalmmsg2.msg1.alm_no) + szErrores[i] + ": " +
                                    odbalmmsg2.msg1.alm_msg.Substring(0, odbalmmsg2.msg1.msg_len) + "\r\n";
                            if (j == 1 && odbalmmsg2.msg2.msg_len > 0)
                                Texto += string.Format("{0}: ", odbalmmsg2.msg2.alm_no) + szErrores[i] + ": " +
                                odbalmmsg2.msg2.alm_msg.Substring(0, odbalmmsg2.msg2.msg_len) + "\r\n";
                            if (j == 2 && odbalmmsg2.msg3.msg_len > 0)
                                Texto += string.Format("{0}: ", odbalmmsg2.msg3.alm_no) + szErrores[i] + ": " +
                                odbalmmsg2.msg3.alm_msg.Substring(0, odbalmmsg2.msg3.msg_len) + "\r\n";
                            if (j == 3 && odbalmmsg2.msg4.msg_len > 0)
                                Texto += string.Format("{0}: ", odbalmmsg2.msg4.alm_no) + szErrores[i] + ": " +
                                odbalmmsg2.msg4.alm_msg.Substring(0, odbalmmsg2.msg4.msg_len) + "\r\n";
                            if (j == 4 && odbalmmsg2.msg5.msg_len > 0)
                                Texto += string.Format("{0}: ", odbalmmsg2.msg5.alm_no) + szErrores[i] + ": " +
                                odbalmmsg2.msg5.alm_msg.Substring(0, odbalmmsg2.msg5.msg_len) + "\r\n";
                            if (j == 5 && odbalmmsg2.msg6.msg_len > 0)
                                Texto += string.Format("{0}: ", odbalmmsg2.msg6.alm_no) + szErrores[i] + ": " +
                                odbalmmsg2.msg6.alm_msg.Substring(0, odbalmmsg2.msg6.msg_len) + "\r\n";
                            if (j == 6 && odbalmmsg2.msg7.msg_len > 0)
                                Texto += string.Format("{0}: ", odbalmmsg2.msg7.alm_no) + szErrores[i] + ": " +
                                odbalmmsg2.msg7.alm_msg.Substring(0, odbalmmsg2.msg7.msg_len) + "\r\n";
                            if (j == 7 && odbalmmsg2.msg8.msg_len > 0)
                                Texto += string.Format("{0}: ", odbalmmsg2.msg8.alm_no) + szErrores[i] + ": " +
                                odbalmmsg2.msg8.alm_msg.Substring(0, odbalmmsg2.msg8.msg_len) + "\r\n";
                            if (j == 8 && odbalmmsg2.msg9.msg_len > 0)
                                Texto += string.Format("{0}: ", odbalmmsg2.msg9.alm_no) + szErrores[i] + ": " +
                                odbalmmsg2.msg9.alm_msg.Substring(0, odbalmmsg2.msg9.msg_len) + "\r\n";
                            if (j == 9 && odbalmmsg2.msg10.msg_len > 0)
                                Texto += string.Format("{0}: ", odbalmmsg2.msg10.alm_no) + szErrores[i] + ": " +
                                odbalmmsg2.msg10.alm_msg.Substring(0, odbalmmsg2.msg10.msg_len) + "\r\n";
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            return (true);
        }
    }
}
