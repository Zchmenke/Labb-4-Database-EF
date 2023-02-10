using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Labb4v2.Models
{
    public partial class SchoolDbContextv7 : DbContext
    {
        public SchoolDbContextv7()
        {
        }

        public SchoolDbContextv7(DbContextOptions<SchoolDbContextv7> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Personel> Personels { get; set; }
        public virtual DbSet<RoleList> RoleLists { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }
        public virtual DbSet<ViewTesting> ViewTestings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-C2ANJQD\\MSSQLSERVER01;Initial Catalog = The School;Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Class1)
                    .HasMaxLength(50)
                    .HasColumnName("Class");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.HeadTeacherId).HasColumnName("HeadTeacherID");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.HeadTeacher)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.HeadTeacherId)
                    .HasConstraintName("FK_Courses_Personel");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepId);

                entity.ToTable("Department");

                entity.Property(e => e.DepId).HasColumnName("DepID");

                entity.Property(e => e.Depname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.Grade1).HasColumnName("Grade");

                entity.Property(e => e.GradeSub)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gradedate).HasColumnType("date");

                entity.Property(e => e.GradingTeacher).HasColumnName("Grading teacher");

                entity.Property(e => e.StudentIdgrade).HasColumnName("StudentIDGrade");

                entity.HasOne(d => d.GradingTeacherNavigation)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.GradingTeacher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grades 2 test_Personel");

                entity.HasOne(d => d.StudentIdgradeNavigation)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.StudentIdgrade)
                    .HasConstraintName("FK_Grades2test_Students");
            });

            modelBuilder.Entity<Personel>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK_Personel_1");

                entity.ToTable("Personel");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.DepId).HasColumnName("DepID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MonthlySalary).HasColumnType("money");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Personels)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("FK_Personel_Department");

                entity.HasOne(d => d.EmployeeRoleNavigation)
                    .WithMany(p => p.Personels)
                    .HasForeignKey(d => d.EmployeeRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personel_RoleList");
            });

            modelBuilder.Entity<RoleList>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("RoleList");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("Role ID");

                entity.Property(e => e.WorkRole)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.ClassIdstudent).HasColumnName("ClassIDStudent");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PersonalNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.ClassIdstudentNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassIdstudent)
                    .HasConstraintName("FK_Students_Classes");
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => e.ListId);

                entity.ToTable("StudentCourse");

                entity.Property(e => e.ListId).HasColumnName("ListID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_StudentCourse_Courses");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentCourse_Students");
            });

            modelBuilder.Entity<ViewTesting>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewTesting");

                entity.Property(e => e.Class).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
