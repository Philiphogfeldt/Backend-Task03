﻿using Backend_Task03.Data;
using Backend_Task03.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;


namespace Backend_Task03.Data
{
    public class AccessControl
    {
        public int LoggedInAccountID { get; set; }
        public string LoggedInAccountName { get; set; }
        public Account LoggedInAccount { get; set; }

        public AccessControl(AppDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext.User;
            string subject = user.FindFirst(ClaimTypes.NameIdentifier).Value;
            string issuer = user.FindFirst(ClaimTypes.NameIdentifier).Issuer;

            LoggedInAccount = db.Accounts.Single(p => p.OpenIDIssuer == issuer && p.OpenIDSubject == subject);
            LoggedInAccountID = LoggedInAccount.ID;
            // LoggedInAccountID = db.Accounts.Single(p => p.OpenIDIssuer == issuer && p.OpenIDSubject == subject).ID;
            LoggedInAccountName = user.FindFirst(ClaimTypes.Name).Value;
            // LoggedInAccount = db.Accounts.Single(p => p.OpenIDIssuer == issuer && p.OpenIDSubject == subject);
            // LoggedInAccount = db.Accounts.SingleOrDefault(a => a.Name == LoggedInAccountName);
        }

        public AccessControl()
        {

        }
    }
}


