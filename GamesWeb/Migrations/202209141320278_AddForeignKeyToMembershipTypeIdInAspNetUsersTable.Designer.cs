﻿// <auto-generated />
namespace GamesWeb.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.4.4")]
    public sealed partial class AddForeignKeyToMembershipTypeIdInAspNetUsersTable : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddForeignKeyToMembershipTypeIdInAspNetUsersTable));
        
        string IMigrationMetadata.Id
        {
            get { return "202209141320278_AddForeignKeyToMembershipTypeIdInAspNetUsersTable"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
