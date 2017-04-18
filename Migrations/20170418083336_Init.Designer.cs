using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;


namespace Test.Migrations
{
    [DbContext(typeof(MemberContext))]
    [Migration("20170418083336_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("Article", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("content");

                    b.Property<int>("memberid");

                    b.Property<string>("title");

                    b.HasKey("id");

                    b.HasIndex("memberid");

                    b.ToTable("articles");
                });

            modelBuilder.Entity("Member", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("members");
                });

            modelBuilder.Entity("Article", b =>
                {
                    b.HasOne("Member", "member")
                        .WithMany("articles")
                        .HasForeignKey("memberid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
