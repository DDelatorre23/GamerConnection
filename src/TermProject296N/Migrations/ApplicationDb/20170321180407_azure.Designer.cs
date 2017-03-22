using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TermProject296N.Repository;

namespace TermProject296N.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170321180407_azure")]
    partial class azure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TermProject296N.Models.Game", b =>
                {
                    b.Property<int>("GameID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Platform");

                    b.Property<string>("Title");

                    b.Property<int>("TotalUsers");

                    b.Property<int?>("UserID");

                    b.HasKey("GameID");

                    b.HasIndex("UserID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("TermProject296N.Models.PartnerRequest", b =>
                {
                    b.Property<int>("PartnerRequestID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("HasBeenMatched");

                    b.Property<int?>("MatchedPartnerUserID");

                    b.Property<DateTime?>("RequestCompleted");

                    b.Property<DateTime>("RequestDate");

                    b.Property<int?>("RequesterUserID");

                    b.Property<int?>("SelectedGameGameID");

                    b.HasKey("PartnerRequestID");

                    b.HasIndex("MatchedPartnerUserID");

                    b.HasIndex("RequesterUserID");

                    b.HasIndex("SelectedGameGameID");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("TermProject296N.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("Id");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Nintendo_FriendCode")
                        .HasAnnotation("MaxLength", 12);

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PSN_UserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.Property<string>("Xbox_Gamertag");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TermProject296N.Models.Game", b =>
                {
                    b.HasOne("TermProject296N.Models.User")
                        .WithMany("FavoriteGames")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("TermProject296N.Models.PartnerRequest", b =>
                {
                    b.HasOne("TermProject296N.Models.User", "MatchedPartner")
                        .WithMany()
                        .HasForeignKey("MatchedPartnerUserID");

                    b.HasOne("TermProject296N.Models.User", "Requester")
                        .WithMany()
                        .HasForeignKey("RequesterUserID");

                    b.HasOne("TermProject296N.Models.Game", "SelectedGame")
                        .WithMany()
                        .HasForeignKey("SelectedGameGameID");
                });
        }
    }
}
