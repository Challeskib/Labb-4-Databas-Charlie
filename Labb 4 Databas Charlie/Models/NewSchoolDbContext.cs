using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Labb_4_Databas_Charlie.Models;

public partial class NewSchoolDbContext : DbContext
{
    public NewSchoolDbContext()
    {
    }

    public NewSchoolDbContext(DbContextOptions<NewSchoolDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentCourse> StudentCourses { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherCourse> TeacherCourses { get; set; }

    public virtual DbSet<VwActiveCourse> VwActiveCourses { get; set; }

    public virtual DbSet<VwAverageSalaryPerDepartment> VwAverageSalaryPerDepartments { get; set; }

    public virtual DbSet<VwDepartmentSalarySummary> VwDepartmentSalarySummaries { get; set; }

    public virtual DbSet<VwNotActiveCourse> VwNotActiveCourses { get; set; }

    public virtual DbSet<VwStaffInformation> VwStaffInformations { get; set; }

    public virtual DbSet<VwStudentClass> VwStudentClasses { get; set; }

    public virtual DbSet<VwStudentTeacherGrade> VwStudentTeacherGrades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CHARLIE;Initial Catalog=NewSchoolDb;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Class__CB1927C033C9FF9A");

            entity.ToTable("Class");

            entity.Property(e => e.ClassName).HasMaxLength(50);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__C92D71A73691A0CD");

            entity.ToTable("Course");

            entity.Property(e => e.CourseName).HasMaxLength(50);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK__Departme__014881AE8F0D23FB");

            entity.ToTable("Department");

            entity.Property(e => e.DeptName).HasMaxLength(50);
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__Grade__54F87A57B673B9E3");

            entity.ToTable("Grade");

            entity.Property(e => e.DateOfGrade).HasColumnType("datetime");

            entity.HasOne(d => d.Course).WithMany(p => p.Grades)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("fk_grade_course");

            entity.HasOne(d => d.Student).WithMany(p => p.Grades)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("fk_grade_student");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Grades)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("fk_grade_teacher");
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.SalaryId).HasName("PK__Salary__4BE204573B33EDFE");

            entity.ToTable("Salary");

            entity.Property(e => e.Salary1)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Salary");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AB1722CEFEF9");

            entity.Property(e => e.Adress).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fname).HasMaxLength(50);
            entity.Property(e => e.HireDate).HasColumnType("datetime");
            entity.Property(e => e.Lname).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Position).HasMaxLength(50);
            entity.Property(e => e.Ssn)
                .HasMaxLength(10)
                .HasColumnName("SSN");

            entity.HasOne(d => d.Dept).WithMany(p => p.Staff)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("fk_staff_department");

            entity.HasOne(d => d.Salary).WithMany(p => p.Staff)
                .HasForeignKey(d => d.SalaryId)
                .HasConstraintName("fk_staff_salary");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B990B2E2157");

            entity.ToTable("Student");

            entity.Property(e => e.Adress).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fname).HasMaxLength(50);
            entity.Property(e => e.Lname).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Ssn)
                .HasMaxLength(10)
                .HasColumnName("SSN");

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("fk_student_class");
        });

        modelBuilder.Entity<StudentCourse>(entity =>
        {
            entity.HasKey(e => e.StudentCourseId).HasName("PK__StudentC__7E3E2F929A2E04CA");

            entity.ToTable("StudentCourse");

            entity.HasOne(d => d.Course).WithMany(p => p.StudentCourses)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("fk_studentcourse_course");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentCourses)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("fk_studentcourse_student");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teacher__EDF259642A8E0503");

            entity.ToTable("Teacher");

            entity.HasOne(d => d.Class).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("fk_teacher_class");

            entity.HasOne(d => d.Staff).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("fk_teacher_staff");
        });

        modelBuilder.Entity<TeacherCourse>(entity =>
        {
            entity.ToTable("TeacherCourse");

            entity.Property(e => e.TeacherCourseId).ValueGeneratedNever();

            entity.HasOne(d => d.Course).WithMany(p => p.TeacherCourses)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_TeacherCourse_Course");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherCourses)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK_TeacherCourse_Teacher");
        });

        modelBuilder.Entity<VwActiveCourse>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ActiveCourses");

            entity.Property(e => e.CourseId).ValueGeneratedOnAdd();
            entity.Property(e => e.CourseName).HasMaxLength(50);
        });

        modelBuilder.Entity<VwAverageSalaryPerDepartment>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_AverageSalaryPerDepartment");

            entity.Property(e => e.AverageSalary).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.DeptName).HasMaxLength(50);
        });

        modelBuilder.Entity<VwDepartmentSalarySummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_DepartmentSalarySummary");

            entity.Property(e => e.DeptName).HasMaxLength(50);
            entity.Property(e => e.TotalSalary).HasColumnType("decimal(38, 0)");
        });

        modelBuilder.Entity<VwNotActiveCourse>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_NotActiveCourses");

            entity.Property(e => e.CourseId).ValueGeneratedOnAdd();
            entity.Property(e => e.CourseName).HasMaxLength(50);
        });

        modelBuilder.Entity<VwStaffInformation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_StaffInformation");

            entity.Property(e => e.Name).HasMaxLength(101);
            entity.Property(e => e.Position).HasMaxLength(50);
        });

        modelBuilder.Entity<VwStudentClass>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_StudentClass");

            entity.Property(e => e.ClassName).HasMaxLength(50);
            entity.Property(e => e.StudentName).HasMaxLength(101);
        });

        modelBuilder.Entity<VwStudentTeacherGrade>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_StudentTeacherGrade");

            entity.Property(e => e.CourseName).HasMaxLength(50);
            entity.Property(e => e.DateOfGrade).HasColumnType("datetime");
            entity.Property(e => e.StudentName).HasMaxLength(101);
            entity.Property(e => e.TeacherName).HasMaxLength(101);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
