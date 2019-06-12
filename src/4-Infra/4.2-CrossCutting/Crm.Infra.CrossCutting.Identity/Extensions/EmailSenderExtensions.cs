﻿using Crm.Domain.Interfaces.Services;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Crm.Infra.CrossCutting.Identity.Extensions
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailService emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirm your email",
                $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }
    }
}