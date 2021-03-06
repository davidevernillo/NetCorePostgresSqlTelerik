﻿using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NetCorePostgresSqlTelerik.Services
{
    public class EmailSender:IEmailSender
    {
        // Our private configuration variables
        private string host;
        private int port;
        private bool enableSSL;
        private string userName;
        private string password;

        // Get our parameterized configuration
        public EmailSender(/*string host, int port, bool enableSSL, string userName, string password*/)
        {
            //this.host = host;
            //this.port = port;
            //this.enableSSL = enableSSL;
            //this.userName = userName;
            //this.password = password;
        }


        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            string host = "";
            int port = 0;
            bool enableSSL = true;
            string userName = "";
            string password = "";

            var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = true
            };
            return client.SendMailAsync(
                new MailMessage(userName, email, subject, htmlMessage) { IsBodyHtml = true }
            );
        }
    }
}
