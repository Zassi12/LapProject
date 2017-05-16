﻿using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LAP.Logic
{
    /// <summary>
    /// A class meant for general tools to help in all situations.
    /// </summary>
    public class Tools
    {
        private static readonly log4net.ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static byte[] GetSHA2(string plainText)
        {
            log.Info("GetSHA2(plainText)");
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
                log.Error("Exception in GetSHA2", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in GetSHA2 (inner)", ex.InnerException);
                throw;
            }

            return hash;
        }
      


    }
}
