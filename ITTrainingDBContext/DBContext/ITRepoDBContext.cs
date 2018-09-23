using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ITTrainingDBContext.DBContext
{
    public partial class ITRepoDBContext : DbContext
    {
        public ITRepoDBContext()
        {
        }

        public ITRepoDBContext(DbContextOptions<ITRepoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adminuseraccounts> Adminuseraccounts { get; set; }
        public virtual DbSet<Affiliatelinks> Affiliatelinks { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Keywords> Keywords { get; set; }
        public virtual DbSet<Lookupconstants> Lookupconstants { get; set; }
        public virtual DbSet<Subjectfortrainings> Subjectfortrainings { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Traningitems> Traningitems { get; set; }
        public virtual DbSet<Traningsources> Traningsources { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;userid=root;password=root;persistsecurityinfo=True;database=ittrainingrepodb;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adminuseraccounts>(entity =>
            {
                entity.HasKey(e => e.AdminId);

                entity.ToTable("adminuseraccounts");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_FK_AdminUserAccountsuser");

                entity.Property(e => e.AdminId).HasColumnType("char(36)");

                entity.Property(e => e.AdminEmailId)
                    .IsRequired()
                    .HasColumnName("AdminEmailID")
                    .HasColumnType("longtext");

                entity.Property(e => e.AdminFirstName)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.AdminLastName)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.AdminMobileNumber)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.AdminPassword)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.AdminUserName)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("char(36)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Adminuseraccounts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdminUserAccountsuser");
            });

            modelBuilder.Entity<Affiliatelinks>(entity =>
            {
                entity.HasKey(e => e.AffiliateId);

                entity.ToTable("affiliatelinks");

                entity.HasIndex(e => e.AffiliateId)
                    .HasName("AffiliateId")
                    .IsUnique();

                entity.HasIndex(e => e.CreateUserId)
                    .HasName("IX_FK_UsersAffiliateLinks1");

                entity.HasIndex(e => e.EditUserId)
                    .HasName("IX_FK_UsersAffiliateLinks");

                entity.HasIndex(e => e.TrainingSourceId)
                    .HasName("IX_FK_TraningSourceAffiliateLinks");

                entity.Property(e => e.AffiliateId).HasColumnType("int(11)");

                entity.Property(e => e.AffiliateLinkUrl)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .IsRequired()
                    .HasColumnType("char(36)");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EditUserId)
                    .IsRequired()
                    .HasColumnName("EditUserID")
                    .HasColumnType("char(36)");

                entity.Property(e => e.TrainingSourceId)
                    .IsRequired()
                    .HasColumnType("char(36)");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.AffiliatelinksCreateUser)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersAffiliateLinks1");

                entity.HasOne(d => d.EditUser)
                    .WithMany(p => p.AffiliatelinksEditUser)
                    .HasForeignKey(d => d.EditUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersAffiliateLinks");

                entity.HasOne(d => d.TrainingSource)
                    .WithMany(p => p.Affiliatelinks)
                    .HasForeignKey(d => d.TrainingSourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraningSourceAffiliateLinks");
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.ToTable("comments");

                entity.HasIndex(e => e.CreateUser)
                    .HasName("IX_FK_UsersComments");

                entity.HasIndex(e => e.EditUser)
                    .HasName("IX_FK_UsersComments1");

                entity.Property(e => e.CommentId).HasColumnType("char(36)");

                entity.Property(e => e.CommentDescription)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.CommentLikeCount)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.CommentOwnerId)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.CommentTitle)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasColumnType("char(36)");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasColumnType("char(36)");

                entity.Property(e => e.ParentCommentId)
                    .IsRequired()
                    .HasColumnName("ParentCommentID")
                    .HasColumnType("longtext");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.CommentsCreateUserNavigation)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersComments");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.CommentsEditUserNavigation)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersComments1");
            });

            modelBuilder.Entity<Keywords>(entity =>
            {
                entity.HasKey(e => e.KeywordId);

                entity.ToTable("keywords");

                entity.HasIndex(e => e.SubjectId)
                    .HasName("IX_FK_SubjectsKeywords");

                entity.Property(e => e.KeywordId).HasColumnType("char(36)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .IsRequired()
                    .HasColumnType("char(36)");

                entity.Property(e => e.KeywordDesc)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.SubjectId).HasColumnType("int(11)");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Keywords)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubjectsKeywords");
            });

            modelBuilder.Entity<Lookupconstants>(entity =>
            {
                entity.HasKey(e => e.LookupId);

                entity.ToTable("lookupconstants");

                entity.HasIndex(e => e.CreateUserId)
                    .HasName("IX_FK_UsersLookupConstants1");

                entity.HasIndex(e => e.EditUserId)
                    .HasName("IX_FK_UsersLookupConstants");

                entity.HasIndex(e => e.LookupId)
                    .HasName("LookupId")
                    .IsUnique();

                entity.Property(e => e.LookupId).HasColumnType("bigint(20)");

                entity.Property(e => e.CodeType)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.CodeValue)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .IsRequired()
                    .HasColumnType("char(36)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EditUserId)
                    .IsRequired()
                    .HasColumnType("char(36)");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.LookupconstantsCreateUser)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersLookupConstants1");

                entity.HasOne(d => d.EditUser)
                    .WithMany(p => p.LookupconstantsEditUser)
                    .HasForeignKey(d => d.EditUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersLookupConstants");
            });

            modelBuilder.Entity<Subjectfortrainings>(entity =>
            {
                entity.HasKey(e => new { e.SubjectId, e.TrainingItemId });

                entity.ToTable("subjectfortrainings");

                entity.HasIndex(e => e.CreateUserId)
                    .HasName("IX_FK_UsersSubjectForTraining");

                entity.HasIndex(e => e.SubjectId)
                    .HasName("SubjectId")
                    .IsUnique();

                entity.HasIndex(e => e.SubjectsSubjectId)
                    .HasName("IX_FK_SubjectForTrainingSubjects");

                entity.HasIndex(e => e.TraningItemTrainingItemId)
                    .HasName("IX_FK_TraningItemSubjectForTraining");

                entity.Property(e => e.SubjectId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TrainingItemId).HasColumnType("char(36)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .IsRequired()
                    .HasColumnType("char(36)");

                entity.Property(e => e.SubjectsSubjectId)
                    .HasColumnName("Subjects_SubjectID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TraningItemTrainingItemId)
                    .IsRequired()
                    .HasColumnName("TraningItem_TrainingItemID")
                    .HasColumnType("char(36)");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.Subjectfortrainings)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersSubjectForTraining");

                entity.HasOne(d => d.SubjectsSubject)
                    .WithMany(p => p.Subjectfortrainings)
                    .HasForeignKey(d => d.SubjectsSubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubjectForTrainingSubjects");

                entity.HasOne(d => d.TraningItemTrainingItem)
                    .WithMany(p => p.Subjectfortrainings)
                    .HasForeignKey(d => d.TraningItemTrainingItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraningItemSubjectForTraining");
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.HasKey(e => e.SubjectId);

                entity.ToTable("subjects");

                entity.HasIndex(e => e.CreateUserId)
                    .HasName("IX_FK_UsersSubjects");

                entity.HasIndex(e => e.SubjectId)
                    .HasName("SubjectID")
                    .IsUnique();

                entity.Property(e => e.SubjectId)
                    .HasColumnName("SubjectID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .IsRequired()
                    .HasColumnName("CreateUserID")
                    .HasColumnType("char(36)");

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersSubjects");
            });

            modelBuilder.Entity<Traningitems>(entity =>
            {
                entity.HasKey(e => e.TrainingItemId);

                entity.ToTable("traningitems");

                entity.HasIndex(e => e.CreateUserId)
                    .HasName("IX_FK_UsersTraningItem");

                entity.HasIndex(e => e.EditUserId)
                    .HasName("IX_FK_UsersTraningItem1");

                entity.HasIndex(e => e.ParentTrainingItemId)
                    .HasName("IX_FK_TraningItemTraningItem");

                entity.HasIndex(e => e.TrainingItemDiscussionId)
                    .HasName("IX_FK_CommentsTraningItem");

                entity.HasIndex(e => e.TrainingSourceId)
                    .HasName("IX_FK_TraningItemTraningSource");

                entity.HasIndex(e => e.TraningItemType)
                    .HasName("IX_FK_LookupConstantsTraningItem");

                entity.Property(e => e.TrainingItemId)
                    .HasColumnName("TrainingItemID")
                    .HasColumnType("char(36)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .IsRequired()
                    .HasColumnType("char(36)");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EditUserId)
                    .IsRequired()
                    .HasColumnType("char(36)");

                entity.Property(e => e.ParentTrainingItemId)
                    .IsRequired()
                    .HasColumnName("ParentTrainingItemID")
                    .HasColumnType("char(36)");

                entity.Property(e => e.TrainingItemContent).HasColumnType("longtext");

                entity.Property(e => e.TrainingItemDiscussionId)
                    .IsRequired()
                    .HasColumnType("char(36)");

                entity.Property(e => e.TrainingItemLink)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.TrainingItemTitle)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.TrainingSourceId)
                    .IsRequired()
                    .HasColumnType("char(36)");

                entity.Property(e => e.TraningItemDescription)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.TraningItemType).HasColumnType("bigint(20)");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.TraningitemsCreateUser)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersTraningItem");

                entity.HasOne(d => d.EditUser)
                    .WithMany(p => p.TraningitemsEditUser)
                    .HasForeignKey(d => d.EditUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersTraningItem1");

                entity.HasOne(d => d.ParentTrainingItem)
                    .WithMany(p => p.InverseParentTrainingItem)
                    .HasForeignKey(d => d.ParentTrainingItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraningItemTraningItem");

                entity.HasOne(d => d.TrainingItemDiscussion)
                    .WithMany(p => p.Traningitems)
                    .HasForeignKey(d => d.TrainingItemDiscussionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommentsTraningItem");

                entity.HasOne(d => d.TrainingSource)
                    .WithMany(p => p.Traningitems)
                    .HasForeignKey(d => d.TrainingSourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraningItemTraningSource");

                entity.HasOne(d => d.TraningItemTypeNavigation)
                    .WithMany(p => p.Traningitems)
                    .HasForeignKey(d => d.TraningItemType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LookupConstantsTraningItem");
            });

            modelBuilder.Entity<Traningsources>(entity =>
            {
                entity.HasKey(e => e.TrainingSourceId);

                entity.ToTable("traningsources");

                entity.HasIndex(e => e.CreateUserId)
                    .HasName("IX_FK_UsersTraningSource");

                entity.HasIndex(e => e.EditUserId)
                    .HasName("IX_FK_UsersTraningSource1");

                entity.Property(e => e.TrainingSourceId).HasColumnType("char(36)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .IsRequired()
                    .HasColumnName("CreateUserID")
                    .HasColumnType("char(36)");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EditUserId)
                    .IsRequired()
                    .HasColumnType("char(36)");

                entity.Property(e => e.WebsiteDescription)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.WebsiteLink)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.WebsiteName)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.TraningsourcesCreateUser)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersTraningSource");

                entity.HasOne(d => d.EditUser)
                    .WithMany(p => p.TraningsourcesEditUser)
                    .HasForeignKey(d => d.EditUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersTraningSource1");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnType("char(36)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EditUserId)
                    .IsRequired()
                    .HasColumnName("EditUserID")
                    .HasColumnType("longtext");

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasColumnType("longtext");
            });
        }
    }
}
