﻿// <auto-generated />
using ContactListProject.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContactListProject.Migrations
{
    [DbContext(typeof(ContactsContext))]
    partial class ContactsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ContactListProject.model.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Company");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Location");

                    b.Property<int>("ParentId")
                        .HasColumnType("int")
                        .HasColumnName("ParentId");

                    b.Property<string>("PhoneNumbers")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PhoneNumbers");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Position");

                    b.Property<int>("RowId")
                        .HasColumnType("int")
                        .HasColumnName("RowId");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}
