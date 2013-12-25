﻿using System;

namespace Tqcsi.Qlkh.Common
{
    public class ExceptionMessageFormatter : IExceptionMessageFormatter
    {
        public string GetEntireExceptionStack(Exception ex)
        {
            var message = ex.Message;
            var innerException = ex.InnerException;
            while (innerException != null)
            {
                message += " --> " + innerException.Message;
                innerException = innerException.InnerException;
            }

            return message;
        }
    }
}
