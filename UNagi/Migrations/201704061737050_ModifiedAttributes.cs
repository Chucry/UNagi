namespace UNagi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedAttributes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MaestroMaterias", "Maestro_Id", "dbo.Maestros");
            DropForeignKey("dbo.MateriaAlumnoes", new[] { "Alumno_Id", "Alumno_Matricula" }, "dbo.Alumnos");
            DropIndex("dbo.MaestroMaterias", new[] { "Maestro_Id" });
            DropPrimaryKey("dbo.Alumnos");
            DropPrimaryKey("dbo.Maestros");
            DropPrimaryKey("dbo.MaestroMaterias");
            AddColumn("dbo.MaestroMaterias", "Maestro_Email", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Alumnos", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Maestros", "Email", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Alumnos", new[] { "Id", "Matricula" });
            AddPrimaryKey("dbo.Maestros", new[] { "Id", "Email" });
            AddPrimaryKey("dbo.MaestroMaterias", new[] { "Maestro_Id", "Maestro_Email", "Materia_Id" });
            CreateIndex("dbo.MaestroMaterias", new[] { "Maestro_Id", "Maestro_Email" });
            AddForeignKey("dbo.MaestroMaterias", new[] { "Maestro_Id", "Maestro_Email" }, "dbo.Maestros", new[] { "Id", "Email" }, cascadeDelete: true);
            AddForeignKey("dbo.MateriaAlumnoes", new[] { "Alumno_Id", "Alumno_Matricula" }, "dbo.Alumnos", new[] { "Id", "Matricula" }, cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MateriaAlumnoes", new[] { "Alumno_Id", "Alumno_Matricula" }, "dbo.Alumnos");
            DropForeignKey("dbo.MaestroMaterias", new[] { "Maestro_Id", "Maestro_Email" }, "dbo.Maestros");
            DropIndex("dbo.MaestroMaterias", new[] { "Maestro_Id", "Maestro_Email" });
            DropPrimaryKey("dbo.MaestroMaterias");
            DropPrimaryKey("dbo.Maestros");
            DropPrimaryKey("dbo.Alumnos");
            AlterColumn("dbo.Maestros", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Alumnos", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.MaestroMaterias", "Maestro_Email");
            AddPrimaryKey("dbo.MaestroMaterias", new[] { "Maestro_Id", "Materia_Id" });
            AddPrimaryKey("dbo.Maestros", "Id");
            AddPrimaryKey("dbo.Alumnos", new[] { "Id", "Matricula" });
            CreateIndex("dbo.MaestroMaterias", "Maestro_Id");
            AddForeignKey("dbo.MateriaAlumnoes", new[] { "Alumno_Id", "Alumno_Matricula" }, "dbo.Alumnos", new[] { "Id", "Matricula" }, cascadeDelete: true);
            AddForeignKey("dbo.MaestroMaterias", "Maestro_Id", "dbo.Maestros", "Id", cascadeDelete: true);
        }
    }
}
