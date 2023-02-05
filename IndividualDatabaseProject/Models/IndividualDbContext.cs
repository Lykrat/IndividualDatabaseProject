using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IndividualDatabaseProject.Models
{
    public partial class IndividualDbContext : DbContext
    {
        public IndividualDbContext()
        {
        }

        public IndividualDbContext(DbContextOptions<IndividualDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AverageSalaryDepartment> AverageSalaryDepartments { get; set; } = null!;
        public virtual DbSet<DbClass> DbClasses { get; set; } = null!;
        public virtual DbSet<DbCourse> DbCourses { get; set; } = null!;
        public virtual DbSet<DbCourseConnection> DbCourseConnections { get; set; } = null!;
        public virtual DbSet<DbDepartment> DbDepartments { get; set; } = null!;
        public virtual DbSet<DbDepartmentConnection> DbDepartmentConnections { get; set; } = null!;
        public virtual DbSet<DbEmployee> DbEmployees { get; set; } = null!;
        public virtual DbSet<DbEmploymentType> DbEmploymentTypes { get; set; } = null!;
        public virtual DbSet<DbGrade> DbGrades { get; set; } = null!;
        public virtual DbSet<DbStudent> DbStudents { get; set; } = null!;
        public virtual DbSet<EmployeeList> EmployeeLists { get; set; } = null!;
        public virtual DbSet<TotalSalaryDepartment> TotalSalaryDepartments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = LAPTOP-T8D7ORFB; Initial Catalog = IndividualDb; Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AverageSalaryDepartment>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("AverageSalaryDepartment");

                entity.Property(e => e.DepartmentName).HasMaxLength(50);

                entity.Property(e => e.TotalSalary).HasColumnType("money");
            });

            modelBuilder.Entity<DbClass>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassName).HasMaxLength(50);
            });

            modelBuilder.Entity<DbCourse>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CourseEnd).HasColumnType("date");

                entity.Property(e => e.CourseName).HasMaxLength(50);

                entity.Property(e => e.CourseStart).HasColumnType("date");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DbCourses)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DbCourses_DbDepartment");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.DbCourses)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DbCourses_DbEmployee");
            });

            modelBuilder.Entity<DbCourseConnection>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DbCourseConnection");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Course)
                    .WithMany()
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DbCourseConnection_DbCourses");

                entity.HasOne(d => d.Student)
                    .WithMany()
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DbCourseConnection_DbStudents");
            });

            modelBuilder.Entity<DbDepartment>(entity =>
            {
                entity.ToTable("DbDepartment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DepartmentName).HasMaxLength(50);
            });

            modelBuilder.Entity<DbDepartmentConnection>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DbDepartmentConnection");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Department)
                    .WithMany()
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DbDepartmentConnection_DbDepartment");

                entity.HasOne(d => d.Teacher)
                    .WithMany()
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DbDepartmentConnection_DbEmployee");
            });

            modelBuilder.Entity<DbEmployee>(entity =>
            {
                entity.ToTable("DbEmployee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmploymentId).HasColumnName("EmploymentID");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .HasColumnName("LName");

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Employment)
                    .WithMany(p => p.DbEmployees)
                    .HasForeignKey(d => d.EmploymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DbEmployee_DbEmployment_Type");
            });

            modelBuilder.Entity<DbEmploymentType>(entity =>
            {
                entity.ToTable("DbEmployment_Type");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Employment).HasMaxLength(50);
            });

            modelBuilder.Entity<DbGrade>(entity =>
            {
                entity.ToTable("DbGrade");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.DateTime).HasColumnType("date");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.DbGrades)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DbGrade_DbCourses");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.DbGrades)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DbGrade_DbStudents");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.DbGrades)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DbGrade_DbEmployee");
            });

            modelBuilder.Entity<DbStudent>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .HasColumnName("LName");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.DbStudents)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_DbStudents_DbClasses");
            });

            modelBuilder.Entity<EmployeeList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("EmployeeList");

                entity.Property(e => e.Employment).HasMaxLength(50);

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .HasColumnName("LName");
            });

            modelBuilder.Entity<TotalSalaryDepartment>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TotalSalaryDepartment");

                entity.Property(e => e.DepartmentName).HasMaxLength(50);

                entity.Property(e => e.TotalSalary).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
