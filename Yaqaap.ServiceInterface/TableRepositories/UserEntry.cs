﻿using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;
using ServiceStack.Auth;

namespace Yaqaap.ServiceInterface.TableRepositories
{
    public class UserEntry : TableEntity, IUserAuth
    {
        public UserEntry()
        {
        }

        public UserEntry(Guid id, string username)
        {
            PartitionKey = id.ToString();

            username = TableEntityHelper.RemoveDiacritics(username);
            username = TableEntityHelper.ToAzureKeyString(username);

            RowKey = username;
        }

        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthDateRaw { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Culture { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Language { get; set; }
        public string MailAddress { get; set; }
        public string Nickname { get; set; }
        public string PostalCode { get; set; }
        public string TimeZone { get; set; }

        [IgnoreProperty]
        public Dictionary<string, string> Meta { get; set; }

        public int Id { get; set; }
        public string PrimaryEmail { get; set; }
        public string Salt { get; set; }
        public string PasswordHash { get; set; }
        public string DigestHa1Hash { get; set; }

        [IgnoreProperty]
        public List<string> Roles { get; set; }

        [IgnoreProperty]
        public List<string> Permissions { get; set; }

        public int? RefId { get; set; }
        public string RefIdStr { get; set; }
        public int InvalidLoginAttempts { get; set; }
        public DateTime? LastLoginAttempt { get; set; }
        public DateTime? LockedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Guid GetUserId()
        {
            return Guid.Parse(PartitionKey);
        }
    }
}