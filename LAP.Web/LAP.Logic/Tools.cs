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

            if (string.IsNullOrEmpty(plainText))
            {
                log.Error("Empty plainText");
                throw new ArgumentNullException(nameof(plainText));
            }
            else
            {
                SHA256 algo = SHA256.Create();
                byte[] plainTextBuffer = Encoding.UTF8.GetBytes(plainText);
                hash = algo.ComputeHash(plainTextBuffer);
            }

            return hash;
        }
    }
}
