using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Kachok.Data;
using Kachok.Data.Logging;

namespace kachok.Migrations.KachokLogging
{
    [DbContext(typeof(KachokLoggingContext))]
    [Migration("20160604033018_Logging")]
    partial class Logging
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kachok.Data.Logging.RequestLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Browser")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Exception")
                        .HasAnnotation("MaxLength", 2000);

                    b.Property<string>("HostAddress")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Logger")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 4000);

                    b.Property<string>("RequestID");

                    b.Property<string>("Thread")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("Url")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Username")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.ToTable("ApplicationLog");
                });
        }
    }
}
