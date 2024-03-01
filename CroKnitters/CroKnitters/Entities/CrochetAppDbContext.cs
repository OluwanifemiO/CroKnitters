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
               new Image() { ImageId = 1, ImageSrc = "https://pbs.twimg.com/profile_images/1654080701292068865/AL2TAeY5_400x400.jpg" },
               new Image() { ImageId = 2, ImageSrc = "https://i.redd.it/jeuusd992wd41.jpg" },
               new Image() { ImageId = 3, ImageSrc = "https://images.squarespace-cdn.com/content/v1/5e10bdc20efb8f0d169f85f9/09943d85-b8c7-4d64-af31-1a27d1b76698/arrow.png" },
               new Image() { ImageId = 4, ImageSrc = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQV1_mGYXjq3eWha-wQIRkn6ulW9X6Ws-ztw&usqp=CAU" }
           );

    }

}
