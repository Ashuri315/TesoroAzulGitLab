USE [master]
GO
/****** Object:  Database [TesoroAzul]    Script Date: 2/24/2025 11:44:12 PM ******/
CREATE DATABASE [TesoroAzul]
 
GO
ALTER DATABASE [TesoroAzul] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TesoroAzul].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TesoroAzul] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TesoroAzul] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TesoroAzul] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TesoroAzul] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TesoroAzul] SET ARITHABORT OFF 
GO
ALTER DATABASE [TesoroAzul] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TesoroAzul] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TesoroAzul] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TesoroAzul] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TesoroAzul] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TesoroAzul] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TesoroAzul] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TesoroAzul] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TesoroAzul] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TesoroAzul] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TesoroAzul] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TesoroAzul] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TesoroAzul] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TesoroAzul] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TesoroAzul] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TesoroAzul] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TesoroAzul] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TesoroAzul] SET RECOVERY FULL 
GO
ALTER DATABASE [TesoroAzul] SET  MULTI_USER 
GO
ALTER DATABASE [TesoroAzul] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TesoroAzul] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TesoroAzul] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TesoroAzul] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TesoroAzul] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TesoroAzul', N'ON'
GO
ALTER DATABASE [TesoroAzul] SET QUERY_STORE = OFF
GO
USE [TesoroAzul]
GO
/****** Object:  Table [dbo].[Barco]    Script Date: 2/24/2025 11:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Barco](
	[id_barco] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[descripcion] [nvarchar](700) NOT NULL,
	[foto] [varbinary](max) NULL,
 CONSTRAINT [PK_Barco] PRIMARY KEY CLUSTERED 
(
	[id_barco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BarcoHabitacion]    Script Date: 2/24/2025 11:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BarcoHabitacion](
	[id_barco] [int] NOT NULL,
	[id_habitacion] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
 CONSTRAINT [PK_CruceroHabitacion] PRIMARY KEY CLUSTERED 
(
	[id_barco] ASC,
	[id_habitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calendario]    Script Date: 2/24/2025 11:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calendario](
	[fecha_inicio] [date] NOT NULL,
	[id_crucero] [int] NOT NULL,
	[fecha_pago] [date] NOT NULL,
 CONSTRAINT [PK_Calendario] PRIMARY KEY CLUSTERED 
(
	[fecha_inicio] ASC,
	[id_crucero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CalendarioHabitacion]    Script Date: 2/24/2025 11:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalendarioHabitacion](
	[id_habitacion] [int] NOT NULL,
	[fecha_inicio] [date] NOT NULL,
	[id_crucero] [int] NOT NULL,
	[precio] [float] NOT NULL,
	[disponible] [int] NOT NULL,
 CONSTRAINT [PK_CalendarioHabitacion] PRIMARY KEY CLUSTERED 
(
	[id_habitacion] ASC,
	[fecha_inicio] ASC,
	[id_crucero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Complemento]    Script Date: 2/24/2025 11:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Complemento](
	[id_complemento] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[descripcion] [nvarchar](200) NOT NULL,
	[precio] [int] NOT NULL,
	[precio_aplicado] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Complemento] PRIMARY KEY CLUSTERED 
(
	[id_complemento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Crucero]    Script Date: 2/24/2025 11:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Crucero](
	[id_crucero] [int] NOT NULL,
	[id_barco] [int] NOT NULL,
	[nombre] [nvarchar](300) NOT NULL,
	[foto] [varbinary](max) NULL,
	[cantidad_dias] [int] NOT NULL,
 CONSTRAINT [PK_Crucero] PRIMARY KEY CLUSTERED 
(
	[id_crucero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CruceroPuerto]    Script Date: 2/24/2025 11:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CruceroPuerto](
	[id_crucero] [int] NOT NULL,
	[id_puerto] [int] NOT NULL,
	[hora_llegada] [nvarchar](50) NULL,
	[hora_salida] [nvarchar](50) NULL,
	[numero_dia] [int] NOT NULL,
 CONSTRAINT [PK_CruceroPuerto] PRIMARY KEY CLUSTERED 
(
	[id_crucero] ASC,
	[id_puerto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CuentaCobrar]    Script Date: 2/24/2025 11:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuentaCobrar](
	[id_reserva] [int] NOT NULL,
	[montoCobrar] [int] NOT NULL,
 CONSTRAINT [PK_CuentaCobrar] PRIMARY KEY CLUSTERED 
(
	[id_reserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Habitacion]    Script Date: 2/24/2025 11:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Habitacion](
	[id_habitacion] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[descripcion] [nvarchar](200) NOT NULL,
	[maximo_huespedes] [int] NOT NULL,
	[minimo_huespedes] [int] NOT NULL,
	[tamanio] [int] NOT NULL,
 CONSTRAINT [PK_Habitacion] PRIMARY KEY CLUSTERED 
(
	[id_habitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Huesped]    Script Date: 2/24/2025 11:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Huesped](
	[id_huesped] [int] NOT NULL,
	[nombre] [nvarchar](200) NOT NULL,
	[telefono] [int] NOT NULL,
	[email] [nvarchar](150) NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_Huesped] PRIMARY KEY CLUSTERED 
(
	[id_huesped] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 2/24/2025 11:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[id_pais] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Pais] PRIMARY KEY CLUSTERED 
(
	[id_pais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puerto]    Script Date: 2/24/2025 11:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puerto](
	[id_puerto] [int] NOT NULL,
	[id_pais] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Puerto] PRIMARY KEY CLUSTERED 
(
	[id_puerto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservaComplemento]    Script Date: 2/24/2025 11:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservaComplemento](
	[id_reserva] [int] NOT NULL,
	[id_complemento] [int] NOT NULL,
 CONSTRAINT [PK_ReservaComplemento] PRIMARY KEY CLUSTERED 
(
	[id_reserva] ASC,
	[id_complemento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservaDetalle]    Script Date: 2/24/2025 11:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservaDetalle](
	[id_reserva] [int] NOT NULL,
	[id_reserva_detalle] [int] NOT NULL,
	[id_habitacion] [int] NOT NULL,
	[id_huesped] [int] NULL,
 CONSTRAINT [PK_ReservaDetalle] PRIMARY KEY CLUSTERED 
(
	[id_reserva] ASC,
	[id_reserva_detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservaEncabezado]    Script Date: 2/24/2025 11:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservaEncabezado](
	[id_reserva] [int] NOT NULL,
	[fecha_inicio] [date] NOT NULL,
	[id_crucero] [int] NOT NULL,
	[id_usuario] [int] NOT NULL,
	[cantidad_habitaciones] [int] NOT NULL,
	[cantidad_pasajeros] [int] NOT NULL,
	[total_habitaciones] [int] NOT NULL,
	[total_complementos] [int] NOT NULL,
	[subtotal] [int] NOT NULL,
	[impuestos] [int] NOT NULL,
	[total] [int] NOT NULL,
	[pendiente] [bit] NOT NULL,
 CONSTRAINT [PK_ReservaEncabezado] PRIMARY KEY CLUSTERED 
(
	[id_reserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 2/24/2025 11:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id_usuario] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[contrasena] [nvarchar](50) NOT NULL,
	[tipo] [nvarchar](50) NOT NULL,
	[telefono] [int] NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[nacionalidad] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Barco] ([id_barco], [nombre], [descripcion], [foto]) VALUES (1, N'MSC Fantasia', N'MSC Fantasia es uno de los cruceros más bellos en el mar con sus escaleras tachonadas de cristal, candelabros de cristal de Murano y piedra pulida en la plaza.', NULL)
GO
INSERT [dbo].[Barco] ([id_barco], [nombre], [descripcion], [foto]) VALUES (2, N'MSC Orchesta', N'Combinando interiores espaciosos y elegantes con excelentes restaurantes, un variado programa de entretenimiento y comodidades de alta calidad estilo resort, MSC Orchestra te promete un crucero de ensueño.', NULL)
GO
INSERT [dbo].[Barco] ([id_barco], [nombre], [descripcion], [foto]) VALUES (3, N'MSC Poesía', N'Este increíble superliner es un barco elegante y lujoso con una espectacular cascada con puentes en el vestíbulo, un jardín zen en el bar de sushi y un tranquilo spa de 13,000 pies cuadrados.', NULL)
GO
INSERT [dbo].[Barco] ([id_barco], [nombre], [descripcion], [foto]) VALUES (4, N'MSC Música', N'Con elegantes piscinas y atractivas áreas de juego para los niños, así como un lujoso spa, teatro, un glamuroso casino, una discoteca panorámica y mucho más, MSC Música ofrece a sus huéspedes un mundo de actividades diurnas y entretenimiento nocturno.', NULL)
GO
INSERT [dbo].[Barco] ([id_barco], [nombre], [descripcion], [foto]) VALUES (5, N'MSC Ópera', N'Lleva el nombre de la forma de arte italiana por excelencia, la ópera. Está construido con líneas más clásicas que sus hermanos de las clases Musica y Fantasia, lo que crea un ambiente especial a bordo y le permite visitar aquellos destinos que son inaccesibles para embarcaciones más grandes.', NULL)
GO
INSERT [dbo].[Barco] ([id_barco], [nombre], [descripcion], [foto]) VALUES (6, N'MSC Armonía', N'Con una combinación distintiva de estilo mediterráneo clásico y diseño pionero. ofrece la más amplia selección posible de música para todos los gustos y estados de ánimo. Elija entre una amplia variedad de alojamientos elegantes, que incluyen cómodas suites, cabañas con vista al mar y cabañas con su propio balcón privado.', NULL)
GO
INSERT [dbo].[Barco] ([id_barco], [nombre], [descripcion], [foto]) VALUES (7, N'MSC Bellísima', N'Ofrece diversión sin fin para toda la familia, desde espectáculos en vivo hasta boleras de tamaño completo y MSC Formula Racer. Luego está el parque acuático interactivo con temática del Gran Cañón, el centro deportivo y las áreas innovadoras y actividades para niños y adolescentes.', NULL)
GO
INSERT [dbo].[Barco] ([id_barco], [nombre], [descripcion], [foto]) VALUES (8, N'MSC Virtuosa', N'A bordo del MSC Virtuosa, tendrás la oportunidad única de admirar dos producciones espectaculares: AJEDREZ, inspirada en el juego de ajedrez, y ARKYMEA, la historia de un científico en busca de un mundo oculto. Es el segundo de los aclamados buques de la clase Meraviglia-Plus.', NULL)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (1, 2, 2)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (1, 5, 3)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (1, 8, 4)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (1, 11, 5)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (2, 3, 2)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (2, 6, 3)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (2, 9, 4)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (2, 12, 5)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (3, 1, 2)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (3, 5, 3)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (3, 9, 4)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (3, 10, 5)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (4, 2, 2)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (4, 6, 3)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (4, 7, 4)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (4, 11, 5)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (5, 3, 2)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (5, 4, 3)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (5, 8, 4)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (5, 12, 5)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (6, 1, 2)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (6, 3, 3)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (6, 5, 4)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (6, 7, 5)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (6, 9, 2)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (6, 11, 3)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (7, 2, 4)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (7, 4, 5)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (7, 6, 2)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (7, 8, 3)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (7, 10, 4)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (7, 12, 5)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (8, 1, 2)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (8, 4, 3)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (8, 7, 4)
GO
INSERT [dbo].[BarcoHabitacion] ([id_barco], [id_habitacion], [cantidad]) VALUES (8, 10, 5)
GO
INSERT [dbo].[Calendario] ([fecha_inicio], [id_crucero], [fecha_pago]) VALUES (CAST(N'2025-03-16' AS Date), 2, CAST(N'2025-03-09' AS Date))
GO
INSERT [dbo].[Calendario] ([fecha_inicio], [id_crucero], [fecha_pago]) VALUES (CAST(N'2025-03-27' AS Date), 1, CAST(N'2025-03-20' AS Date))
GO
INSERT [dbo].[Calendario] ([fecha_inicio], [id_crucero], [fecha_pago]) VALUES (CAST(N'2025-04-01' AS Date), 3, CAST(N'2025-03-22' AS Date))
GO
INSERT [dbo].[Calendario] ([fecha_inicio], [id_crucero], [fecha_pago]) VALUES (CAST(N'2025-04-20' AS Date), 4, CAST(N'2025-04-13' AS Date))
GO
INSERT [dbo].[Calendario] ([fecha_inicio], [id_crucero], [fecha_pago]) VALUES (CAST(N'2025-04-27' AS Date), 2, CAST(N'2025-04-20' AS Date))
GO
INSERT [dbo].[Calendario] ([fecha_inicio], [id_crucero], [fecha_pago]) VALUES (CAST(N'2025-04-30' AS Date), 3, CAST(N'2025-04-23' AS Date))
GO
INSERT [dbo].[Calendario] ([fecha_inicio], [id_crucero], [fecha_pago]) VALUES (CAST(N'2025-05-23' AS Date), 3, CAST(N'2025-05-15' AS Date))
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (1, CAST(N'2025-04-01' AS Date), 3, 483744, 2)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (1, CAST(N'2025-04-30' AS Date), 3, 483744, 2)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (1, CAST(N'2025-05-23' AS Date), 3, 483744, 2)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (2, CAST(N'2025-03-27' AS Date), 1, 525000, 2)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (2, CAST(N'2025-04-20' AS Date), 4, 1019389, 2)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (3, CAST(N'2025-03-16' AS Date), 2, 517000, 2)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (3, CAST(N'2025-04-27' AS Date), 2, 320000, 2)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (5, CAST(N'2025-03-27' AS Date), 1, 650000, 3)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (5, CAST(N'2025-04-01' AS Date), 3, 683792, 3)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (5, CAST(N'2025-04-30' AS Date), 3, 683792, 3)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (5, CAST(N'2025-05-23' AS Date), 3, 683792, 3)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (6, CAST(N'2025-03-16' AS Date), 2, 658000, 3)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (6, CAST(N'2025-04-20' AS Date), 4, 1257230, 3)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (6, CAST(N'2025-04-27' AS Date), 2, 450000, 3)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (7, CAST(N'2025-04-20' AS Date), 4, 1396810, 4)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (8, CAST(N'2025-03-27' AS Date), 1, 816318, 4)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (9, CAST(N'2025-03-16' AS Date), 2, 777000, 4)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (9, CAST(N'2025-04-01' AS Date), 3, 925160, 4)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (9, CAST(N'2025-04-27' AS Date), 2, 590000, 4)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (9, CAST(N'2025-04-30' AS Date), 3, 925160, 4)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (9, CAST(N'2025-05-23' AS Date), 3, 925160, 4)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (10, CAST(N'2025-04-01' AS Date), 3, 1639186, 5)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (10, CAST(N'2025-04-30' AS Date), 3, 1639186, 5)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (10, CAST(N'2025-05-23' AS Date), 3, 1639186, 5)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (11, CAST(N'2025-03-27' AS Date), 1, 1623000, 5)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (11, CAST(N'2025-04-20' AS Date), 4, 2803195, 5)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (12, CAST(N'2025-03-16' AS Date), 2, 1506157, 5)
GO
INSERT [dbo].[CalendarioHabitacion] ([id_habitacion], [fecha_inicio], [id_crucero], [precio], [disponible]) VALUES (12, CAST(N'2025-04-27' AS Date), 2, 1300000, 5)
GO
INSERT [dbo].[Crucero] ([id_crucero], [id_barco], [nombre], [foto], [cantidad_dias]) VALUES (1, 1, N'Trasatlántico por Brasil, Cabo Verde, Portugal.', NULL, 15)
GO
INSERT [dbo].[Crucero] ([id_crucero], [id_barco], [nombre], [foto], [cantidad_dias]) VALUES (2, 2, N'Trasatlántico por Brasil, Cabo Verde, Marruecos, España.', NULL, 16)
GO
INSERT [dbo].[Crucero] ([id_crucero], [id_barco], [nombre], [foto], [cantidad_dias]) VALUES (3, 3, N'Trasatlántico por Brasil, Cabo Verde, Marruecos, España.', NULL, 16)
GO
INSERT [dbo].[Crucero] ([id_crucero], [id_barco], [nombre], [foto], [cantidad_dias]) VALUES (4, 4, N'Trasatlántico por Brasil, Cabo Verde, España, Francia, Holanda, Alemania', NULL, 16)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (1, 1, N'--', N'18:00', 1)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (1, 2, N'14:00', N'20:00', 3)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (1, 3, N'13:00', N'19:00', 4)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (1, 4, N'08:00', N'17:00', 5)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (1, 5, N'08:00', N'18:00', 10)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (1, 7, N'08:00', N'16:00', 13)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (1, 11, N'12:00', N'--', 15)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (2, 1, N'--', N'20:00', 1)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (2, 4, N'10:00', N'18:00', 4)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (2, 6, N'08:00', N'18:00', 9)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (2, 7, N'08:00', N'16:00', 12)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (2, 12, N'07:00', N'20:00', 14)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (2, 16, N'14:00', N'--', 16)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (3, 1, N'--', N'20:00', 1)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (3, 4, N'10:00', N'18:00', 4)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (3, 6, N'08:00', N'18:00', 9)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (3, 8, N'08:00', N'16:00', 12)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (3, 12, N'07:00', N'20:00', 14)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (3, 16, N'14:00', N'--', 16)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (4, 3, N'--', N'20:00', 1)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (4, 5, N'09:00', N'18:00', 6)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (4, 9, N'10:00', N'18:00', 10)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (4, 10, N'08:00', N'16:00', 11)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (4, 13, N'10:00', N'21:30', 13)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (4, 14, N'14:00', N'22:00', 14)
GO
INSERT [dbo].[CruceroPuerto] ([id_crucero], [id_puerto], [hora_llegada], [hora_salida], [numero_dia]) VALUES (4, 15, N'08:00', N'--', 16)
GO
INSERT [dbo].[Habitacion] ([id_habitacion], [nombre], [descripcion], [maximo_huespedes], [minimo_huespedes], [tamanio]) VALUES (1, N'Interior Bella', N'La opción más económica. Un refugio cómodo y acogedor. 
Perfecto para tomar siestas largas después de un día lleno de aventuras', 2, 1, 15)
GO
INSERT [dbo].[Habitacion] ([id_habitacion], [nombre], [descripcion], [maximo_huespedes], [minimo_huespedes], [tamanio]) VALUES (2, N'Interior Studio', N'Camarote interior con vista al centro comercial interno.
Ideal para venir con la pareja o en familia.', 4, 1, 14)
GO
INSERT [dbo].[Habitacion] ([id_habitacion], [nombre], [descripcion], [maximo_huespedes], [minimo_huespedes], [tamanio]) VALUES (3, N'Interior Deluxe', N'Conectado con el centro comercial interno. Ideal para familias grandes.
Se aceptan mascotas.', 6, 2, 14)
GO
INSERT [dbo].[Habitacion] ([id_habitacion], [nombre], [descripcion], [maximo_huespedes], [minimo_huespedes], [tamanio]) VALUES (4, N'Mar Bella', N'Mayor superficie a un precio excelente.
Perfecto si necesitas ese pequeño espacio extra.
Tu propia ventana en el camarote.', 3, 1, 20)
GO
INSERT [dbo].[Habitacion] ([id_habitacion], [nombre], [descripcion], [maximo_huespedes], [minimo_huespedes], [tamanio]) VALUES (5, N'Mar Studio', N'Económico con vista al mar.
Tu propia ventana en el camarote.
Ideal para familias con niños pequeños.', 5, 2, 15)
GO
INSERT [dbo].[Habitacion] ([id_habitacion], [nombre], [descripcion], [maximo_huespedes], [minimo_huespedes], [tamanio]) VALUES (6, N'Mar Deluxe', N'Ventana de piso a techo en el camarote. 
Disfruta de vistas en 180 grados.  Desayuno gratis en la cabina y prioridad para elegir el horario de la cena', 4, 2, 17)
GO
INSERT [dbo].[Habitacion] ([id_habitacion], [nombre], [descripcion], [maximo_huespedes], [minimo_huespedes], [tamanio]) VALUES (7, N'Balcón Bella', N'Camarote exterior con balcón privado (vista al mar o vista al paseo). Ideal para familias. Se permiten mascotas', 5, 1, 21)
GO
INSERT [dbo].[Habitacion] ([id_habitacion], [nombre], [descripcion], [maximo_huespedes], [minimo_huespedes], [tamanio]) VALUES (8, N'Balcón Deluxe', N'Mayor superficie a un precio excelente.
Balcón privado con sillas para disfrutar de vistas paseo', 7, 2, 24)
GO
INSERT [dbo].[Habitacion] ([id_habitacion], [nombre], [descripcion], [maximo_huespedes], [minimo_huespedes], [tamanio]) VALUES (9, N'Balcón Fantástica', N'Vistas espectaculares orientadas a la popa
. Balcón privado en la parte trasera del barco.', 4, 1, 22)
GO
INSERT [dbo].[Habitacion] ([id_habitacion], [nombre], [descripcion], [maximo_huespedes], [minimo_huespedes], [tamanio]) VALUES (10, N'Suite Junior', N'Nuestra suite de lujo estándar. 
Balcón privado con dos sillas.
 Disfruta del lujo de una suite sin salirte de tu presupuesto.', 8, 2, 34)
GO
INSERT [dbo].[Habitacion] ([id_habitacion], [nombre], [descripcion], [maximo_huespedes], [minimo_huespedes], [tamanio]) VALUES (11, N'Suite Grand', N'Amplio espacio, que incluye una sala de estar y un baño completo con bañera. 
Balcón privado con asientos. 
La suite "más lujosa" de la flota.', 12, 3, 46)
GO
INSERT [dbo].[Habitacion] ([id_habitacion], [nombre], [descripcion], [maximo_huespedes], [minimo_huespedes], [tamanio]) VALUES (12, N'Suite Aurea', N'La suite de mayor espacio de la flota. Permite mascotas y cenas privadas. Ideal para familias o fiestas entre amigos.', 18, 4, 73)
GO
INSERT [dbo].[Pais] ([id_pais], [nombre]) VALUES (1, N'Brasil')
GO
INSERT [dbo].[Pais] ([id_pais], [nombre]) VALUES (2, N'Cabo Verde')
GO
INSERT [dbo].[Pais] ([id_pais], [nombre]) VALUES (3, N'España')
GO
INSERT [dbo].[Pais] ([id_pais], [nombre]) VALUES (4, N'Portugal')
GO
INSERT [dbo].[Pais] ([id_pais], [nombre]) VALUES (5, N'Marruecos')
GO
INSERT [dbo].[Pais] ([id_pais], [nombre]) VALUES (6, N'Francia')
GO
INSERT [dbo].[Pais] ([id_pais], [nombre]) VALUES (7, N'Holanda')
GO
INSERT [dbo].[Pais] ([id_pais], [nombre]) VALUES (8, N'Alemania')
GO
INSERT [dbo].[Puerto] ([id_puerto], [id_pais], [nombre]) VALUES (1, 1, N'Río de Janeiro')
GO
INSERT [dbo].[Puerto] ([id_puerto], [id_pais], [nombre]) VALUES (2, 1, N'Salvador de Bahía')
GO
INSERT [dbo].[Puerto] ([id_puerto], [id_pais], [nombre]) VALUES (3, 1, N'Maceió')
GO
INSERT [dbo].[Puerto] ([id_puerto], [id_pais], [nombre]) VALUES (4, 1, N'Recife')
GO
INSERT [dbo].[Puerto] ([id_puerto], [id_pais], [nombre]) VALUES (5, 2, N'Praia')
GO
INSERT [dbo].[Puerto] ([id_puerto], [id_pais], [nombre]) VALUES (6, 2, N'Mindelo')
GO
INSERT [dbo].[Puerto] ([id_puerto], [id_pais], [nombre]) VALUES (7, 3, N'Santa Cruz de Tenerife')
GO
INSERT [dbo].[Puerto] ([id_puerto], [id_pais], [nombre]) VALUES (8, 3, N'Las Palmas')
GO
INSERT [dbo].[Puerto] ([id_puerto], [id_pais], [nombre]) VALUES (9, 3, N'Cadiz')
GO
INSERT [dbo].[Puerto] ([id_puerto], [id_pais], [nombre]) VALUES (10, 3, N'Vigo')
GO
INSERT [dbo].[Puerto] ([id_puerto], [id_pais], [nombre]) VALUES (11, 4, N'Lisboa')
GO
INSERT [dbo].[Puerto] ([id_puerto], [id_pais], [nombre]) VALUES (12, 5, N'Casablanca')
GO
INSERT [dbo].[Puerto] ([id_puerto], [id_pais], [nombre]) VALUES (13, 6, N'Le Havre')
GO
INSERT [dbo].[Puerto] ([id_puerto], [id_pais], [nombre]) VALUES (14, 7, N'Rotterdam')
GO
INSERT [dbo].[Puerto] ([id_puerto], [id_pais], [nombre]) VALUES (15, 8, N'Kiel')
GO
INSERT [dbo].[Puerto] ([id_puerto], [id_pais], [nombre]) VALUES (16, 3, N'Barcelona')
GO
ALTER TABLE [dbo].[BarcoHabitacion]  WITH CHECK ADD  CONSTRAINT [FK_CruceroHabitacion_Barco] FOREIGN KEY([id_barco])
REFERENCES [dbo].[Barco] ([id_barco])
GO
ALTER TABLE [dbo].[BarcoHabitacion] CHECK CONSTRAINT [FK_CruceroHabitacion_Barco]
GO
ALTER TABLE [dbo].[BarcoHabitacion]  WITH CHECK ADD  CONSTRAINT [FK_CruceroHabitacion_Habitacion] FOREIGN KEY([id_habitacion])
REFERENCES [dbo].[Habitacion] ([id_habitacion])
GO
ALTER TABLE [dbo].[BarcoHabitacion] CHECK CONSTRAINT [FK_CruceroHabitacion_Habitacion]
GO
ALTER TABLE [dbo].[Calendario]  WITH CHECK ADD  CONSTRAINT [FK_Calendario_Crucero] FOREIGN KEY([id_crucero])
REFERENCES [dbo].[Crucero] ([id_crucero])
GO
ALTER TABLE [dbo].[Calendario] CHECK CONSTRAINT [FK_Calendario_Crucero]
GO
ALTER TABLE [dbo].[CalendarioHabitacion]  WITH CHECK ADD  CONSTRAINT [FK_CalendarioHabitacion_Calendario] FOREIGN KEY([fecha_inicio], [id_crucero])
REFERENCES [dbo].[Calendario] ([fecha_inicio], [id_crucero])
GO
ALTER TABLE [dbo].[CalendarioHabitacion] CHECK CONSTRAINT [FK_CalendarioHabitacion_Calendario]
GO
ALTER TABLE [dbo].[CalendarioHabitacion]  WITH CHECK ADD  CONSTRAINT [FK_CalendarioHabitacion_Habitacion] FOREIGN KEY([id_habitacion])
REFERENCES [dbo].[Habitacion] ([id_habitacion])
GO
ALTER TABLE [dbo].[CalendarioHabitacion] CHECK CONSTRAINT [FK_CalendarioHabitacion_Habitacion]
GO
ALTER TABLE [dbo].[Crucero]  WITH CHECK ADD  CONSTRAINT [FK_Crucero_Barco] FOREIGN KEY([id_barco])
REFERENCES [dbo].[Barco] ([id_barco])
GO
ALTER TABLE [dbo].[Crucero] CHECK CONSTRAINT [FK_Crucero_Barco]
GO
ALTER TABLE [dbo].[CruceroPuerto]  WITH CHECK ADD  CONSTRAINT [FK_CruceroPuerto_Crucero] FOREIGN KEY([id_crucero])
REFERENCES [dbo].[Crucero] ([id_crucero])
GO
ALTER TABLE [dbo].[CruceroPuerto] CHECK CONSTRAINT [FK_CruceroPuerto_Crucero]
GO
ALTER TABLE [dbo].[CruceroPuerto]  WITH CHECK ADD  CONSTRAINT [FK_CruceroPuerto_Puerto] FOREIGN KEY([id_puerto])
REFERENCES [dbo].[Puerto] ([id_puerto])
GO
ALTER TABLE [dbo].[CruceroPuerto] CHECK CONSTRAINT [FK_CruceroPuerto_Puerto]
GO
ALTER TABLE [dbo].[Puerto]  WITH CHECK ADD  CONSTRAINT [FK_Puerto_Pais] FOREIGN KEY([id_pais])
REFERENCES [dbo].[Pais] ([id_pais])
GO
ALTER TABLE [dbo].[Puerto] CHECK CONSTRAINT [FK_Puerto_Pais]
GO
ALTER TABLE [dbo].[ReservaComplemento]  WITH CHECK ADD  CONSTRAINT [FK_ReservaComplemento_Complemento] FOREIGN KEY([id_complemento])
REFERENCES [dbo].[Complemento] ([id_complemento])
GO
ALTER TABLE [dbo].[ReservaComplemento] CHECK CONSTRAINT [FK_ReservaComplemento_Complemento]
GO
ALTER TABLE [dbo].[ReservaComplemento]  WITH CHECK ADD  CONSTRAINT [FK_ReservaComplemento_ReservaEncabezado] FOREIGN KEY([id_reserva])
REFERENCES [dbo].[ReservaEncabezado] ([id_reserva])
GO
ALTER TABLE [dbo].[ReservaComplemento] CHECK CONSTRAINT [FK_ReservaComplemento_ReservaEncabezado]
GO
ALTER TABLE [dbo].[ReservaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ReservaDetalle_Habitacion] FOREIGN KEY([id_habitacion])
REFERENCES [dbo].[Habitacion] ([id_habitacion])
GO
ALTER TABLE [dbo].[ReservaDetalle] CHECK CONSTRAINT [FK_ReservaDetalle_Habitacion]
GO
ALTER TABLE [dbo].[ReservaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ReservaDetalle_Huesped] FOREIGN KEY([id_huesped])
REFERENCES [dbo].[Huesped] ([id_huesped])
GO
ALTER TABLE [dbo].[ReservaDetalle] CHECK CONSTRAINT [FK_ReservaDetalle_Huesped]
GO
ALTER TABLE [dbo].[ReservaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ReservaDetalle_ReservaEncabezado] FOREIGN KEY([id_reserva])
REFERENCES [dbo].[ReservaEncabezado] ([id_reserva])
GO
ALTER TABLE [dbo].[ReservaDetalle] CHECK CONSTRAINT [FK_ReservaDetalle_ReservaEncabezado]
GO
ALTER TABLE [dbo].[ReservaEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_ReservaEncabezado_Calendario] FOREIGN KEY([fecha_inicio], [id_crucero])
REFERENCES [dbo].[Calendario] ([fecha_inicio], [id_crucero])
GO
ALTER TABLE [dbo].[ReservaEncabezado] CHECK CONSTRAINT [FK_ReservaEncabezado_Calendario]
GO
ALTER TABLE [dbo].[ReservaEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_ReservaEncabezado_CuentaCobrar] FOREIGN KEY([id_reserva])
REFERENCES [dbo].[CuentaCobrar] ([id_reserva])
GO
ALTER TABLE [dbo].[ReservaEncabezado] CHECK CONSTRAINT [FK_ReservaEncabezado_CuentaCobrar]
GO
ALTER TABLE [dbo].[ReservaEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_ReservaEncabezado_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[ReservaEncabezado] CHECK CONSTRAINT [FK_ReservaEncabezado_Usuario]
GO
USE [master]
GO
ALTER DATABASE [TesoroAzul] SET  READ_WRITE 
GO
