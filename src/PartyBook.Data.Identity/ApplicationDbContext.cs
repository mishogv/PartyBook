﻿//namespace PartyBook.Data
//{
//    using IdentityServer4.EntityFramework.Options;
//    using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
//    using Microsoft.EntityFrameworkCore;
//    using Microsoft.Extensions.Options;
//    using PartyBook.Data.Identity.Models;

//    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
//    {
//        public ApplicationDbContext(
//            DbContextOptions options,
//            IOptions<OperationalStoreOptions> operationalStoreOptions)
//            : base(options, operationalStoreOptions)
//        {
//        }

//        protected override void OnModelCreating(ModelBuilder builder)
//        {
//            base.OnModelCreating(builder);
//        }
//    }
//}
