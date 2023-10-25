
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/25/2023 13:26:14
-- Generated from EDMX file: C:\Users\belac\source\repos\CodigoLimpioEntityFrameWork_EntregaFinal\CodigoLimpioEntityFrameWork\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Coloria];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DepartamentoColor_Color]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DepartamentoColor] DROP CONSTRAINT [FK_DepartamentoColor_Color];
GO
IF OBJECT_ID(N'[dbo].[FK_DepartamentoColor_Departamento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DepartamentoColor] DROP CONSTRAINT [FK_DepartamentoColor_Departamento];
GO
IF OBJECT_ID(N'[dbo].[FK_DesarrolloRegional_Idea]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DesarrolloRegional] DROP CONSTRAINT [FK_DesarrolloRegional_Idea];
GO
IF OBJECT_ID(N'[dbo].[FK_ideaColor_Color]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ideaColor] DROP CONSTRAINT [FK_ideaColor_Color];
GO
IF OBJECT_ID(N'[dbo].[FK_ideaColor_Idea]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ideaColor] DROP CONSTRAINT [FK_ideaColor_Idea];
GO
IF OBJECT_ID(N'[dbo].[FK_ideaHerramienta_Herramienta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ideaHerramienta] DROP CONSTRAINT [FK_ideaHerramienta_Herramienta];
GO
IF OBJECT_ID(N'[dbo].[FK_ideaHerramienta_Idea]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ideaHerramienta] DROP CONSTRAINT [FK_ideaHerramienta_Idea];
GO
IF OBJECT_ID(N'[dbo].[FK_ideaMiembro_Idea]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ideaMiembro] DROP CONSTRAINT [FK_ideaMiembro_Idea];
GO
IF OBJECT_ID(N'[dbo].[FK_ideaMiembro_Miembro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ideaMiembro] DROP CONSTRAINT [FK_ideaMiembro_Miembro];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Color]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Color];
GO
IF OBJECT_ID(N'[dbo].[Departamento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departamento];
GO
IF OBJECT_ID(N'[dbo].[DepartamentoColor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DepartamentoColor];
GO
IF OBJECT_ID(N'[dbo].[DesarrolloRegional]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DesarrolloRegional];
GO
IF OBJECT_ID(N'[dbo].[Herramienta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Herramienta];
GO
IF OBJECT_ID(N'[dbo].[Idea]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Idea];
GO
IF OBJECT_ID(N'[dbo].[ideaColor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ideaColor];
GO
IF OBJECT_ID(N'[dbo].[ideaHerramienta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ideaHerramienta];
GO
IF OBJECT_ID(N'[dbo].[ideaMiembro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ideaMiembro];
GO
IF OBJECT_ID(N'[dbo].[Miembro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Miembro];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Color'
CREATE TABLE [dbo].[Color] (
    [idColor] int IDENTITY(1,1) NOT NULL,
    [nombreColor] varchar(50)  NOT NULL,
    [descripcionColor] varchar(250)  NOT NULL
);
GO

-- Creating table 'Departamento'
CREATE TABLE [dbo].[Departamento] (
    [idDepartamento] int IDENTITY(1,1) NOT NULL,
    [nombreDepartamento] varchar(150)  NULL
);
GO

-- Creating table 'DepartamentoColor'
CREATE TABLE [dbo].[DepartamentoColor] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idDepartamento] int  NOT NULL,
    [idColor] int  NOT NULL
);
GO

-- Creating table 'DesarrolloRegional'
CREATE TABLE [dbo].[DesarrolloRegional] (
    [idDesarrolloRegional] int IDENTITY(1,1) NOT NULL,
    [idIdea] int  NOT NULL
);
GO

-- Creating table 'Herramienta'
CREATE TABLE [dbo].[Herramienta] (
    [idHerramienta] int  NOT NULL,
    [nombreHerramienta] varchar(150)  NOT NULL
);
GO

-- Creating table 'Idea'
CREATE TABLE [dbo].[Idea] (
    [idIdea] int IDENTITY(1,1) NOT NULL,
    [nombreIdea] varchar(50)  NOT NULL,
    [inversionRequerida] float  NOT NULL,
    [ingresosObjetivos] float  NOT NULL,
    [inversionInfraestructura] float  NOT NULL
);
GO

-- Creating table 'ideaColor'
CREATE TABLE [dbo].[ideaColor] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idIdea] int  NOT NULL,
    [idColor] int  NOT NULL
);
GO

-- Creating table 'ideaHerramienta'
CREATE TABLE [dbo].[ideaHerramienta] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idIdea] int  NOT NULL,
    [idHerramienta] int  NOT NULL
);
GO

-- Creating table 'ideaMiembro'
CREATE TABLE [dbo].[ideaMiembro] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idIdea] int  NOT NULL,
    [idMiembro] int  NOT NULL
);
GO

-- Creating table 'Miembro'
CREATE TABLE [dbo].[Miembro] (
    [idMiembro] int IDENTITY(1,1) NOT NULL,
    [nombreMiembro] varchar(150)  NOT NULL,
    [apellidoMiembro] varchar(150)  NOT NULL,
    [cedulaMiembro] varchar(50)  NOT NULL,
    [correoMiembro] varchar(250)  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [idColor] in table 'Color'
ALTER TABLE [dbo].[Color]
ADD CONSTRAINT [PK_Color]
    PRIMARY KEY CLUSTERED ([idColor] ASC);
GO

-- Creating primary key on [idDepartamento] in table 'Departamento'
ALTER TABLE [dbo].[Departamento]
ADD CONSTRAINT [PK_Departamento]
    PRIMARY KEY CLUSTERED ([idDepartamento] ASC);
GO

-- Creating primary key on [id] in table 'DepartamentoColor'
ALTER TABLE [dbo].[DepartamentoColor]
ADD CONSTRAINT [PK_DepartamentoColor]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [idDesarrolloRegional] in table 'DesarrolloRegional'
ALTER TABLE [dbo].[DesarrolloRegional]
ADD CONSTRAINT [PK_DesarrolloRegional]
    PRIMARY KEY CLUSTERED ([idDesarrolloRegional] ASC);
GO

-- Creating primary key on [idHerramienta] in table 'Herramienta'
ALTER TABLE [dbo].[Herramienta]
ADD CONSTRAINT [PK_Herramienta]
    PRIMARY KEY CLUSTERED ([idHerramienta] ASC);
GO

-- Creating primary key on [idIdea] in table 'Idea'
ALTER TABLE [dbo].[Idea]
ADD CONSTRAINT [PK_Idea]
    PRIMARY KEY CLUSTERED ([idIdea] ASC);
GO

-- Creating primary key on [id] in table 'ideaColor'
ALTER TABLE [dbo].[ideaColor]
ADD CONSTRAINT [PK_ideaColor]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ideaHerramienta'
ALTER TABLE [dbo].[ideaHerramienta]
ADD CONSTRAINT [PK_ideaHerramienta]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ideaMiembro'
ALTER TABLE [dbo].[ideaMiembro]
ADD CONSTRAINT [PK_ideaMiembro]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [idMiembro] in table 'Miembro'
ALTER TABLE [dbo].[Miembro]
ADD CONSTRAINT [PK_Miembro]
    PRIMARY KEY CLUSTERED ([idMiembro] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idColor] in table 'DepartamentoColor'
ALTER TABLE [dbo].[DepartamentoColor]
ADD CONSTRAINT [FK_DepartamentoColor_Color]
    FOREIGN KEY ([idColor])
    REFERENCES [dbo].[Color]
        ([idColor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartamentoColor_Color'
CREATE INDEX [IX_FK_DepartamentoColor_Color]
ON [dbo].[DepartamentoColor]
    ([idColor]);
GO

-- Creating foreign key on [idColor] in table 'ideaColor'
ALTER TABLE [dbo].[ideaColor]
ADD CONSTRAINT [FK_ideaColor_Color]
    FOREIGN KEY ([idColor])
    REFERENCES [dbo].[Color]
        ([idColor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ideaColor_Color'
CREATE INDEX [IX_FK_ideaColor_Color]
ON [dbo].[ideaColor]
    ([idColor]);
GO

-- Creating foreign key on [idDepartamento] in table 'DepartamentoColor'
ALTER TABLE [dbo].[DepartamentoColor]
ADD CONSTRAINT [FK_DepartamentoColor_Departamento]
    FOREIGN KEY ([idDepartamento])
    REFERENCES [dbo].[Departamento]
        ([idDepartamento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartamentoColor_Departamento'
CREATE INDEX [IX_FK_DepartamentoColor_Departamento]
ON [dbo].[DepartamentoColor]
    ([idDepartamento]);
GO

-- Creating foreign key on [idIdea] in table 'DesarrolloRegional'
ALTER TABLE [dbo].[DesarrolloRegional]
ADD CONSTRAINT [FK_DesarrolloRegional_Idea]
    FOREIGN KEY ([idIdea])
    REFERENCES [dbo].[Idea]
        ([idIdea])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DesarrolloRegional_Idea'
CREATE INDEX [IX_FK_DesarrolloRegional_Idea]
ON [dbo].[DesarrolloRegional]
    ([idIdea]);
GO

-- Creating foreign key on [idHerramienta] in table 'ideaHerramienta'
ALTER TABLE [dbo].[ideaHerramienta]
ADD CONSTRAINT [FK_ideaHerramienta_Herramienta]
    FOREIGN KEY ([idHerramienta])
    REFERENCES [dbo].[Herramienta]
        ([idHerramienta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ideaHerramienta_Herramienta'
CREATE INDEX [IX_FK_ideaHerramienta_Herramienta]
ON [dbo].[ideaHerramienta]
    ([idHerramienta]);
GO

-- Creating foreign key on [idIdea] in table 'ideaColor'
ALTER TABLE [dbo].[ideaColor]
ADD CONSTRAINT [FK_ideaColor_Idea]
    FOREIGN KEY ([idIdea])
    REFERENCES [dbo].[Idea]
        ([idIdea])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ideaColor_Idea'
CREATE INDEX [IX_FK_ideaColor_Idea]
ON [dbo].[ideaColor]
    ([idIdea]);
GO

-- Creating foreign key on [idIdea] in table 'ideaHerramienta'
ALTER TABLE [dbo].[ideaHerramienta]
ADD CONSTRAINT [FK_ideaHerramienta_Idea]
    FOREIGN KEY ([idIdea])
    REFERENCES [dbo].[Idea]
        ([idIdea])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ideaHerramienta_Idea'
CREATE INDEX [IX_FK_ideaHerramienta_Idea]
ON [dbo].[ideaHerramienta]
    ([idIdea]);
GO

-- Creating foreign key on [idIdea] in table 'ideaMiembro'
ALTER TABLE [dbo].[ideaMiembro]
ADD CONSTRAINT [FK_ideaMiembro_Idea]
    FOREIGN KEY ([idIdea])
    REFERENCES [dbo].[Idea]
        ([idIdea])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ideaMiembro_Idea'
CREATE INDEX [IX_FK_ideaMiembro_Idea]
ON [dbo].[ideaMiembro]
    ([idIdea]);
GO

-- Creating foreign key on [idMiembro] in table 'ideaMiembro'
ALTER TABLE [dbo].[ideaMiembro]
ADD CONSTRAINT [FK_ideaMiembro_Miembro]
    FOREIGN KEY ([idMiembro])
    REFERENCES [dbo].[Miembro]
        ([idMiembro])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ideaMiembro_Miembro'
CREATE INDEX [IX_FK_ideaMiembro_Miembro]
ON [dbo].[ideaMiembro]
    ([idMiembro]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------