using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CroKnitters.Entities;

public partial class CrochetAppDbContext : DbContext
{
    public CrochetAppDbContext()
    {
    }

    public CrochetAppDbContext(DbContextOptions<CrochetAppDbContext> options)
        : base(options)
    {
    }

    public DbSet<City> Cities { get; set; }

    public DbSet<Comment> Comments { get; set; }

    public DbSet<Event> Events { get; set; }

    public DbSet<EventUser> EventUsers { get; set; }

    public DbSet<Image> Images { get; set; }

    public DbSet<Language> Languages { get; set; }

    public DbSet<Pattern> Patterns { get; set; }

    public DbSet<PatternComment> PatternComments { get; set; }

    public DbSet<PatternTag> PatternTags { get; set; }

    public DbSet<Preference> Preferences { get; set; }

    public DbSet<Project> Projects { get; set; }

    public DbSet<ProjectComment> ProjectComments { get; set; }

    public DbSet<ProjectPattern> ProjectPatterns { get; set; }

    public DbSet<ProjectTag> ProjectTags { get; set; }

    public DbSet<Province> Provinces { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public DbSet<Theme> Themes { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserPattern> UserPatterns { get; set; }

    public DbSet<UserProject> UserProjects { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__Cities__F2D21B763291A5A0");

            entity.Property(e => e.CityName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Province).WithMany(p => p.Cities)
                .HasForeignKey(d => d.ProvinceId)
                .HasConstraintName("FK__Cities__Province__2E1BDC42");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comments__C3B4DFCA7D1B4540");

            entity.Property(e => e.Content)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");

            entity.HasOne(d => d.Owner).WithMany(p => p.Comments)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__OwnerI__4AB81AF0");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Events__7944C810EEF9274C");

            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.EventTitle)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Owner).WithMany(p => p.Events)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Events__OwnerId__34C8D9D1");
        });

        modelBuilder.Entity<EventUser>(entity =>
        {
            entity.HasKey(e => e.EventUserId).HasName("PK__EventUse__75F92483FA2626FC");

            entity.HasOne(d => d.Event).WithMany(p => p.EventUsers)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventUser__Event__68487DD7");

            entity.HasOne(d => d.User).WithMany(p => p.EventUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventUser__UserI__693CA210");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__Images__7516F70CC8F1B07F");

            entity.Property(e => e.ImageSrc)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("PK__Language__B93855ABA45758AD");

            entity.Property(e => e.LanguageName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pattern>(entity =>
        {
            entity.HasKey(e => e.PatternId).HasName("PK__Patterns__0A631B521FCBD794");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PatternName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StitchType)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Image).WithMany(p => p.Patterns)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("FK__Patterns__ImageI__3F466844");

            entity.HasOne(d => d.Owner).WithMany(p => p.Patterns)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Patterns__OwnerI__3E52440B");
        });

        modelBuilder.Entity<PatternComment>(entity =>
        {
            entity.HasKey(e => e.PatComId).HasName("PK__PatternC__272DE03846EEF9E6");

            entity.HasOne(d => d.Comment).WithMany(p => p.PatternComments)
                .HasForeignKey(d => d.CommentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PatternCo__Comme__656C112C");

            entity.HasOne(d => d.Pattern).WithMany(p => p.PatternComments)
                .HasForeignKey(d => d.PatternId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PatternCo__Patte__6477ECF3");
        });

        modelBuilder.Entity<PatternTag>(entity =>
        {
            entity.HasKey(e => e.PatTagId).HasName("PK__PatternT__68421DA4E054EE9B");

            entity.HasOne(d => d.Pattern).WithMany(p => p.PatternTags)
                .HasForeignKey(d => d.PatternId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PatternTa__Patte__5CD6CB2B");

            entity.HasOne(d => d.Tag).WithMany(p => p.PatternTags)
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PatternTa__TagId__5DCAEF64");
        });

        modelBuilder.Entity<Preference>(entity =>
        {
            entity.HasKey(e => e.PreferenceId).HasName("PK__Preferen__E228496F2600B5A8");

            entity.HasOne(d => d.Language).WithMany(p => p.Preferences)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Preferenc__Langu__38996AB5");

            entity.HasOne(d => d.Theme).WithMany(p => p.Preferences)
                .HasForeignKey(d => d.ThemeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Preferenc__Theme__398D8EEE");

            entity.HasOne(d => d.User).WithMany(p => p.Preferences)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Preferenc__UserI__37A5467C");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Projects__761ABEF001154132");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ProjectName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('In-Progress')");

            entity.HasOne(d => d.Image).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("FK__Projects__ImageI__45F365D3");

            entity.HasOne(d => d.Owner).WithMany(p => p.Projects)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Projects__OwnerI__44FF419A");
        });

        modelBuilder.Entity<ProjectComment>(entity =>
        {
            entity.HasKey(e => e.ProComId).HasName("PK__ProjectC__FAF8CB4AAB204E27");

            entity.HasOne(d => d.Comment).WithMany(p => p.ProjectComments)
                .HasForeignKey(d => d.CommentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProjectCo__Comme__619B8048");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectComments)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProjectCo__Proje__60A75C0F");
        });

        modelBuilder.Entity<ProjectPattern>(entity =>
        {
            entity.HasKey(e => e.ProPatId).HasName("PK__ProjectP__19B1EB93417F37D9");

            entity.HasOne(d => d.Pattern).WithMany(p => p.ProjectPatterns)
                .HasForeignKey(d => d.PatternId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProjectPa__Patte__5629CD9C");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectPatterns)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProjectPa__Proje__5535A963");
        });

        modelBuilder.Entity<ProjectTag>(entity =>
        {
            entity.HasKey(e => e.ProTagId).HasName("PK__ProjectT__EA3BF1B886EBE45B");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectTags)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProjectTa__Proje__59063A47");

            entity.HasOne(d => d.Tag).WithMany(p => p.ProjectTags)
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProjectTa__TagId__59FA5E80");
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.HasKey(e => e.ProvinceId).HasName("PK__Province__FD0A6F83F858F43F");

            entity.Property(e => e.ProvinceName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("PK__Tags__657CF9ACB4394FA8");

            entity.Property(e => e.TagName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Theme>(entity =>
        {
            entity.HasKey(e => e.ThemeId).HasName("PK__Themes__FBB3E4D98AE98BB3");

            entity.Property(e => e.ThemeTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CEBD8424E");

            entity.Property(e => e.Bio)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.City).WithMany(p => p.Users)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Users__CityId__30F848ED");

            entity.HasOne(d => d.Image).WithMany(p => p.Users)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("FK__Users__ImageId__31EC6D26");
        });

        modelBuilder.Entity<UserPattern>(entity =>
        {
            entity.HasKey(e => e.UpatId).HasName("PK__UserPatt__900CF3B8C62046ED");

            entity.HasOne(d => d.Pattern).WithMany(p => p.UserPatterns)
                .HasForeignKey(d => d.PatternId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserPatte__Patte__4E88ABD4");

            entity.HasOne(d => d.User).WithMany(p => p.UserPatterns)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserPatte__UserI__4D94879B");
        });

        modelBuilder.Entity<UserProject>(entity =>
        {
            entity.HasKey(e => e.UproId).HasName("PK__UserProj__1DAD7D9709F4A257");

            entity.HasOne(d => d.Project).WithMany(p => p.UserProjects)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserProje__Proje__52593CB8");

            entity.HasOne(d => d.User).WithMany(p => p.UserProjects)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserProje__UserI__5165187F");
        });

        //seed data into the database:
        //iteration 1 data
        //seed into admin
        modelBuilder.Entity<Admin>().HasData(
                new Admin() { AdminId = 1, Username = "Admin1", Email = "admin1@example.com", Password = "!a123456" },
                new Admin() { AdminId = 2, Username = "Admin2", Email = "admin2@example.com", Password = "!a123456" },
                new Admin() { AdminId = 3, Username = "Admin3", Email = "admin3@example.com", Password = "!a123456" },
                new Admin() { AdminId = 4, Username = "Admin4", Email = "admin4@example.com", Password = "!a123456" }
            );

        //seed into user
        modelBuilder.Entity<User>().HasData(
               new User() { UserId = 1, FirstName = "Samuel", LastName = "Dane", Username = "Samuel123", Email = "samD@example.com", Password = "!a123456", Bio = "Just a guy whose favourite thing is to crochet :).", ImageId = 1 },
               new User() { UserId = 2, FirstName = "Julia", LastName = "Fernandez", Username = "Julia123", Email = "juliaCrochet@example.com", Password = "!a123456", Bio = "Hello there! I like to crochet and knit...", ImageId = 2 },
               new User() { UserId = 3, FirstName = "Juan", LastName = "Pablo", Username = "Juan123", Email = "Pablo@example.com", Password = "!a123456", Bio = "My name is Juan Pablo and I'm exploring this craft as a new hobby.", ImageId = 4 },
               new User() { UserId = 4, FirstName = "Delilah", LastName = "Smith", Username = "Delilah123", Email = "Dsmith@example.com", Password = "!a123456", Bio = "Hello!", ImageId = 3 }
           );

        ////seed into city
        //modelBuilder.Entity<City>().HasData(
        //       new City() { CityId = 1, CityName = "Toronto", ProvinceId = 1 },
        //       new City() { CityId = 2, CityName = "Vancouver", ProvinceId = 2 },
        //       new City() { CityId = 3, CityName = "Montreal", ProvinceId = 3 },
        //       new City() { CityId = 4, CityName = "Calgary", ProvinceId = 4 }
        //   );

        //seed into province
        modelBuilder.Entity<Province>().HasData(
               new Province() { ProvinceId = 1, ProvinceName = "Alberta" },
               new Province() { ProvinceId = 2, ProvinceName = "British Columbia" },
               new Province() { ProvinceId = 3, ProvinceName = "Manitoba" },
               new Province() { ProvinceId = 4, ProvinceName = "New Brunswick" },
               new Province() { ProvinceId = 5, ProvinceName = "Newfoundland and Labrador" },
               new Province() { ProvinceId = 6, ProvinceName = "Nova Scotia" },
               new Province() { ProvinceId = 7, ProvinceName = "Ontario" },
               new Province() { ProvinceId = 8, ProvinceName = "Prince Edward Island" },
               new Province() { ProvinceId = 9, ProvinceName = "Quebec" },
               new Province() { ProvinceId = 10, ProvinceName = "Saskatchewan" }
           );

        //seed into image
        modelBuilder.Entity<Image>().HasData(
               new Image() { ImageId = 1, ImageSrc = "https://pbs.twimg.com/profile_images/1654080701292068865/AL2TAeY5_400x400.jpg" },
               new Image() { ImageId = 2, ImageSrc = "https://i.redd.it/jeuusd992wd41.jpg" },
               new Image() { ImageId = 3, ImageSrc = "https://images.squarespace-cdn.com/content/v1/5e10bdc20efb8f0d169f85f9/09943d85-b8c7-4d64-af31-1a27d1b76698/arrow.png" },
               new Image() { ImageId = 4, ImageSrc = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQV1_mGYXjq3eWha-wQIRkn6ulW9X6Ws-ztw&usqp=CAU" }
           );
    }

}
