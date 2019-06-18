﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeacherQueue.DAL;

namespace TeacherQueue.Migrations
{
    [DbContext(typeof(QueueContext))]
    partial class QueueContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TeacherQueue.Models.DatabaseModels.Queue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Size");

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId")
                        .IsUnique();

                    b.ToTable("Queues");
                });

            modelBuilder.Entity("TeacherQueue.Models.DatabaseModels.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("TeacherQueue.Models.DatabaseModels.StudentQueue", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("QueueId");

                    b.HasKey("StudentId", "QueueId");

                    b.HasIndex("QueueId");

                    b.ToTable("StudentQueue");
                });

            modelBuilder.Entity("TeacherQueue.Models.DatabaseModels.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FirstMidName");

                    b.Property<bool>("HasQueue");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Salt");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("TeacherQueue.Models.DatabaseModels.Queue", b =>
                {
                    b.HasOne("TeacherQueue.Models.DatabaseModels.Teacher", "Teacher")
                        .WithOne("Queue")
                        .HasForeignKey("TeacherQueue.Models.DatabaseModels.Queue", "TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TeacherQueue.Models.DatabaseModels.StudentQueue", b =>
                {
                    b.HasOne("TeacherQueue.Models.DatabaseModels.Queue", "Queue")
                        .WithMany("StudentQueues")
                        .HasForeignKey("QueueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TeacherQueue.Models.DatabaseModels.Student", "Student")
                        .WithMany("StudentQueues")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
