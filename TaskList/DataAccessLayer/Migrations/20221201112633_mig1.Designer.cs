// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20221201112633_mig1")]
    partial class mig1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("EntityLayer.TaskComment", b =>
                {
                    b.Property<int>("comment_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("TaskOwnerowner_id")
                        .HasColumnType("int");

                    b.Property<string>("comment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("comment_id");

                    b.HasIndex("TaskOwnerowner_id");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("EntityLayer.TaskOwner", b =>
                {
                    b.Property<int>("owner_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("comment_id")
                        .HasColumnType("int");

                    b.Property<string>("owner_explanation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("owner_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("owner_status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("owner_task_title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("owner_id");

                    b.ToTable("taskOwner");
                });

            modelBuilder.Entity("EntityLayer.User", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("user_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("user_pword")
                        .HasColumnType("int");

                    b.Property<string>("user_role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("user_id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("EntityLayer.TaskComment", b =>
                {
                    b.HasOne("EntityLayer.TaskOwner", "TaskOwner")
                        .WithMany("comment")
                        .HasForeignKey("TaskOwnerowner_id");

                    b.Navigation("TaskOwner");
                });

            modelBuilder.Entity("EntityLayer.TaskOwner", b =>
                {
                    b.Navigation("comment");
                });
#pragma warning restore 612, 618
        }
    }
}
