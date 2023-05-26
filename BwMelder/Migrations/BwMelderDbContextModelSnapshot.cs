﻿// <auto-generated />
using System;
using BwMelder.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BwMelder.Migrations
{
    [DbContext(typeof(BwMelderDbContext))]
    partial class BwMelderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("BwMelder.Model.Crew", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClubName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RaceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.ToTable("Crews");
                });

            modelBuilder.Entity("BwMelder.Model.HomeCoach", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CrewId")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CrewId")
                        .IsUnique();

                    b.ToTable("HomeCoaches");
                });

            modelBuilder.Entity("BwMelder.Model.Participant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Comments")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ShirtSize")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Participants", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Participant");
                });

            modelBuilder.Entity("BwMelder.Model.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Coxed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RowerCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Races");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Coxed = false,
                            Name = "Jung 1x 13",
                            Number = "A",
                            RowerCount = 1
                        },
                        new
                        {
                            Id = 2,
                            Coxed = false,
                            Name = "Jung 1x 13 LG",
                            Number = "B",
                            RowerCount = 1
                        },
                        new
                        {
                            Id = 3,
                            Coxed = false,
                            Name = "Mäd 1x 13",
                            Number = "C",
                            RowerCount = 1
                        },
                        new
                        {
                            Id = 4,
                            Coxed = false,
                            Name = "Mäd 1x 13 LG",
                            Number = "D",
                            RowerCount = 1
                        },
                        new
                        {
                            Id = 5,
                            Coxed = false,
                            Name = "Jung 2x 12/13",
                            Number = "E",
                            RowerCount = 2
                        },
                        new
                        {
                            Id = 6,
                            Coxed = false,
                            Name = "Jung 2x 12/13 LG",
                            Number = "F",
                            RowerCount = 2
                        },
                        new
                        {
                            Id = 7,
                            Coxed = false,
                            Name = "Mäd 2x 12/13",
                            Number = "G",
                            RowerCount = 2
                        },
                        new
                        {
                            Id = 8,
                            Coxed = false,
                            Name = "Mäd 2x 12/13 LG",
                            Number = "H",
                            RowerCount = 2
                        },
                        new
                        {
                            Id = 9,
                            Coxed = true,
                            Name = "Jung 4x+ 12/13",
                            Number = "I",
                            RowerCount = 4
                        },
                        new
                        {
                            Id = 10,
                            Coxed = true,
                            Name = "Mäd 4x+ 12/13",
                            Number = "J",
                            RowerCount = 4
                        },
                        new
                        {
                            Id = 11,
                            Coxed = true,
                            Name = "Jung/Mäd 4x+ 12/13 Mix",
                            Number = "K",
                            RowerCount = 4
                        },
                        new
                        {
                            Id = 12,
                            Coxed = false,
                            Name = "Jung 1x 14",
                            Number = "L",
                            RowerCount = 1
                        },
                        new
                        {
                            Id = 13,
                            Coxed = false,
                            Name = "Jung 1x 14 LG",
                            Number = "M",
                            RowerCount = 1
                        },
                        new
                        {
                            Id = 14,
                            Coxed = false,
                            Name = "Mäd 1x 14",
                            Number = "N",
                            RowerCount = 1
                        },
                        new
                        {
                            Id = 15,
                            Coxed = false,
                            Name = "Mäd 1x 14 LG",
                            Number = "O",
                            RowerCount = 1
                        },
                        new
                        {
                            Id = 16,
                            Coxed = false,
                            Name = "Jung 2x 13/14",
                            Number = "P",
                            RowerCount = 2
                        },
                        new
                        {
                            Id = 17,
                            Coxed = false,
                            Name = "Jung 2x 13/14 LG",
                            Number = "Q",
                            RowerCount = 2
                        },
                        new
                        {
                            Id = 18,
                            Coxed = false,
                            Name = "Mäd 2x 13/14",
                            Number = "R",
                            RowerCount = 2
                        },
                        new
                        {
                            Id = 19,
                            Coxed = false,
                            Name = "Mäd 2x 13/14 LG",
                            Number = "S",
                            RowerCount = 2
                        },
                        new
                        {
                            Id = 20,
                            Coxed = true,
                            Name = "Jung 4x+ 13/14",
                            Number = "T",
                            RowerCount = 4
                        },
                        new
                        {
                            Id = 21,
                            Coxed = true,
                            Name = "Mäd 4x+ 13/14",
                            Number = "U",
                            RowerCount = 4
                        },
                        new
                        {
                            Id = 22,
                            Coxed = true,
                            Name = "Jung/Mäd 4x+ 13/14 Mix",
                            Number = "V",
                            RowerCount = 4
                        },
                        new
                        {
                            Id = 23,
                            Coxed = false,
                            Name = "SON 2x 12-14 Inklusion",
                            Number = "W",
                            RowerCount = 2
                        },
                        new
                        {
                            Id = 24,
                            Coxed = false,
                            Name = "SON 1x 12-14 Para",
                            Number = "X",
                            RowerCount = 1
                        },
                        new
                        {
                            Id = 25,
                            Coxed = false,
                            Name = "SON 2x 15-18 Inklusion",
                            Number = "1",
                            RowerCount = 2
                        },
                        new
                        {
                            Id = 26,
                            Coxed = false,
                            Name = "SON 1x 15-18 Para",
                            Number = "2",
                            RowerCount = 1
                        });
                });

            modelBuilder.Entity("BwMelder.Model.Athlete", b =>
                {
                    b.HasBaseType("BwMelder.Model.Participant");

                    b.Property<Guid>("CrewId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCox")
                        .HasColumnType("INTEGER");

                    b.HasIndex("CrewId");

                    b.HasDiscriminator().HasValue("Athlete");
                });

            modelBuilder.Entity("BwMelder.Model.TeamCoach", b =>
                {
                    b.HasBaseType("BwMelder.Model.Participant");

                    b.Property<string>("ClubName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DriversLicense")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("TeamCoach");
                });

            modelBuilder.Entity("BwMelder.Model.Crew", b =>
                {
                    b.HasOne("BwMelder.Model.Race", "Race")
                        .WithMany("Crews")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");
                });

            modelBuilder.Entity("BwMelder.Model.HomeCoach", b =>
                {
                    b.HasOne("BwMelder.Model.Crew", null)
                        .WithOne("HomeCoach")
                        .HasForeignKey("BwMelder.Model.HomeCoach", "CrewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("BwMelder.Model.Contact", "Contact", b1 =>
                        {
                            b1.Property<Guid>("HomeCoachId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("EmailAddress")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Phone")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("HomeCoachId");

                            b1.ToTable("HomeCoaches");

                            b1.WithOwner()
                                .HasForeignKey("HomeCoachId");
                        });

                    b.Navigation("Contact")
                        .IsRequired();
                });

            modelBuilder.Entity("BwMelder.Model.Participant", b =>
                {
                    b.OwnsOne("BwMelder.Model.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("ParticipantId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Zip")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("ParticipantId");

                            b1.ToTable("Participants");

                            b1.WithOwner()
                                .HasForeignKey("ParticipantId");
                        });

                    b.OwnsOne("BwMelder.Model.Diet", "Diet", b1 =>
                        {
                            b1.Property<Guid>("ParticipantId")
                                .HasColumnType("TEXT");

                            b1.Property<int>("Choice")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Restrictions")
                                .HasColumnType("TEXT");

                            b1.HasKey("ParticipantId");

                            b1.ToTable("Participants");

                            b1.WithOwner()
                                .HasForeignKey("ParticipantId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Diet")
                        .IsRequired();
                });

            modelBuilder.Entity("BwMelder.Model.Athlete", b =>
                {
                    b.HasOne("BwMelder.Model.Crew", null)
                        .WithMany("Athletes")
                        .HasForeignKey("CrewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("BwMelder.Model.LegalGuardian", "LegalGuardian", b1 =>
                        {
                            b1.Property<Guid>("AthleteId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("AthleteId");

                            b1.ToTable("Participants");

                            b1.WithOwner()
                                .HasForeignKey("AthleteId");

                            b1.OwnsOne("BwMelder.Model.Contact", "Contact", b2 =>
                                {
                                    b2.Property<Guid>("LegalGuardianAthleteId")
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("EmailAddress")
                                        .IsRequired()
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("Phone")
                                        .IsRequired()
                                        .HasColumnType("TEXT");

                                    b2.HasKey("LegalGuardianAthleteId");

                                    b2.ToTable("Participants");

                                    b2.WithOwner()
                                        .HasForeignKey("LegalGuardianAthleteId");
                                });

                            b1.Navigation("Contact")
                                .IsRequired();
                        });

                    b.Navigation("LegalGuardian")
                        .IsRequired();
                });

            modelBuilder.Entity("BwMelder.Model.TeamCoach", b =>
                {
                    b.OwnsOne("BwMelder.Model.Contact", "Contact", b1 =>
                        {
                            b1.Property<Guid>("TeamCoachId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("EmailAddress")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Phone")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("TeamCoachId");

                            b1.ToTable("Participants");

                            b1.WithOwner()
                                .HasForeignKey("TeamCoachId");
                        });

                    b.Navigation("Contact")
                        .IsRequired();
                });

            modelBuilder.Entity("BwMelder.Model.Crew", b =>
                {
                    b.Navigation("Athletes");

                    b.Navigation("HomeCoach");
                });

            modelBuilder.Entity("BwMelder.Model.Race", b =>
                {
                    b.Navigation("Crews");
                });
#pragma warning restore 612, 618
        }
    }
}
