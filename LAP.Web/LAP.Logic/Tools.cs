using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using iTextSharp.text.pdf;
using System.Data;
using iTextSharp.text.pdf.parser;
using System.util.collections;
using iTextSharp.text;
using System.Net.Mail;

namespace LAP.Logic
{
    /// <summary>
    /// A class meant for general tools to help in all situations.
    /// </summary>
    public class Tools
    {
        private static readonly log4net.ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// SHA512 Algorythmus Hash
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static byte[] GetSHA512(string plainText)
        {
            log.Info("GetSHA512(plainText)");
            byte[] hash = null;
            try
            {
                if (string.IsNullOrEmpty(plainText))
                {
                    log.Error("Empty plainText");
                    throw new ArgumentNullException(nameof(plainText));
                }
                else
                {
                    SHA512 algo = SHA512.Create();
                    byte[] plainTextBuffer = Encoding.UTF8.GetBytes(plainText);
                    hash = algo.ComputeHash(plainTextBuffer);
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception in GetSHA512", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in GetSHA512 (inner)", ex.InnerException);
                throw;
            }

            return hash;
        }

        private void SendEmail(MemoryStream ms)
        {
            MailAddress _From = new MailAddress("dzallinger@gmx.at");
            MailAddress _To = new MailAddress("dzallinger@gmx.at");
            MailMessage email = new MailMessage(_From, _To);
            Attachment attach = new Attachment(ms, new System.Net.Mime.ContentType("application/pdf"));
            email.Attachments.Add(attach);
            SmtpClient mailSender = new SmtpClient("srv08.itccn.loc");
            mailSender.Send(email);
            
        }

        //private void DownloadAsPDF(MemoryStream ms)
        //{
        //    Response.Clear();
        //    Response.ClearContent();
        //    Response.ClearHeaders();
        //    Response.ContentType = "application/pdf";
        //    Response.AppendHeader("Content-Disposition", "attachment;filename=abc.pdf");
        //    Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
        //    Response.OutputStream.Flush();
        //    Response.OutputStream.Close();
        //    Response.End();
        //    ms.Close();
        //}
        //Helper functions



    }
}
