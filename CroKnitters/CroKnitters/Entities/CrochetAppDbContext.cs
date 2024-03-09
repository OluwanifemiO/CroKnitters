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

    public DbSet<Admin> Admin { get; set; }

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

    //new
    public DbSet<ProjectImage> ProjectImages { get; set; }

    public DbSet<PatternImage> PatternImage { get; set; }

    public DbSet<Group> Groups { get; set; }

    public DbSet<Message> Messages { get; set; }

    public DbSet<GroupChat> GroupChat { get; set; }

    public DbSet<PrivateChat> PrivateChat { get; set; }

    public DbSet<FriendsList> FriendsList { get; set; }

    public DbSet<GroupUser> GroupUsers { get; set; }


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

        modelBuilder.Entity<FriendsList>(entity =>
        {
            entity.HasKey(e => e.ListId).HasName("PK__FriendsL__E3832805B148DDC9");

            entity.ToTable("FriendsList");

            entity.HasOne(d => d.Friend).WithMany(p => p.FriendsListFriends)
                .HasForeignKey(d => d.FriendId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FriendsLi__Frien__3B40CD36");

            entity.HasOne(d => d.User).WithMany(p => p.FriendsListUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FriendsLi__UserI__3A4CA8FD");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK__Groups__149AF36A0C281B44");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.GroupName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GroupChat>(entity =>
        {
            entity.HasKey(e => e.GChatId).HasName("PK__GroupCha__75C801E807CEC318");

            entity.ToTable("GroupChat");

            entity.Property(e => e.GChatId).HasColumnName("GChatId");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupChats)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK__GroupChat__Group__31B762FC");

            entity.HasOne(d => d.Message).WithMany(p => p.GroupChats)
                .HasForeignKey(d => d.MessageId)
                .HasConstraintName("FK__GroupChat__Messa__30C33EC3");
        });

        modelBuilder.Entity<GroupUser>(entity =>
        {
            entity.HasKey(e => e.GroupUserId).HasName("PK__GroupUse__37F70716E0C22569");

            entity.Property(e => e.Role)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValueSql("('Member')");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupUsers)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GroupUser__Group__40058253");

            entity.HasOne(d => d.User).WithMany(p => p.GroupUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GroupUser__UserI__3E1D39E1");
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

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Messages__C87C0C9C167A84C6");

            entity.Property(e => e.Content)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Sender).WithMany(p => p.Messages)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Messages__Sender__2CF2ADDF");
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

        modelBuilder.Entity<PatternImage>(entity =>
        {
            entity.HasKey(e => e.PatImId).HasName("PK__PatternI__469D527DA79D41C7");

            entity.HasOne(d => d.Image).WithMany(p => p.PatternImages)
                .HasForeignKey(d => d.ImageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PatternIm__Image__236943A5");

            entity.HasOne(d => d.Pattern).WithMany(p => p.PatternImages)
                .HasForeignKey(d => d.PatternId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PatternIm__Patte__22751F6C");
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

        modelBuilder.Entity<PrivateChat>(entity =>
        {
            entity.HasKey(e => e.PChatId).HasName("PK__PrivateC__752CDBDC8FE2125C");

            entity.ToTable("PrivateChat");

            entity.Property(e => e.PChatId).HasColumnName("PChatId");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Message).WithMany(p => p.PrivateChats)
                .HasForeignKey(d => d.MessageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PrivateCh__Messa__367C1819");

            entity.HasOne(d => d.Reciever).WithMany(p => p.PrivateChatRecievers)
                .HasForeignKey(d => d.RecieverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PrivateCh__Recie__3587F3E0");

            entity.HasOne(d => d.Sender).WithMany(p => p.PrivateChatSenders)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PrivateCh__Sende__3493CFA7");
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

        modelBuilder.Entity<ProjectImage>(entity =>
        {
            entity.HasKey(e => e.ProImId).HasName("PK__ProjectI__05A6BB15FBD6324F");

            entity.HasOne(d => d.Image).WithMany(p => p.ProjectImages)
                .HasForeignKey(d => d.ImageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProjectIm__Image__1F98B2C1");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectImages)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProjectIm__Proje__1EA48E88");
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

        //seed into city
        modelBuilder.Entity<City>().HasData(
               new City() { CityId = 1, CityName = "Calgary", ProvinceId = 1 },
               new City() { CityId = 2, CityName = "Edmonton", ProvinceId = 1 },
               new City() { CityId = 3, CityName = "Red Deer", ProvinceId = 1 },
               new City() { CityId = 4, CityName = "Vancouver", ProvinceId = 2 },
               new City() { CityId = 5, CityName = "Surrey", ProvinceId = 2 },
               new City() { CityId = 6, CityName = "Victoria", ProvinceId = 2 },
               new City() { CityId = 7, CityName = "Burnaby", ProvinceId = 2 },
               new City() { CityId = 8, CityName = "Richmond", ProvinceId = 2 },
               new City() { CityId = 9, CityName = "Kelowna", ProvinceId = 2 },
               new City() { CityId = 10, CityName = "Abbotsford", ProvinceId = 2 },
               new City() { CityId = 11, CityName = "Coquitlam", ProvinceId = 2 },
               new City() { CityId = 12, CityName = "Saanich", ProvinceId = 2 },
               new City() { CityId = 13, CityName = "White Rock", ProvinceId = 2 },
               new City() { CityId = 14, CityName = "Delta", ProvinceId = 2 },
               new City() { CityId = 15, CityName = "Nanaimo", ProvinceId = 2 },
               new City() { CityId = 16, CityName = "Winnipeg", ProvinceId = 3 },
               new City() { CityId = 17, CityName = "Moncton", ProvinceId = 4 },
               new City() { CityId = 18, CityName = "St. John's", ProvinceId = 5 },
               new City() { CityId = 19, CityName = "Halifax", ProvinceId = 6 },
               new City() { CityId = 20, CityName = "Toronto", ProvinceId = 7 },
               new City() { CityId = 21, CityName = "Ottawa", ProvinceId = 7 },
               new City() { CityId = 22, CityName = "Hamilton", ProvinceId = 7 },
               new City() { CityId = 23, CityName = "Mississauga", ProvinceId = 7 },
               new City() { CityId = 24, CityName = "Brampton", ProvinceId = 7 },
               new City() { CityId = 25, CityName = "Kitchener", ProvinceId = 7 },
               new City() { CityId = 26, CityName = "London", ProvinceId = 7 },
               new City() { CityId = 27, CityName = "Markham", ProvinceId = 7 },
               new City() { CityId = 28, CityName = "Oshawa", ProvinceId = 7 },
               new City() { CityId = 29, CityName = "Vaughan", ProvinceId = 7 },
               new City() { CityId = 30, CityName = "Windsor", ProvinceId = 7 },
               new City() { CityId = 31, CityName = "St. Catharines", ProvinceId = 7 },
               new City() { CityId = 32, CityName = "Oakville", ProvinceId = 7 },
               new City() { CityId = 33, CityName = "Richmond Hill", ProvinceId = 7 },
               new City() { CityId = 34, CityName = "Burlington", ProvinceId = 7 },
               new City() { CityId = 35, CityName = "Sudbury", ProvinceId = 7 },
               new City() { CityId = 36, CityName = "Barrie", ProvinceId = 7 },
               new City() { CityId = 37, CityName = "Guelph", ProvinceId = 7 },
               new City() { CityId = 38, CityName = "Whitby", ProvinceId = 7 },
               new City() { CityId = 39, CityName = "Cambridge", ProvinceId = 7 },
               new City() { CityId = 40, CityName = "Milton", ProvinceId = 7 },
               new City() { CityId = 41, CityName = "Ajax", ProvinceId = 7 },
               new City() { CityId = 42, CityName = "Waterloo", ProvinceId = 7 },
               new City() { CityId = 43, CityName = "Thunder Bay", ProvinceId = 7 },
               new City() { CityId = 44, CityName = "Brantford", ProvinceId = 7 },
               new City() { CityId = 45, CityName = "Chatham", ProvinceId = 7 },
               new City() { CityId = 46, CityName = "Clarington", ProvinceId = 7 },
               new City() { CityId = 47, CityName = "Montréal", ProvinceId = 9 },
               new City() { CityId = 48, CityName = "Quebec City", ProvinceId = 9 },
               new City() { CityId = 49, CityName = "Laval", ProvinceId = 9 },
               new City() { CityId = 50, CityName = "Gatineau", ProvinceId = 9 },
               new City() { CityId = 51, CityName = "Longueuil", ProvinceId = 9 },
               new City() { CityId = 52, CityName = "Sherbrooke", ProvinceId = 9 },
               new City() { CityId = 53, CityName = "Lévis", ProvinceId = 9 },
               new City() { CityId = 54, CityName = "Saguenay", ProvinceId = 9 },
               new City() { CityId = 55, CityName = "Trois-Rivières", ProvinceId = 9 },
               new City() { CityId = 56, CityName = "Terrebonne", ProvinceId = 9 },
               new City() { CityId = 57, CityName = "Saint-Jérôme", ProvinceId = 9 },
               new City() { CityId = 58, CityName = "Saskatoon", ProvinceId = 10 },
               new City() { CityId = 59, CityName = "Regina", ProvinceId = 10 }
           );

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
               new Image() { ImageId = 1, ImageSrc = "image_one.jpg" },
               new Image() { ImageId = 2, ImageSrc = "image_two.jpg" },
               new Image() { ImageId = 3, ImageSrc = "image_three.png" },
               new Image() { ImageId = 4, ImageSrc = "image_four.jpeg" },
               new Image() { ImageId = 5, ImageSrc = "mesh-stitch.png" },
               new Image() { ImageId = 6, ImageSrc = "treble-stitch.png" },
               new Image() { ImageId = 7, ImageSrc = "chevron-stitch.png" },
               new Image() { ImageId = 8, ImageSrc = "granny-square-stitch.png" },
               new Image() { ImageId = 9, ImageSrc = "basketweave-stitch.png" },
               new Image() { ImageId = 10, ImageSrc = "popcorn_stitch.jpeg" },
               new Image() { ImageId = 11, ImageSrc = "baby-socks.jpeg" },
               new Image() { ImageId = 12, ImageSrc = "winter-scarf.jpeg" },
               new Image() { ImageId = 13, ImageSrc = "granny-square-blanket.jpeg" },
               new Image() { ImageId = 14, ImageSrc = "amigurumi-bunny.jpeg" },
               new Image() { ImageId = 15, ImageSrc = "summer-top.jpeg" },
               new Image() { ImageId = 16, ImageSrc = "crochet-coaster.jpg" },
               new Image() { ImageId = 17, ImageSrc = "cable-stitch.jpg" },
               new Image() { ImageId = 18, ImageSrc = "shell-stitch.png" }
           );

        //seed into patterns
        modelBuilder.Entity<Pattern>().HasData(
               new Pattern() { PatternId = 1, PatternName = "Mesh Pattern", Description = "This pattern usually consists of single chains connected to one another in the middle to resemble a mesh design.", CreationDate = new DateTime(2024, 3, 3), Likes = 50, StitchType = "Mesh Stitch", StitchCount = 30, OwnerId = 1 },
               new Pattern() { PatternId = 2, PatternName = "Treble Crochet Pattern", Description = "This pattern consists of treble crochet stitches.", CreationDate = new DateTime(2024, 3, 1), Likes = 20, StitchType = "Treble Crochet Stitch", StitchCount = 20, OwnerId = 2 },
               new Pattern() { PatternId = 3, PatternName = "Chevron Pattern", Description = "This pattern usually consists of double crochet stitches connected to one to resemble a wave design.", CreationDate = new DateTime(2024, 2, 19), Likes = 80, StitchType = "Double Crochet Stitch", StitchCount = 70, OwnerId = 2 },
               new Pattern() { PatternId = 4, PatternName = "Granny Square Pattern", Description = "This pattern usually consists of Double crochet stitches that are connected in a unique way.", CreationDate = new DateTime(2024, 2, 12), Likes = 100, StitchType = "Double Crochet Stitch", StitchCount = 100, OwnerId = 3 },
               new Pattern() { PatternId = 5, PatternName = "Basketweave Pattern", Description = "This pattern creates a woven texture resembling a basket.", CreationDate = new DateTime(2024, 2, 18), Likes = 45, StitchType = "Basketweave Stitch", StitchCount = 25, OwnerId = 1 },
               new Pattern() { PatternId = 6, PatternName = "Popcorn Stitch Pattern", Description = "This pattern features the popcorn stitch for a textured and raised effect.", CreationDate = new DateTime(2024, 2, 7), Likes = 30, StitchType = "Popcorn Stitch", StitchCount = 15, OwnerId = 3 },
               new Pattern() { PatternId = 7, PatternName = "Cable Stitch Pattern", Description = "This pattern creates a twisted and braided appearance using cable stitches.", CreationDate = new DateTime(2024, 2, 20), Likes = 60, StitchType = "Cable Stitch", StitchCount = 40, OwnerId = 1 },
               new Pattern() { PatternId = 8, PatternName = "Shell Stitch Pattern", Description = "This pattern forms a scallop-like shell using various crochet stitches.", CreationDate = new DateTime(2024, 3, 1), Likes = 75, StitchType = "Shell Stitch", StitchCount = 50, OwnerId = 2 }

               );

        //seed into projects
        modelBuilder.Entity<Project>().HasData(
              new Project() { ProjectId = 1, ProjectName = "Baby Socks", Description = "This is a work in progress socks for my six month old baby.", CreationDate = new DateTime(2024, 3, 3), Likes = 50, Status = "In-Progress", OwnerId = 1 },
              new Project() { ProjectId = 2, ProjectName = "Winter Scarf", Description = "A warm scarf for the winter season, using a bobble stitch pattern.", CreationDate = DateTime.Now.AddDays(-10), Likes = 75, Status = "Completed", OwnerId = 2 },
              new Project() { ProjectId = 3, ProjectName = "Granny Square Blanket", Description = "A colorful blanket made from granny squares. Each square features a different color, aiming for a vibrant look.", CreationDate = DateTime.Now.AddDays(-20), Likes = 90, Status = "In-Progress", OwnerId = 3 },
              new Project() { ProjectId = 4, ProjectName = "Amigurumi Bunny", Description = "A cute bunny amigurumi project for the upcoming Easter holidays.", CreationDate = DateTime.Now.AddDays(-5), Likes = 120, Status = "Completed", OwnerId = 1 },
              new Project() { ProjectId = 5, ProjectName = "Summer Top", Description = "A light and breezy top perfect for summer, using cotton yarn.", CreationDate = DateTime.Now.AddDays(-30), Likes = 65, Status = "In-Progress", OwnerId = 2 },
              new Project() { ProjectId = 6, ProjectName = "Crochet Coasters", Description = "Set of coasters for the dining table, featuring a floral motif.", CreationDate = DateTime.Now.AddDays(-15), Likes = 40, Status = "Completed", OwnerId = 3 }
              );

        //seed into theme
        modelBuilder.Entity<Theme>().HasData(
            new Theme() { ThemeId = 1, ThemeTitle = "Light" },
            new Theme() { ThemeId = 2, ThemeTitle = "Dark" }
            );

        //seed into language
        modelBuilder.Entity<Language>().HasData(
            new Language() { LanguageId = 1, LanguageName = "English" },
            new Language() { LanguageId = 2, LanguageName = "French" }
            );

        //seed into Preference 
        modelBuilder.Entity<Preference>().HasData(
            new Preference() { PreferenceId = 1, LanguageId = 1, ThemeId = 1, UserId = 1 },
            new Preference() { PreferenceId = 2, LanguageId = 2, ThemeId = 2, UserId = 2 }
            );

        //seed into comment
        modelBuilder.Entity<Comment>().HasData(
            new Comment() { CommentId = 1, Content = "Very pretty!", CreationDate = DateTime.Now.AddDays(-10), Likes = 10, ApprovalStatus = true, OwnerId = 1, AdminId = 1},
            new Comment() { CommentId = 2, Content = "Super cute!", CreationDate = DateTime.Now.AddDays(-10), Likes = 20, ApprovalStatus = true, OwnerId = 2, AdminId = 2 },
            new Comment() { CommentId = 3, Content = "Love the colors!", CreationDate = DateTime.Now.AddDays(-10), Likes = 15, ApprovalStatus = true, OwnerId = 3, AdminId = 1 },
            new Comment() { CommentId = 4, Content = "Shitty job!", CreationDate = DateTime.Now.AddDays(-10), Likes = 12, ApprovalStatus = false, OwnerId = 4, AdminId = 1 }
            );

        //seed into tag
        modelBuilder.Entity<Tag>().HasData(
            new Tag() { TagId = 1, TagName = "Amazing" },
            new Tag() { TagId = 2, TagName = "Cute" }, 
            new Tag() { TagId = 3, TagName = "Elegant" },
            new Tag() { TagId = 4, TagName = "Classic" },
            new Tag() { TagId = 5, TagName = "Modern" },
            new Tag() { TagId = 6, TagName = "Colorful" },
            new Tag() { TagId = 7, TagName = "Simple" },
            new Tag() { TagId = 8, TagName = "Unique" }
            );

        //seed into Events
        modelBuilder.Entity<Event>().HasData(
            new Event() { EventId = 1, EventTitle = "Yarn sale at Kitchener, Ontario.", Description = "Don't miss out on amazing deals at our annual yarn sale! From colorful skeins to luxurious blends, we've got something for every project. See you there!", Date = DateTime.Now.AddDays(80), OwnerId = 1 },
            new Event() { EventId = 2, EventTitle = "Project showcase at Toronto, Ontario", Description = "Join us for an inspiring evening as local crafters showcase their latest creations. From intricate afghans to cozy scarves, you'll find plenty of ideas to spark your creativity.", Date = DateTime.Now.AddDays(70), OwnerId = 2 },
            new Event() { EventId = 3, EventTitle = "Crochet workshop in Vancouver, BC", Description = "Learn the art of crochet from experienced instructors in a fun and supportive environment. Whether you're a complete beginner or looking to refine your skills, this workshop is perfect for you!", Date = DateTime.Now.AddDays(60), OwnerId = 3 },
            new Event() { EventId = 4, EventTitle = "Knitting and Crochet Expo in Montreal, QC", Description = "Discover the latest trends and techniques in knitting and crochet at our annual expo. From interactive workshops to vendor booths featuring the hottest yarns, you'll find everything you need to take your crafting to the next level.", Date = new DateTime(2024, 3, 1, 12, 30, 0), OwnerId = 4 },
            new Event() { EventId = 5, EventTitle = "Online Crochet Class - Beginners Welcome!", Description = "Join us for a virtual crochet class designed for beginners. Learn essential stitches and techniques from the comfort of your own home, with personalized instruction and plenty of support.", Date = DateTime.Now.AddDays(50), OwnerId = 2 },
            new Event() { EventId = 6, EventTitle = "Local Yarn Swap Meet in Calgary, AB", Description = "Trade your stash and discover new treasures at our yarn swap meet. Bring your unwanted yarn and notions to exchange with fellow crafters, and leave with fresh inspiration for your next project.", Date = DateTime.Now.AddDays(80), OwnerId = 4 }
            );

        //seed into FriendList
        modelBuilder.Entity<FriendsList>().HasData(
            new FriendsList() { ListId = 1, FriendId = 1, UserId = 2 },
            new FriendsList() { ListId = 2, FriendId = 1, UserId = 3 },
            new FriendsList() { ListId = 3, FriendId = 1, UserId = 4 },
            new FriendsList() { ListId = 4, FriendId = 2, UserId = 3 },
            new FriendsList() { ListId = 5, FriendId = 2, UserId = 4 }
            );

        //seed into Group
        modelBuilder.Entity<Group>().HasData(
            new Group() { GroupId = 1, GroupName = "Lazy Crocheters community", CreationDate = DateTime.Now.AddDays(-10), Description = "Some lazy people coming together to motivate one another." },
            new Group() { GroupId = 2, GroupName = "Weekend Crochet Warriors", CreationDate = DateTime.Now.AddDays(-10), Description = "Weekend warriors unite for crochet projects big and small. All skill levels welcome." },
            new Group() { GroupId = 3, GroupName = "Eco-Friendly Fiber Artists", CreationDate = DateTime.Now.AddDays(-10), Description = "A community focused on using eco-friendly and sustainable materials in our crochet and knitting projects." }
            );


        //seed into eventusers
        modelBuilder.Entity<EventUser>().HasData(
            new EventUser() { EventUserId = 1, EventId = 1, UserId = 1 },
            new EventUser() { EventUserId = 2, EventId = 2, UserId = 2 },
            new EventUser() { EventUserId = 3, EventId = 3, UserId = 3 },
            new EventUser() { EventUserId = 4, EventId = 4, UserId = 4 },
            new EventUser() { EventUserId = 5, EventId = 5, UserId = 3 },
            new EventUser() { EventUserId = 6, EventId = 6, UserId = 2 }
            );

        //seed into groupchat
        modelBuilder.Entity<GroupChat>().HasData(
            new GroupChat() { GChatId = 1, MessageId = 1, GroupId = 1 },
            new GroupChat() { GChatId = 2, MessageId = 2, GroupId = 1 },
            new GroupChat() { GChatId = 3, MessageId = 3, GroupId = 2 },
            new GroupChat() { GChatId = 4, MessageId = 4, GroupId = 2 },
            new GroupChat() { GChatId = 5, MessageId = 5, GroupId = 3 },
            new GroupChat() { GChatId = 6, MessageId = 6, GroupId = 3 }
            );

        //seed into message
        modelBuilder.Entity<Message>().HasData(
            new Message() { MessageId = 1, Content = "Hey everyone! Excited to join this group.", CreationDate = DateTime.Now.AddDays(-10), SenderId = 1 },
            new Message() { MessageId = 2, Content = "Welcome! Looking forward to seeing your projects.", CreationDate = DateTime.Now.AddDays(-10), SenderId = 2 },
            new Message() { MessageId = 3, Content = "Does anyone have tips for a beginner?", CreationDate = DateTime.Now.AddDays(-10), SenderId = 3 },
            new Message() { MessageId = 4, Content = "Sure! I'd recommend starting with simple patterns and bulky yarn. It's easier to see your stitches.", CreationDate = DateTime.Now.AddDays(-10), SenderId = 4 },
            new Message() { MessageId = 5, Content = "I'm trying to find eco-friendly yarn. Any brand recommendations?", CreationDate = DateTime.Now.AddDays(-10), SenderId = 2 },
            new Message() { MessageId = 6, Content = "I love using bamboo and recycled cotton yarns. They're great for the environment and work well for many projects.", CreationDate = DateTime.Now.AddDays(-10), SenderId = 4 },
            new Message() { MessageId = 7, Content = "Hey! How's it going?", CreationDate = DateTime.Now.AddDays(-10), SenderId = 1 },
            new Message() { MessageId = 8, Content = "Hi there! Not bad, just working on a new project. How about you?", CreationDate = DateTime.Now.AddDays(-10), SenderId = 2 },
            new Message() { MessageId = 9, Content = "Hey! What kind of project are you working on?", CreationDate = DateTime.Now.AddDays(-10), SenderId = 1 },
            new Message() { MessageId = 10, Content = "I'm trying out a new crochet pattern for a scarf. It's a bit challenging, but fun!", CreationDate = DateTime.Now.AddDays(-10), SenderId = 3 },
            new Message() { MessageId = 11, Content = "Hello! Do you have a favorite type of yarn you like to use?", CreationDate = DateTime.Now.AddDays(-10), SenderId = 1 },
            new Message() { MessageId = 12, Content = "I love using soft merino wool for scarves. It gives a cozy feel. How about you?", CreationDate = DateTime.Now.AddDays(-10), SenderId = 4 }
            );

        //seed into groupusers
        modelBuilder.Entity<GroupUser>().HasData(
            new GroupUser() { GroupUserId = 1, Role = "Admin", GroupId = 1, UserId = 2 },
            new GroupUser() { GroupUserId = 2, Role = "Member", GroupId = 1, UserId = 1 },
            new GroupUser() { GroupUserId = 3, Role = "Admin", GroupId = 2, UserId = 3 },
            new GroupUser() { GroupUserId = 4, Role = "Member", GroupId = 2, UserId = 4 },
            new GroupUser() { GroupUserId = 5, Role = "Admin", GroupId = 3, UserId = 2 },
            new GroupUser() { GroupUserId = 6, Role = "Member", GroupId = 3, UserId = 4 }
            );

        //seed into patterncomment
        modelBuilder.Entity<PatternComment>().HasData(
            new PatternComment() { PatComId = 1, PatternId = 1, CommentId = 2 },
            new PatternComment() { PatComId = 2, PatternId = 1, CommentId = 1 },
            new PatternComment() { PatComId = 3, PatternId = 2, CommentId = 3 },
            new PatternComment() { PatComId = 4, PatternId = 2, CommentId = 4 },
            new PatternComment() { PatComId = 5, PatternId = 3, CommentId = 2 },
            new PatternComment() { PatComId = 6, PatternId = 3, CommentId = 4 }
            );

        //seed into projectcomment
        modelBuilder.Entity<ProjectComment>().HasData(
            new ProjectComment() { ProComId = 1, ProjectId = 1, CommentId = 2 },
            new ProjectComment() { ProComId = 2, ProjectId = 1, CommentId = 1 },
            new ProjectComment() { ProComId = 3, ProjectId = 2, CommentId = 3 },
            new ProjectComment() { ProComId = 4, ProjectId = 2, CommentId = 4 },
            new ProjectComment() { ProComId = 5, ProjectId = 3, CommentId = 2 },
            new ProjectComment() { ProComId = 6, ProjectId = 3, CommentId = 4 }
            );

        //seed into patternimage
        modelBuilder.Entity<PatternImage>().HasData(
            new PatternImage() { PatImId = 1, PatternId = 1, ImageId = 5 },
            new PatternImage() { PatImId = 2, PatternId = 2, ImageId = 6 },
            new PatternImage() { PatImId = 3, PatternId = 3, ImageId = 7 },
            new PatternImage() { PatImId = 4, PatternId = 4, ImageId = 8 },
            new PatternImage() { PatImId = 5, PatternId = 5, ImageId = 9 },
            new PatternImage() { PatImId = 6, PatternId = 6, ImageId = 10 },
            new PatternImage() { PatImId = 7, PatternId = 7, ImageId = 17 },
            new PatternImage() { PatImId = 8, PatternId = 8, ImageId = 18}
            );

        //seed into projectimage
        modelBuilder.Entity<ProjectImage>().HasData(
            new ProjectImage() { ProImId = 1, ProjectId = 1, ImageId = 11 },
            new ProjectImage() { ProImId = 2, ProjectId = 2, ImageId = 12 },
            new ProjectImage() { ProImId = 3, ProjectId = 3, ImageId = 13 },
            new ProjectImage() { ProImId = 4, ProjectId = 4, ImageId = 14 },
            new ProjectImage() { ProImId = 5, ProjectId = 5, ImageId = 15 },
            new ProjectImage() { ProImId = 6, ProjectId = 6, ImageId = 16 }
            );

        //seed into patterntag
        modelBuilder.Entity<PatternTag>().HasData(
            new PatternTag() { PatTagId = 1, PatternId = 1, TagId = 1 },
            new PatternTag() { PatTagId = 2, PatternId = 2, TagId = 2 },
            new PatternTag() { PatTagId = 3, PatternId = 3, TagId = 3 },
            new PatternTag() { PatTagId = 4, PatternId = 4, TagId = 4 },
            new PatternTag() { PatTagId = 5, PatternId = 5, TagId = 5 },
            new PatternTag() { PatTagId = 6, PatternId = 6, TagId = 6 },
            new PatternTag() { PatTagId = 7, PatternId = 7, TagId = 7 },
            new PatternTag() { PatTagId = 8, PatternId = 8, TagId = 8 }
            );

        //seed into projecttag
        modelBuilder.Entity<ProjectTag>().HasData(
            new ProjectTag() { ProTagId = 1, ProjectId = 1, TagId = 8 },
            new ProjectTag() { ProTagId = 2, ProjectId = 2, TagId = 7 },
            new ProjectTag() { ProTagId = 3, ProjectId = 3, TagId = 6 },
            new ProjectTag() { ProTagId = 4, ProjectId = 4, TagId = 5 },
            new ProjectTag() { ProTagId = 5, ProjectId = 5, TagId = 4 },
            new ProjectTag() { ProTagId = 6, ProjectId = 6, TagId = 3 }
            );

        //seed into userpattern
        modelBuilder.Entity<UserPattern>().HasData(
            new UserPattern() { UpatId = 1, PatternId = 1, UserId = 1 },
            new UserPattern() { UpatId = 2, PatternId = 2, UserId = 1 },
            new UserPattern() { UpatId = 3, PatternId = 3, UserId = 2 },
            new UserPattern() { UpatId = 4, PatternId = 4, UserId = 2 },
            new UserPattern() { UpatId = 5, PatternId = 5, UserId = 3 },
            new UserPattern() { UpatId = 6, PatternId = 6, UserId = 3 },
            new UserPattern() { UpatId = 7, PatternId = 7, UserId = 4 },
            new UserPattern() { UpatId = 8, PatternId = 8, UserId = 4 }
            );

        //seed into userproject
        modelBuilder.Entity<UserProject>().HasData(
            new UserProject() { UproId = 1, ProjectId = 1, UserId = 1 },
            new UserProject() { UproId = 2, ProjectId = 2, UserId = 1 },
            new UserProject() { UproId = 3, ProjectId = 3, UserId = 1 },
            new UserProject() { UproId = 4, ProjectId = 4, UserId = 3 },
            new UserProject() { UproId = 5, ProjectId = 5, UserId = 3 },
            new UserProject() { UproId = 6, ProjectId = 6, UserId = 3 }
            );

        //seed into privatechat
        modelBuilder.Entity<PrivateChat>().HasData(
            new PrivateChat() {PChatId = 1, CreationDate = DateTime.Now.AddDays(-10), MessageId = 7, SenderId = 1, RecieverId = 2 },
            new PrivateChat() {PChatId = 2, CreationDate = DateTime.Now.AddDays(-10), MessageId = 8, SenderId = 2, RecieverId = 1 },
            new PrivateChat() {PChatId = 3, CreationDate = DateTime.Now.AddDays(-10), MessageId = 9, SenderId = 1, RecieverId = 3 },
            new PrivateChat() {PChatId = 4, CreationDate = DateTime.Now.AddDays(-10), MessageId = 10, SenderId = 3, RecieverId = 1 },
            new PrivateChat() {PChatId = 5, CreationDate = DateTime.Now.AddDays(-10), MessageId = 11, SenderId = 1, RecieverId = 4 },
            new PrivateChat() {PChatId = 6, CreationDate = DateTime.Now.AddDays(-10), MessageId = 12, SenderId = 4, RecieverId = 1 }
            );
    }

}
