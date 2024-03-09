﻿// <auto-generated />
using System;
using CroKnitters.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CroKnitters.Migrations
{
    [DbContext(typeof(CrochetAppDbContext))]
    [Migration("20240213183326_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CroKnitters.Entities.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("CroKnitters.Entities.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("ProvinceId")
                        .HasColumnType("int");

                    b.HasKey("CityId")
                        .HasName("PK__Cities__F2D21B763291A5A0");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("CroKnitters.Entities.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("CommentId")
                        .HasName("PK__Comments__C3B4DFCA7D1B4540");

                    b.HasIndex("OwnerId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("CroKnitters.Entities.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("EventTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("EventId")
                        .HasName("PK__Events__7944C810EEF9274C");

                    b.HasIndex("OwnerId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("CroKnitters.Entities.EventUser", b =>
                {
                    b.Property<int>("EventUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventUserId"));

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("EventUserId")
                        .HasName("PK__EventUse__75F92483FA2626FC");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("EventUsers");
                });

            modelBuilder.Entity("CroKnitters.Entities.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageId"));

                    b.Property<string>("ImageSrc")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("ImageId")
                        .HasName("PK__Images__7516F70CC8F1B07F");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("CroKnitters.Entities.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LanguageId"));

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("LanguageId")
                        .HasName("PK__Language__B93855ABA45758AD");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("CroKnitters.Entities.Pattern", b =>
                {
                    b.Property<int>("PatternId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatternId"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("PatternName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("StitchCount")
                        .HasColumnType("int");

                    b.Property<string>("StitchType")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("PatternId")
                        .HasName("PK__Patterns__0A631B521FCBD794");

                    b.HasIndex("AdminId");

                    b.HasIndex("ImageId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Patterns");
                });

            modelBuilder.Entity("CroKnitters.Entities.PatternComment", b =>
                {
                    b.Property<int>("PatComId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatComId"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<int>("PatternId")
                        .HasColumnType("int");

                    b.HasKey("PatComId")
                        .HasName("PK__PatternC__272DE03846EEF9E6");

                    b.HasIndex("AdminId");

                    b.HasIndex("CommentId");

                    b.HasIndex("PatternId");

                    b.ToTable("PatternComments");
                });

            modelBuilder.Entity("CroKnitters.Entities.PatternTag", b =>
                {
                    b.Property<int>("PatTagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatTagId"));

                    b.Property<int>("PatternId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("PatTagId")
                        .HasName("PK__PatternT__68421DA4E054EE9B");

                    b.HasIndex("PatternId");

                    b.HasIndex("TagId");

                    b.ToTable("PatternTags");
                });

            modelBuilder.Entity("CroKnitters.Entities.Preference", b =>
                {
                    b.Property<int>("PreferenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PreferenceId"));

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int>("ThemeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PreferenceId")
                        .HasName("PK__Preferen__E228496F2600B5A8");

                    b.HasIndex("LanguageId");

                    b.HasIndex("ThemeId");

                    b.HasIndex("UserId");

                    b.ToTable("Preferences");
                });

            modelBuilder.Entity("CroKnitters.Entities.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Status")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasDefaultValueSql("('In-Progress')");

                    b.HasKey("ProjectId")
                        .HasName("PK__Projects__761ABEF001154132");

                    b.HasIndex("AdminId");

                    b.HasIndex("ImageId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("CroKnitters.Entities.ProjectComment", b =>
                {
                    b.Property<int>("ProComId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProComId"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("ProComId")
                        .HasName("PK__ProjectC__FAF8CB4AAB204E27");

                    b.HasIndex("AdminId");

                    b.HasIndex("CommentId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectComments");
                });

            modelBuilder.Entity("CroKnitters.Entities.ProjectPattern", b =>
                {
                    b.Property<int>("ProPatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProPatId"));

                    b.Property<int>("PatternId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("ProPatId")
                        .HasName("PK__ProjectP__19B1EB93417F37D9");

                    b.HasIndex("PatternId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectPatterns");
                });

            modelBuilder.Entity("CroKnitters.Entities.ProjectTag", b =>
                {
                    b.Property<int>("ProTagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProTagId"));

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("ProTagId")
                        .HasName("PK__ProjectT__EA3BF1B886EBE45B");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TagId");

                    b.ToTable("ProjectTags");
                });

            modelBuilder.Entity("CroKnitters.Entities.Province", b =>
                {
                    b.Property<int>("ProvinceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProvinceId"));

                    b.Property<string>("ProvinceName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ProvinceId")
                        .HasName("PK__Province__FD0A6F83F858F43F");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("CroKnitters.Entities.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagId"));

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("TagId")
                        .HasName("PK__Tags__657CF9ACB4394FA8");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("CroKnitters.Entities.Theme", b =>
                {
                    b.Property<int>("ThemeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThemeId"));

                    b.Property<string>("ThemeTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ThemeId")
                        .HasName("PK__Themes__FBB3E4D98AE98BB3");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("CroKnitters.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Bio")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("UserId")
                        .HasName("PK__Users__1788CC4CEBD8424E");

                    b.HasIndex("CityId");

                    b.HasIndex("ImageId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CroKnitters.Entities.UserPattern", b =>
                {
                    b.Property<int>("UpatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UpatId"));

                    b.Property<int>("PatternId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UpatId")
                        .HasName("PK__UserPatt__900CF3B8C62046ED");

                    b.HasIndex("PatternId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPatterns");
                });

            modelBuilder.Entity("CroKnitters.Entities.UserProject", b =>
                {
                    b.Property<int>("UproId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UproId"));

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UproId")
                        .HasName("PK__UserProj__1DAD7D9709F4A257");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("UserProjects");
                });

            modelBuilder.Entity("CroKnitters.Entities.City", b =>
                {
                    b.HasOne("CroKnitters.Entities.Province", "Province")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceId")
                        .HasConstraintName("FK__Cities__Province__2E1BDC42");

                    b.Navigation("Province");
                });

            modelBuilder.Entity("CroKnitters.Entities.Comment", b =>
                {
                    b.HasOne("CroKnitters.Entities.User", "Owner")
                        .WithMany("Comments")
                        .HasForeignKey("OwnerId")
                        .IsRequired()
                        .HasConstraintName("FK__Comments__OwnerI__4AB81AF0");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CroKnitters.Entities.Event", b =>
                {
                    b.HasOne("CroKnitters.Entities.User", "Owner")
                        .WithMany("Events")
                        .HasForeignKey("OwnerId")
                        .IsRequired()
                        .HasConstraintName("FK__Events__OwnerId__34C8D9D1");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CroKnitters.Entities.EventUser", b =>
                {
                    b.HasOne("CroKnitters.Entities.Event", "Event")
                        .WithMany("EventUsers")
                        .HasForeignKey("EventId")
                        .IsRequired()
                        .HasConstraintName("FK__EventUser__Event__68487DD7");

                    b.HasOne("CroKnitters.Entities.User", "User")
                        .WithMany("EventUsers")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__EventUser__UserI__693CA210");

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CroKnitters.Entities.Pattern", b =>
                {
                    b.HasOne("CroKnitters.Entities.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CroKnitters.Entities.Image", "Image")
                        .WithMany("Patterns")
                        .HasForeignKey("ImageId")
                        .HasConstraintName("FK__Patterns__ImageI__3F466844");

                    b.HasOne("CroKnitters.Entities.User", "Owner")
                        .WithMany("Patterns")
                        .HasForeignKey("OwnerId")
                        .IsRequired()
                        .HasConstraintName("FK__Patterns__OwnerI__3E52440B");

                    b.Navigation("Admin");

                    b.Navigation("Image");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CroKnitters.Entities.PatternComment", b =>
                {
                    b.HasOne("CroKnitters.Entities.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CroKnitters.Entities.Comment", "Comment")
                        .WithMany("PatternComments")
                        .HasForeignKey("CommentId")
                        .IsRequired()
                        .HasConstraintName("FK__PatternCo__Comme__656C112C");

                    b.HasOne("CroKnitters.Entities.Pattern", "Pattern")
                        .WithMany("PatternComments")
                        .HasForeignKey("PatternId")
                        .IsRequired()
                        .HasConstraintName("FK__PatternCo__Patte__6477ECF3");

                    b.Navigation("Admin");

                    b.Navigation("Comment");

                    b.Navigation("Pattern");
                });

            modelBuilder.Entity("CroKnitters.Entities.PatternTag", b =>
                {
                    b.HasOne("CroKnitters.Entities.Pattern", "Pattern")
                        .WithMany("PatternTags")
                        .HasForeignKey("PatternId")
                        .IsRequired()
                        .HasConstraintName("FK__PatternTa__Patte__5CD6CB2B");

                    b.HasOne("CroKnitters.Entities.Tag", "Tag")
                        .WithMany("PatternTags")
                        .HasForeignKey("TagId")
                        .IsRequired()
                        .HasConstraintName("FK__PatternTa__TagId__5DCAEF64");

                    b.Navigation("Pattern");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("CroKnitters.Entities.Preference", b =>
                {
                    b.HasOne("CroKnitters.Entities.Language", "Language")
                        .WithMany("Preferences")
                        .HasForeignKey("LanguageId")
                        .IsRequired()
                        .HasConstraintName("FK__Preferenc__Langu__38996AB5");

                    b.HasOne("CroKnitters.Entities.Theme", "Theme")
                        .WithMany("Preferences")
                        .HasForeignKey("ThemeId")
                        .IsRequired()
                        .HasConstraintName("FK__Preferenc__Theme__398D8EEE");

                    b.HasOne("CroKnitters.Entities.User", "User")
                        .WithMany("Preferences")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Preferenc__UserI__37A5467C");

                    b.Navigation("Language");

                    b.Navigation("Theme");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CroKnitters.Entities.Project", b =>
                {
                    b.HasOne("CroKnitters.Entities.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CroKnitters.Entities.Image", "Image")
                        .WithMany("Projects")
                        .HasForeignKey("ImageId")
                        .HasConstraintName("FK__Projects__ImageI__45F365D3");

                    b.HasOne("CroKnitters.Entities.User", "Owner")
                        .WithMany("Projects")
                        .HasForeignKey("OwnerId")
                        .IsRequired()
                        .HasConstraintName("FK__Projects__OwnerI__44FF419A");

                    b.Navigation("Admin");

                    b.Navigation("Image");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CroKnitters.Entities.ProjectComment", b =>
                {
                    b.HasOne("CroKnitters.Entities.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CroKnitters.Entities.Comment", "Comment")
                        .WithMany("ProjectComments")
                        .HasForeignKey("CommentId")
                        .IsRequired()
                        .HasConstraintName("FK__ProjectCo__Comme__619B8048");

                    b.HasOne("CroKnitters.Entities.Project", "Project")
                        .WithMany("ProjectComments")
                        .HasForeignKey("ProjectId")
                        .IsRequired()
                        .HasConstraintName("FK__ProjectCo__Proje__60A75C0F");

                    b.Navigation("Admin");

                    b.Navigation("Comment");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("CroKnitters.Entities.ProjectPattern", b =>
                {
                    b.HasOne("CroKnitters.Entities.Pattern", "Pattern")
                        .WithMany("ProjectPatterns")
                        .HasForeignKey("PatternId")
                        .IsRequired()
                        .HasConstraintName("FK__ProjectPa__Patte__5629CD9C");

                    b.HasOne("CroKnitters.Entities.Project", "Project")
                        .WithMany("ProjectPatterns")
                        .HasForeignKey("ProjectId")
                        .IsRequired()
                        .HasConstraintName("FK__ProjectPa__Proje__5535A963");

                    b.Navigation("Pattern");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("CroKnitters.Entities.ProjectTag", b =>
                {
                    b.HasOne("CroKnitters.Entities.Project", "Project")
                        .WithMany("ProjectTags")
                        .HasForeignKey("ProjectId")
                        .IsRequired()
                        .HasConstraintName("FK__ProjectTa__Proje__59063A47");

                    b.HasOne("CroKnitters.Entities.Tag", "Tag")
                        .WithMany("ProjectTags")
                        .HasForeignKey("TagId")
                        .IsRequired()
                        .HasConstraintName("FK__ProjectTa__TagId__59FA5E80");

                    b.Navigation("Project");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("CroKnitters.Entities.User", b =>
                {
                    b.HasOne("CroKnitters.Entities.City", "City")
                        .WithMany("Users")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK__Users__CityId__30F848ED");

                    b.HasOne("CroKnitters.Entities.Image", "Image")
                        .WithMany("Users")
                        .HasForeignKey("ImageId")
                        .HasConstraintName("FK__Users__ImageId__31EC6D26");

                    b.Navigation("City");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("CroKnitters.Entities.UserPattern", b =>
                {
                    b.HasOne("CroKnitters.Entities.Pattern", "Pattern")
                        .WithMany("UserPatterns")
                        .HasForeignKey("PatternId")
                        .IsRequired()
                        .HasConstraintName("FK__UserPatte__Patte__4E88ABD4");

                    b.HasOne("CroKnitters.Entities.User", "User")
                        .WithMany("UserPatterns")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__UserPatte__UserI__4D94879B");

                    b.Navigation("Pattern");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CroKnitters.Entities.UserProject", b =>
                {
                    b.HasOne("CroKnitters.Entities.Project", "Project")
                        .WithMany("UserProjects")
                        .HasForeignKey("ProjectId")
                        .IsRequired()
                        .HasConstraintName("FK__UserProje__Proje__52593CB8");

                    b.HasOne("CroKnitters.Entities.User", "User")
                        .WithMany("UserProjects")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__UserProje__UserI__5165187F");

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CroKnitters.Entities.City", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("CroKnitters.Entities.Comment", b =>
                {
                    b.Navigation("PatternComments");

                    b.Navigation("ProjectComments");
                });

            modelBuilder.Entity("CroKnitters.Entities.Event", b =>
                {
                    b.Navigation("EventUsers");
                });

            modelBuilder.Entity("CroKnitters.Entities.Image", b =>
                {
                    b.Navigation("Patterns");

                    b.Navigation("Projects");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("CroKnitters.Entities.Language", b =>
                {
                    b.Navigation("Preferences");
                });

            modelBuilder.Entity("CroKnitters.Entities.Pattern", b =>
                {
                    b.Navigation("PatternComments");

                    b.Navigation("PatternTags");

                    b.Navigation("ProjectPatterns");

                    b.Navigation("UserPatterns");
                });

            modelBuilder.Entity("CroKnitters.Entities.Project", b =>
                {
                    b.Navigation("ProjectComments");

                    b.Navigation("ProjectPatterns");

                    b.Navigation("ProjectTags");

                    b.Navigation("UserProjects");
                });

            modelBuilder.Entity("CroKnitters.Entities.Province", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("CroKnitters.Entities.Tag", b =>
                {
                    b.Navigation("PatternTags");

                    b.Navigation("ProjectTags");
                });

            modelBuilder.Entity("CroKnitters.Entities.Theme", b =>
                {
                    b.Navigation("Preferences");
                });

            modelBuilder.Entity("CroKnitters.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("EventUsers");

                    b.Navigation("Events");

                    b.Navigation("Patterns");

                    b.Navigation("Preferences");

                    b.Navigation("Projects");

                    b.Navigation("UserPatterns");

                    b.Navigation("UserProjects");
                });
#pragma warning restore 612, 618
        }
    }
}