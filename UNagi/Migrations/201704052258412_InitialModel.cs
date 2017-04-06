namespace UNagi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumnos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Matricula = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Contraseña = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.Matricula });
            
            CreateTable(
                "dbo.Materias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Maestros",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Contraseña = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MateriaAlumnoes",
                c => new
                    {
                        Materia_Id = c.Int(nullable: false),
                        Alumno_Id = c.Int(nullable: false),
                        Alumno_Matricula = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Materia_Id, t.Alumno_Id, t.Alumno_Matricula })
                .ForeignKey("dbo.Materias", t => t.Materia_Id, cascadeDelete: true)
                .ForeignKey("dbo.Alumnos", t => new { t.Alumno_Id, t.Alumno_Matricula }, cascadeDelete: true)
                .Index(t => t.Materia_Id)
                .Index(t => new { t.Alumno_Id, t.Alumno_Matricula });
            
            CreateTable(
                "dbo.MaestroMaterias",
                c => new
                    {
                        Maestro_Id = c.Int(nullable: false),
                        Materia_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Maestro_Id, t.Materia_Id })
                .ForeignKey("dbo.Maestros", t => t.Maestro_Id, cascadeDelete: true)
                .ForeignKey("dbo.Materias", t => t.Materia_Id, cascadeDelete: true)
                .Index(t => t.Maestro_Id)
                .Index(t => t.Materia_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MaestroMaterias", "Materia_Id", "dbo.Materias");
            DropForeignKey("dbo.MaestroMaterias", "Maestro_Id", "dbo.Maestros");
            DropForeignKey("dbo.MateriaAlumnoes", new[] { "Alumno_Id", "Alumno_Matricula" }, "dbo.Alumnos");
            DropForeignKey("dbo.MateriaAlumnoes", "Materia_Id", "dbo.Materias");
            DropIndex("dbo.MaestroMaterias", new[] { "Materia_Id" });
            DropIndex("dbo.MaestroMaterias", new[] { "Maestro_Id" });
            DropIndex("dbo.MateriaAlumnoes", new[] { "Alumno_Id", "Alumno_Matricula" });
            DropIndex("dbo.MateriaAlumnoes", new[] { "Materia_Id" });
            DropTable("dbo.MaestroMaterias");
            DropTable("dbo.MateriaAlumnoes");
            DropTable("dbo.Maestros");
            DropTable("dbo.Materias");
            DropTable("dbo.Alumnos");
        }
    }
}
