namespace RestauranteStore.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Restaurante : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Almacen",
                c => new
                    {
                        AlmacenId = c.Int(nullable: false, identity: true),
                        Inventario = c.Int(nullable: false),
                        EstadoAlm = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlmacenId);
            
            CreateTable(
                "dbo.Ingredientes",
                c => new
                    {
                        IngredienteId = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        NombreIng = c.String(),
                        TipoIng = c.Int(nullable: false),
                        PlatoComidaId = c.Int(nullable: false),
                        AlmacenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IngredienteId)
                .ForeignKey("dbo.PlatoComidas", t => t.PlatoComidaId, cascadeDelete: true)
                .ForeignKey("dbo.Almacen", t => t.AlmacenId, cascadeDelete: true)
                .Index(t => t.PlatoComidaId)
                .Index(t => t.AlmacenId);
            
            CreateTable(
                "dbo.PlatoComidas",
                c => new
                    {
                        PlatoComidaId = c.Int(nullable: false, identity: true),
                        NomPlato = c.String(),
                        Precio = c.Double(nullable: false),
                        PedidoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlatoComidaId)
                .ForeignKey("dbo.Pedidos", t => t.PedidoId, cascadeDelete: true)
                .Index(t => t.PedidoId);
            
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        PedidoId = c.Int(nullable: false, identity: true),
                        CantidadPlato = c.Int(nullable: false),
                        Extra = c.String(),
                        MontoPagar = c.Double(nullable: false),
                        PersonaId = c.Int(nullable: false),
                        EstadoPedidoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PedidoId)
                .ForeignKey("dbo.EstadoPedidos", t => t.EstadoPedidoId, cascadeDelete: true)
                .ForeignKey("dbo.Personas", t => t.PersonaId, cascadeDelete: true)
                .Index(t => t.PersonaId)
                .Index(t => t.EstadoPedidoId);
            
            CreateTable(
                "dbo.EstadoPedidos",
                c => new
                    {
                        EstadoPedidoId = c.Int(nullable: false, identity: true),
                        TipoPago = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EstadoPedidoId);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        PersonaId = c.Int(nullable: false),
                        DNI = c.Int(nullable: false),
                        NombrePersona = c.String(nullable: false),
                        ApellidoPaterno = c.String(),
                        ApellidoMaterno = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Telefono = c.String(),
                        Direccion = c.String(),
                        CartaId = c.Int(nullable: false),
                        CancelarReservaId = c.Int(nullable: false),
                        ReservaId = c.Int(nullable: false),
                        TipoEmpleadoId = c.Int(nullable: false),
                        TurnoId = c.Int(nullable: false),
                        NombreCliente = c.String(),
                        NombreEmpleado = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PersonaId)
                .ForeignKey("dbo.CancelarReservas", t => t.PersonaId)
                .ForeignKey("dbo.CartasDelDia", t => t.CartaId, cascadeDelete: true)
                .ForeignKey("dbo.Reservas", t => t.PersonaId)
                .ForeignKey("dbo.TipoEmpleados", t => t.TipoEmpleadoId, cascadeDelete: true)
                .ForeignKey("dbo.Turnos", t => t.TurnoId, cascadeDelete: true)
                .Index(t => t.PersonaId)
                .Index(t => t.CartaId)
                .Index(t => t.TipoEmpleadoId)
                .Index(t => t.TurnoId);
            
            CreateTable(
                "dbo.CancelarReservas",
                c => new
                    {
                        CancelarReservaId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Hora = c.DateTime(nullable: false),
                        NumMesa = c.Int(nullable: false),
                        PersonaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CancelarReservaId);
            
            CreateTable(
                "dbo.CartasDelDia",
                c => new
                    {
                        CartaId = c.Int(nullable: false, identity: true),
                        Bebidas = c.Int(nullable: false),
                        Menu = c.Int(nullable: false),
                        Postres = c.Int(nullable: false),
                        EspecialidadDiaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartaId)
                .ForeignKey("dbo.EspecialidadDias", t => t.EspecialidadDiaId, cascadeDelete: true)
                .Index(t => t.EspecialidadDiaId);
            
            CreateTable(
                "dbo.EspecialidadDias",
                c => new
                    {
                        EspecialidadDiaId = c.Int(nullable: false, identity: true),
                        Dia = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EspecialidadDiaId);
            
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        ReservaId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Hora = c.DateTime(nullable: false),
                        PersonaId = c.Int(nullable: false),
                        MesaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReservaId)
                .ForeignKey("dbo.Mesas", t => t.MesaId, cascadeDelete: true)
                .Index(t => t.MesaId);
            
            CreateTable(
                "dbo.Mesas",
                c => new
                    {
                        MesaId = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        NumMesa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MesaId);
            
            CreateTable(
                "dbo.TipoEmpleados",
                c => new
                    {
                        TipoEmpleadoId = c.Int(nullable: false, identity: true),
                        NomTipoEmp = c.String(),
                    })
                .PrimaryKey(t => t.TipoEmpleadoId);
            
            CreateTable(
                "dbo.Turnos",
                c => new
                    {
                        TurnoId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.TurnoId);
            
            CreateTable(
                "dbo.Provedores",
                c => new
                    {
                        ProveedorId = c.Int(nullable: false, identity: true),
                        NombreEmpresa = c.String(),
                        Ruc = c.Int(nullable: false),
                        AlmacenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProveedorId)
                .ForeignKey("dbo.Almacen", t => t.AlmacenId, cascadeDelete: true)
                .Index(t => t.AlmacenId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Provedores", "AlmacenId", "dbo.Almacen");
            DropForeignKey("dbo.Ingredientes", "AlmacenId", "dbo.Almacen");
            DropForeignKey("dbo.Ingredientes", "PlatoComidaId", "dbo.PlatoComidas");
            DropForeignKey("dbo.PlatoComidas", "PedidoId", "dbo.Pedidos");
            DropForeignKey("dbo.Personas", "TurnoId", "dbo.Turnos");
            DropForeignKey("dbo.Personas", "TipoEmpleadoId", "dbo.TipoEmpleados");
            DropForeignKey("dbo.Personas", "PersonaId", "dbo.Reservas");
            DropForeignKey("dbo.Reservas", "MesaId", "dbo.Mesas");
            DropForeignKey("dbo.Pedidos", "PersonaId", "dbo.Personas");
            DropForeignKey("dbo.Personas", "CartaId", "dbo.CartasDelDia");
            DropForeignKey("dbo.CartasDelDia", "EspecialidadDiaId", "dbo.EspecialidadDias");
            DropForeignKey("dbo.Personas", "PersonaId", "dbo.CancelarReservas");
            DropForeignKey("dbo.Pedidos", "EstadoPedidoId", "dbo.EstadoPedidos");
            DropIndex("dbo.Provedores", new[] { "AlmacenId" });
            DropIndex("dbo.Reservas", new[] { "MesaId" });
            DropIndex("dbo.CartasDelDia", new[] { "EspecialidadDiaId" });
            DropIndex("dbo.Personas", new[] { "TurnoId" });
            DropIndex("dbo.Personas", new[] { "TipoEmpleadoId" });
            DropIndex("dbo.Personas", new[] { "CartaId" });
            DropIndex("dbo.Personas", new[] { "PersonaId" });
            DropIndex("dbo.Pedidos", new[] { "EstadoPedidoId" });
            DropIndex("dbo.Pedidos", new[] { "PersonaId" });
            DropIndex("dbo.PlatoComidas", new[] { "PedidoId" });
            DropIndex("dbo.Ingredientes", new[] { "AlmacenId" });
            DropIndex("dbo.Ingredientes", new[] { "PlatoComidaId" });
            DropTable("dbo.Provedores");
            DropTable("dbo.Turnos");
            DropTable("dbo.TipoEmpleados");
            DropTable("dbo.Mesas");
            DropTable("dbo.Reservas");
            DropTable("dbo.EspecialidadDias");
            DropTable("dbo.CartasDelDia");
            DropTable("dbo.CancelarReservas");
            DropTable("dbo.Personas");
            DropTable("dbo.EstadoPedidos");
            DropTable("dbo.Pedidos");
            DropTable("dbo.PlatoComidas");
            DropTable("dbo.Ingredientes");
            DropTable("dbo.Almacen");
        }
    }
}
