﻿using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.DAL.Entities
{
    public class User : Entity
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string ConfirmationToken { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public string Email { get; set; }

        public bool IsConfirmed { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }

    }
}
