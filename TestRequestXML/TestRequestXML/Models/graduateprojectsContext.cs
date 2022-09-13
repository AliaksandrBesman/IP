using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TestRequestXML.Models
{
    public partial class graduateprojectsContext : DbContext
    {
        public graduateprojectsContext()
        {
        }

        public graduateprojectsContext(DbContextOptions<graduateprojectsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<ConfirmedStageByAssigned> ConfirmedStageByAssigned { get; set; }
        public virtual DbSet<ConfirmedStageStudents> ConfirmedStageStudents { get; set; }
        public virtual DbSet<CountConfirmedStageStudent> CountConfirmedStageStudent { get; set; }
        public virtual DbSet<CountStageStudents> CountStageStudents { get; set; }
        public virtual DbSet<CountSubtasks> CountSubtasks { get; set; }
        public virtual DbSet<CountTasksInStatusByAssigned> CountTasksInStatusByAssigned { get; set; }
        public virtual DbSet<Notices> Notices { get; set; }
        public virtual DbSet<NoticesList> NoticesList { get; set; }
        public virtual DbSet<StudentsTasks> StudentsTasks { get; set; }
        public virtual DbSet<TaskModeVisible> TaskModeVisible { get; set; }
        public virtual DbSet<TaskNodeTaskInfo> TaskNodeTaskInfo { get; set; }
        public virtual DbSet<TaskPriority> TaskPriority { get; set; }
        public virtual DbSet<TaskStatus> TaskStatus { get; set; }
        public virtual DbSet<TaskType> TaskType { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<TasksStageStat> TasksStageStat { get; set; }
        public virtual DbSet<TasksStatList> TasksStatList { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<UserRolesView> UserRolesView { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersDetails> UsersDetails { get; set; }
        public virtual DbSet<UsersInfo> UsersInfo { get; set; }
        public virtual DbSet<UsersRolesView> UsersRolesView { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("workstation id=graduate-projects.mssql.somee.com;packet size=4096;user id=AliaksandrBesman_SQLLogin_1;pwd=p1b7e8tsp2;data source=graduate-projects.mssql.somee.com;persist security info=False;initial catalog=graduate-projects");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ConfirmedStageByAssigned>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ConfirmedStageByAssigned");

                entity.Property(e => e.ConfirmedStage)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CountSubtasks).HasColumnName("Count_Subtasks");

                entity.Property(e => e.MtId).HasColumnName("mt_id");

                entity.Property(e => e.MtName)
                    .HasColumnName("mt_name")
                    .HasMaxLength(30);

                entity.Property(e => e.TAssignedById).HasColumnName("t_AssignedById");
            });

            modelBuilder.Entity<ConfirmedStageStudents>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ConfirmedStageStudents");

                entity.Property(e => e.CountStageStudent).HasColumnName("countStageStudent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30);

                entity.Property(e => e.NodeName).HasMaxLength(30);
            });

            modelBuilder.Entity<CountConfirmedStageStudent>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CountConfirmedStageStudent");

                entity.Property(e => e.CountConfirmedStageStudent1).HasColumnName("CountConfirmedStageStudent");

                entity.Property(e => e.MtId).HasColumnName("mt_id");

                entity.Property(e => e.MtName)
                    .HasColumnName("mt_name")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<CountStageStudents>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CountStageStudents");

                entity.Property(e => e.CountStageStudent).HasColumnName("countStageStudent");

                entity.Property(e => e.MtId).HasColumnName("mt_id");
            });

            modelBuilder.Entity<CountSubtasks>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Count_Subtasks");

                entity.Property(e => e.CountSubtasks1).HasColumnName("Count_Subtasks");
            });

            modelBuilder.Entity<CountTasksInStatusByAssigned>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CountTasksInStatusByAssigned");

                entity.Property(e => e.CountTasksInStatusByAssigned1).HasColumnName("CountTasksInStatusByAssigned");

                entity.Property(e => e.MtAssignedById).HasColumnName("mt_AssignedById");

                entity.Property(e => e.MtId).HasColumnName("mt_id");

                entity.Property(e => e.MtName)
                    .HasColumnName("mt_name")
                    .HasMaxLength(30);

                entity.Property(e => e.MtStatusId).HasColumnName("mt_StatusId");

                entity.Property(e => e.MtTaskNodeId).HasColumnName("mt_TaskNodeId");

                entity.Property(e => e.SbAssignedById).HasColumnName("sb_AssignedById");

                entity.Property(e => e.SbId).HasColumnName("sb_id");

                entity.Property(e => e.SbName)
                    .HasColumnName("sb_name")
                    .HasMaxLength(30);

                entity.Property(e => e.SbStatusId).HasColumnName("sb_StatusId");

                entity.Property(e => e.SbTaskNodeId).HasColumnName("sb_TaskNodeId");

                entity.Property(e => e.TAssignedById).HasColumnName("t_AssignedById");

                entity.Property(e => e.TId).HasColumnName("t_id");

                entity.Property(e => e.TName)
                    .HasColumnName("t_name")
                    .HasMaxLength(30);

                entity.Property(e => e.TStatusId).HasColumnName("t_StatusId");

                entity.Property(e => e.TTaskNodeId).HasColumnName("t_TaskNodeId");
            });

            modelBuilder.Entity<Notices>(entity =>
            {
                entity.HasOne(d => d.AssignedBy)
                    .WithMany(p => p.Notices)
                    .HasForeignKey(d => d.AssignedById)
                    .HasConstraintName("FK_Notices_Assigned_to_User");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Notices)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_Notices_to_Tasks");
            });

            modelBuilder.Entity<NoticesList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("NoticesList");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Priority).HasMaxLength(10);

                entity.Property(e => e.ReporterName).HasMaxLength(30);

                entity.Property(e => e.ReporterSecondName).HasMaxLength(40);

                entity.Property(e => e.ReporterSurname).HasMaxLength(30);

                entity.Property(e => e.SecondName).HasMaxLength(40);

                entity.Property(e => e.Status).HasMaxLength(30);

                entity.Property(e => e.Surname).HasMaxLength(30);

                entity.Property(e => e.TaskName)
                    .HasColumnName("taskName")
                    .HasMaxLength(30);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.Type).HasMaxLength(30);

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<StudentsTasks>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("StudentsTasks");

                entity.Property(e => e.DId).HasColumnName("d_Id");

                entity.Property(e => e.DName)
                    .HasColumnName("d_Name")
                    .HasMaxLength(30);

                entity.Property(e => e.DTitle)
                    .HasColumnName("d_Title")
                    .HasMaxLength(100);

                entity.Property(e => e.SId).HasColumnName("s_Id");

                entity.Property(e => e.SName)
                    .HasColumnName("s_Name")
                    .HasMaxLength(30);

                entity.Property(e => e.STitle)
                    .HasColumnName("s_Title")
                    .HasMaxLength(100);

                entity.Property(e => e.StAssignedById).HasColumnName("st_AssignedById");

                entity.Property(e => e.StId).HasColumnName("st_Id");

                entity.Property(e => e.StName)
                    .HasColumnName("st_Name")
                    .HasMaxLength(30);

                entity.Property(e => e.StStatus)
                    .HasColumnName("st_Status")
                    .HasMaxLength(30);

                entity.Property(e => e.StTitle)
                    .HasColumnName("st_Title")
                    .HasMaxLength(100);

                entity.Property(e => e.TId).HasColumnName("t_Id");

                entity.Property(e => e.TName)
                    .HasColumnName("t_Name")
                    .HasMaxLength(30);

                entity.Property(e => e.TTitle)
                    .HasColumnName("t_Title")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TaskModeVisible>(entity =>
            {
                entity.Property(e => e.ModeVisible).HasMaxLength(10);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<TaskNodeTaskInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TaskNodeTaskInfo");

                entity.Property(e => e.NodeId).HasColumnName("nodeId");

                entity.Property(e => e.NodeName)
                    .HasColumnName("nodeName")
                    .HasMaxLength(30);

                entity.Property(e => e.TaskId).HasColumnName("taskId");
            });

            modelBuilder.Entity<TaskPriority>(entity =>
            {
                entity.Property(e => e.Priority).HasMaxLength(10);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<TaskStatus>(entity =>
            {
                entity.Property(e => e.Status).HasMaxLength(30);

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<TaskType>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.Type).HasMaxLength(30);
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.AssignedBy)
                    .WithMany(p => p.TasksAssignedBy)
                    .HasForeignKey(d => d.AssignedById)
                    .HasConstraintName("FK_Tasks_AssignedById_to_Users");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.TasksCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_Tasks_Created_to_Users");

                entity.HasOne(d => d.Mode)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.ModeId)
                    .HasConstraintName("FK_Tasks_to_TaskVisibleMode");

                entity.HasOne(d => d.Priority)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.PriorityId)
                    .HasConstraintName("FK_Tasks_to_TaskPriorities");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Tasks_to_TasksStatus");

                entity.HasOne(d => d.TaskNode)
                    .WithMany(p => p.InverseTaskNode)
                    .HasForeignKey(d => d.TaskNodeId)
                    .HasConstraintName("FK_PK_Task_to_subtask");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Tasks_to_TaskType");
            });

            modelBuilder.Entity<TasksStageStat>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Tasks_Stage_Stat");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30);

                entity.Property(e => e.NodeName)
                    .HasColumnName("nodeName")
                    .HasMaxLength(30);

                entity.Property(e => e.StStatus).HasColumnName("st_Status");

                entity.Property(e => e.Status).HasMaxLength(30);
            });

            modelBuilder.Entity<TasksStatList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("tasks_stat_list");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30);

                entity.Property(e => e.StStatus).HasColumnName("st_Status");

                entity.Property(e => e.Status).HasMaxLength(30);
            });

            modelBuilder.Entity<UserDetails>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("UQ__UserDeta__1788CC4D3823C962")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Course).HasColumnName("course");

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(40);

                entity.Property(e => e.Faculty)
                    .HasColumnName("faculty")
                    .HasMaxLength(50);

                entity.Property(e => e.Group).HasColumnName("group");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phoneNumber")
                    .HasMaxLength(20);

                entity.Property(e => e.Speciality)
                    .HasColumnName("speciality")
                    .HasMaxLength(50);

                entity.Property(e => e.Subgroup).HasColumnName("subgroup");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserDetails)
                    .HasForeignKey<UserDetails>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserDetails_to_Users");
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(60);

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<UserRolesView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("user_roles_view");

                entity.Property(e => e.Login).HasMaxLength(30);

                entity.Property(e => e.Password).HasMaxLength(30);

                entity.Property(e => e.RoleId).HasColumnName("roleId");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Login).HasMaxLength(30);

                entity.Property(e => e.ManagerId).HasColumnName("managerId");

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Password).HasMaxLength(30);

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.SecondName).HasMaxLength(40);

                entity.Property(e => e.Surname).HasMaxLength(30);

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_Users_to_Users");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Users_to_UserRoles");
            });

            modelBuilder.Entity<UsersDetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("UsersDetails");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(40);

                entity.Property(e => e.Faculty)
                    .HasColumnName("faculty")
                    .HasMaxLength(50);

                entity.Property(e => e.Group).HasColumnName("group");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ManagerId).HasColumnName("managerId");

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phoneNumber")
                    .HasMaxLength(20);

                entity.Property(e => e.SecondName).HasMaxLength(40);

                entity.Property(e => e.Speciality)
                    .HasColumnName("speciality")
                    .HasMaxLength(50);

                entity.Property(e => e.Subgroup).HasColumnName("subgroup");

                entity.Property(e => e.Surname).HasMaxLength(30);
            });

            modelBuilder.Entity<UsersInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("UsersInfo");

                entity.Property(e => e.Group).HasColumnName("group");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ManagerId).HasColumnName("managerId");

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.SecondName).HasMaxLength(40);

                entity.Property(e => e.Subgroup).HasColumnName("subgroup");

                entity.Property(e => e.Surname).HasMaxLength(30);
            });

            modelBuilder.Entity<UsersRolesView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("users_roles_view");

                entity.Property(e => e.Login).HasMaxLength(30);

                entity.Property(e => e.Password).HasMaxLength(30);

                entity.Property(e => e.RoleName).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
