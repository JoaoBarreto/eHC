/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     18-05-2013 14:08:06                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Administrativo') and o.name = 'FK_ADMINIST_GENERALIZ_EMPREGAD')
alter table Administrativo
   drop constraint FK_ADMINIST_GENERALIZ_EMPREGAD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Consulta') and o.name = 'FK_CONSULTA_ASSOCIATI_SALA')
alter table Consulta
   drop constraint FK_CONSULTA_ASSOCIATI_SALA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Consulta') and o.name = 'FK_CONSULTA_ASSOCIATI_MEDICO')
alter table Consulta
   drop constraint FK_CONSULTA_ASSOCIATI_MEDICO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Consulta') and o.name = 'FK_CONSULTA_ASSOCIATI_UTENTE')
alter table Consulta
   drop constraint FK_CONSULTA_ASSOCIATI_UTENTE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Diagnostico') and o.name = 'FK_DIAGNOST_ASSOCIATI_CONSULTA')
alter table Diagnostico
   drop constraint FK_DIAGNOST_ASSOCIATI_CONSULTA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Diagnostico') and o.name = 'FK_DIAGNOST_ASSOCIATI_PRESCRIC')
alter table Diagnostico
   drop constraint FK_DIAGNOST_ASSOCIATI_PRESCRIC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DiagnosticoDoenca') and o.name = 'FK_DIAGNOST_DIAGNOSTI_DIAGNOST')
alter table DiagnosticoDoenca
   drop constraint FK_DIAGNOST_DIAGNOSTI_DIAGNOST
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DiagnosticoDoenca') and o.name = 'FK_DIAGNOST_DIAGNOSTI_DOENCA')
alter table DiagnosticoDoenca
   drop constraint FK_DIAGNOST_DIAGNOSTI_DOENCA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EntidadeDeSaudeEmpregado') and o.name = 'FK_ENTIDADE_ENTIDADED_EMPREGAD')
alter table EntidadeDeSaudeEmpregado
   drop constraint FK_ENTIDADE_ENTIDADED_EMPREGAD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EntidadeDeSaudeEmpregado') and o.name = 'FK_ENTIDADE_ENTIDADED_ENTIDADE')
alter table EntidadeDeSaudeEmpregado
   drop constraint FK_ENTIDADE_ENTIDADED_ENTIDADE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Exame') and o.name = 'FK_EXAME_ASSOCIATI_ESPECIAL')
alter table Exame
   drop constraint FK_EXAME_ASSOCIATI_ESPECIAL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Exame') and o.name = 'FK_EXAME_GENERALIZ_ELEMENTO')
alter table Exame
   drop constraint FK_EXAME_GENERALIZ_ELEMENTO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('FichaClinica') and o.name = 'FK_FICHACLI_ASSOCIATI_UTENTE')
alter table FichaClinica
   drop constraint FK_FICHACLI_ASSOCIATI_UTENTE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('FichaClinicaDiagnostico') and o.name = 'FK_FICHACLI_FICHACLIN_DIAGNOST')
alter table FichaClinicaDiagnostico
   drop constraint FK_FICHACLI_FICHACLIN_DIAGNOST
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('FichaClinicaDiagnostico') and o.name = 'FK_FICHACLI_FICHACLIN_FICHACLI')
alter table FichaClinicaDiagnostico
   drop constraint FK_FICHACLI_FICHACLIN_FICHACLI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Medicamento') and o.name = 'FK_MEDICAME_GENERALIZ_ELEMENTO')
alter table Medicamento
   drop constraint FK_MEDICAME_GENERALIZ_ELEMENTO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Medico') and o.name = 'FK_MEDICO_ASSOCIATI_ESPECIAL')
alter table Medico
   drop constraint FK_MEDICO_ASSOCIATI_ESPECIAL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Medico') and o.name = 'FK_MEDICO_GENERALIZ_EMPREGAD')
alter table Medico
   drop constraint FK_MEDICO_GENERALIZ_EMPREGAD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PrescricaoElementosPrescritos') and o.name = 'FK_PRESCRIC_PRESCRICA_ELEMENTO')
alter table PrescricaoElementosPrescritos
   drop constraint FK_PRESCRIC_PRESCRICA_ELEMENTO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PrescricaoElementosPrescritos') and o.name = 'FK_PRESCRIC_PRESCRICA_PRESCRIC')
alter table PrescricaoElementosPrescritos
   drop constraint FK_PRESCRIC_PRESCRICA_PRESCRIC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Sala') and o.name = 'FK_SALA_ASSOCIATI_ENTIDADE')
alter table Sala
   drop constraint FK_SALA_ASSOCIATI_ENTIDADE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Tratamento') and o.name = 'FK_TRATAMEN_GENERALIZ_ELEMENTO')
alter table Tratamento
   drop constraint FK_TRATAMEN_GENERALIZ_ELEMENTO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Utente') and o.name = 'FK_UTENTE_ASSOCIATI_FICHACLI')
alter table Utente
   drop constraint FK_UTENTE_ASSOCIATI_FICHACLI
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Administrativo')
            and   name  = 'GENERALIZATION_2_FK'
            and   indid > 0
            and   indid < 255)
   drop index Administrativo.GENERALIZATION_2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Administrativo')
            and   type = 'U')
   drop table Administrativo
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Consulta')
            and   name  = 'ASSOCIATION5_FK'
            and   indid > 0
            and   indid < 255)
   drop index Consulta.ASSOCIATION5_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Consulta')
            and   type = 'U')
   drop table Consulta
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Diagnostico')
            and   name  = 'ASSOCIATION12_FK'
            and   indid > 0
            and   indid < 255)
   drop index Diagnostico.ASSOCIATION12_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Diagnostico')
            and   type = 'U')
   drop table Diagnostico
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DiagnosticoDoenca')
            and   name  = 'DIAGNOSTICODOENCA_FK'
            and   indid > 0
            and   indid < 255)
   drop index DiagnosticoDoenca.DIAGNOSTICODOENCA_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DiagnosticoDoenca')
            and   type = 'U')
   drop table DiagnosticoDoenca
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Doenca')
            and   type = 'U')
   drop table Doenca
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ElementosPrescritos')
            and   type = 'U')
   drop table ElementosPrescritos
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Empregado')
            and   type = 'U')
   drop table Empregado
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EntidadeDeSaude')
            and   type = 'U')
   drop table EntidadeDeSaude
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('EntidadeDeSaudeEmpregado')
            and   name  = 'ENTIDADEDESAUDEEMPREGADO_FK'
            and   indid > 0
            and   indid < 255)
   drop index EntidadeDeSaudeEmpregado.ENTIDADEDESAUDEEMPREGADO_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EntidadeDeSaudeEmpregado')
            and   type = 'U')
   drop table EntidadeDeSaudeEmpregado
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Especialidade')
            and   type = 'U')
   drop table Especialidade
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Exame')
            and   name  = 'ASSOCIATION14_FK'
            and   indid > 0
            and   indid < 255)
   drop index Exame.ASSOCIATION14_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Exame')
            and   type = 'U')
   drop table Exame
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('FichaClinica')
            and   name  = 'ASSOCIATION13_FK'
            and   indid > 0
            and   indid < 255)
   drop index FichaClinica.ASSOCIATION13_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FichaClinica')
            and   type = 'U')
   drop table FichaClinica
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('FichaClinicaDiagnostico')
            and   name  = 'FICHACLINICADIAGNOSTICO_FK'
            and   indid > 0
            and   indid < 255)
   drop index FichaClinicaDiagnostico.FICHACLINICADIAGNOSTICO_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FichaClinicaDiagnostico')
            and   type = 'U')
   drop table FichaClinicaDiagnostico
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Medicamento')
            and   name  = 'GENERALIZATION_4_FK'
            and   indid > 0
            and   indid < 255)
   drop index Medicamento.GENERALIZATION_4_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Medicamento')
            and   type = 'U')
   drop table Medicamento
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Medico')
            and   name  = 'ASSOCIATION3_FK'
            and   indid > 0
            and   indid < 255)
   drop index Medico.ASSOCIATION3_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Medico')
            and   type = 'U')
   drop table Medico
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Prescricao')
            and   type = 'U')
   drop table Prescricao
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PrescricaoElementosPrescritos')
            and   name  = 'PRESCRICAOELEMENTOSPRESCRITOS_FK'
            and   indid > 0
            and   indid < 255)
   drop index PrescricaoElementosPrescritos.PRESCRICAOELEMENTOSPRESCRITOS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PrescricaoElementosPrescritos')
            and   type = 'U')
   drop table PrescricaoElementosPrescritos
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Sala')
            and   name  = 'ASSOCIATION1_FK'
            and   indid > 0
            and   indid < 255)
   drop index Sala.ASSOCIATION1_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Sala')
            and   type = 'U')
   drop table Sala
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Tratamento')
            and   name  = 'GENERALIZATION_3_FK'
            and   indid > 0
            and   indid < 255)
   drop index Tratamento.GENERALIZATION_3_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Tratamento')
            and   type = 'U')
   drop table Tratamento
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Utente')
            and   name  = 'ASSOCIATION13_FK'
            and   indid > 0
            and   indid < 255)
   drop index Utente.ASSOCIATION13_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Utente')
            and   type = 'U')
   drop table Utente
go

/*==============================================================*/
/* Table: Administrativo                                        */
/*==============================================================*/
create table Administrativo (
   IdEmpregado          int                  not null,
   constraint PK_ADMINISTRATIVO primary key (IdEmpregado)
)
go

/*==============================================================*/
/* Index: GENERALIZATION_2_FK                                   */
/*==============================================================*/
create index GENERALIZATION_2_FK on Administrativo (
IdEmpregado ASC
)
go

/*==============================================================*/
/* Table: Consulta                                              */
/*==============================================================*/
create table Consulta (
   IdConsulta           int                  not null,
   IdUtente             int                  null,
   IdSala               int                  null,
   IdEmpregado          int                  null,
   Estado               int                  null,
   Observacoes          varchar(254)         null,
   Data                 datetime             null,
   constraint PK_CONSULTA primary key (IdConsulta)
)
go

/*==============================================================*/
/* Index: ASSOCIATION5_FK                                       */
/*==============================================================*/
create index ASSOCIATION5_FK on Consulta (
IdSala ASC
)
go

/*==============================================================*/
/* Table: Diagnostico                                           */
/*==============================================================*/
create table Diagnostico (
   IdDiagnostico        int                  not null,
   IdConsulta           int                  not null,
   IdPrescricao         int                  not null,
   Diagnostico          varchar(254)         null,
   constraint PK_DIAGNOSTICO primary key (IdDiagnostico)
)
go

/*==============================================================*/
/* Index: ASSOCIATION12_FK                                      */
/*==============================================================*/
create index ASSOCIATION12_FK on Diagnostico (
IdConsulta ASC
)
go

/*==============================================================*/
/* Table: DiagnosticoDoenca                                     */
/*==============================================================*/
create table DiagnosticoDoenca (
   IdDiagnostico        int                  not null,
   IdDoenca             int                  not null,
   constraint PK_DIAGNOSTICODOENCA primary key (IdDiagnostico, IdDoenca)
)
go

/*==============================================================*/
/* Index: DIAGNOSTICODOENCA_FK                                  */
/*==============================================================*/
create index DIAGNOSTICODOENCA_FK on DiagnosticoDoenca (
IdDoenca ASC
)
go

/*==============================================================*/
/* Table: Doenca                                                */
/*==============================================================*/
create table Doenca (
   IdDoenca             int                  not null,
   Descricao            varchar(254)         null,
   Sintomas             varchar(254)         null,
   constraint PK_DOENCA primary key (IdDoenca)
)
go

/*==============================================================*/
/* Table: ElementosPrescritos                                   */
/*==============================================================*/
create table ElementosPrescritos (
   IdElemento           int                  not null,
   Nome                 varchar(254)         null,
   constraint PK_ELEMENTOSPRESCRITOS primary key (IdElemento)
)
go

/*==============================================================*/
/* Table: Empregado                                             */
/*==============================================================*/
create table Empregado (
   IdEmpregado          int                  not null,
   Nome                 varchar(254)         null,
   Morada               varchar(254)         null,
   Telefone             int                  null,
   Email                varchar(254)         null,
   constraint PK_EMPREGADO primary key (IdEmpregado)
)
go

/*==============================================================*/
/* Table: EntidadeDeSaude                                       */
/*==============================================================*/
create table EntidadeDeSaude (
   IdEntidadeDeSaude    int                  not null,
   Nome                 varchar(254)         null,
   Morada               varchar(254)         null,
   Nif                  int                  null,
   Email                varchar(254)         null,
   constraint PK_ENTIDADEDESAUDE primary key (IdEntidadeDeSaude)
)
go

/*==============================================================*/
/* Table: EntidadeDeSaudeEmpregado                              */
/*==============================================================*/
create table EntidadeDeSaudeEmpregado (
   IdEmpregado          int                  not null,
   IdEntidadeDeSaude    int                  null,
   constraint PK_ENTIDADEDESAUDEEMPREGADO primary key (IdEmpregado)
)
go

/*==============================================================*/
/* Index: ENTIDADEDESAUDEEMPREGADO_FK                           */
/*==============================================================*/
create index ENTIDADEDESAUDEEMPREGADO_FK on EntidadeDeSaudeEmpregado (
IdEmpregado ASC
)
go

/*==============================================================*/
/* Table: Especialidade                                         */
/*==============================================================*/
create table Especialidade (
   IdEspecialidade      int                  not null,
   Especialidade        varchar(254)         null,
   constraint PK_ESPECIALIDADE primary key (IdEspecialidade)
)
go

/*==============================================================*/
/* Table: Exame                                                 */
/*==============================================================*/
create table Exame (
   IdElemento           int                  not null,
   IdEspecialidade      int                  not null,
   constraint PK_EXAME primary key (IdElemento)
)
go

/*==============================================================*/
/* Index: ASSOCIATION14_FK                                      */
/*==============================================================*/
create index ASSOCIATION14_FK on Exame (
IdEspecialidade ASC
)
go

/*==============================================================*/
/* Table: FichaClinica                                          */
/*==============================================================*/
create table FichaClinica (
   IdFichaClinica       int                  not null,
   IdUtente             int                  not null,
   constraint PK_FICHACLINICA primary key (IdFichaClinica)
)
go

/*==============================================================*/
/* Index: ASSOCIATION13_FK                                      */
/*==============================================================*/
create index ASSOCIATION13_FK on FichaClinica (
IdUtente ASC
)
go

/*==============================================================*/
/* Table: FichaClinicaDiagnostico                               */
/*==============================================================*/
create table FichaClinicaDiagnostico (
   IdFichaClinica       int                  not null,
   IdDiagnostico        int                  not null,
   constraint PK_FICHACLINICADIAGNOSTICO primary key (IdDiagnostico, IdFichaClinica)
)
go

/*==============================================================*/
/* Index: FICHACLINICADIAGNOSTICO_FK                            */
/*==============================================================*/
create index FICHACLINICADIAGNOSTICO_FK on FichaClinicaDiagnostico (
IdDiagnostico ASC
)
go

/*==============================================================*/
/* Table: Medicamento                                           */
/*==============================================================*/
create table Medicamento (
   IdElemento           int                  not null,
   Posologia            varchar(254)         null,
   constraint PK_MEDICAMENTO primary key (IdElemento)
)
go

/*==============================================================*/
/* Index: GENERALIZATION_4_FK                                   */
/*==============================================================*/
create index GENERALIZATION_4_FK on Medicamento (
IdElemento ASC
)
go

/*==============================================================*/
/* Table: Medico                                                */
/*==============================================================*/
create table Medico (
   IdEmpregado          int                  not null,
   IdEspecialidade      int                  null,
   constraint PK_MEDICO primary key (IdEmpregado)
)
go

/*==============================================================*/
/* Index: ASSOCIATION3_FK                                       */
/*==============================================================*/
create index ASSOCIATION3_FK on Medico (
IdEspecialidade ASC
)
go

/*==============================================================*/
/* Table: Prescricao                                            */
/*==============================================================*/
create table Prescricao (
   IdPrescricao         int                  not null,
   constraint PK_PRESCRICAO primary key (IdPrescricao)
)
go

/*==============================================================*/
/* Table: PrescricaoElementosPrescritos                         */
/*==============================================================*/
create table PrescricaoElementosPrescritos (
   IdElemento           int                  not null,
   IdPrescricao         int                  not null,
   Quantidade           int                  null,
   constraint PK_PRESCRICAOELEMENTOSPRESCRIT primary key (IdElemento, IdPrescricao)
)
go

/*==============================================================*/
/* Index: PRESCRICAOELEMENTOSPRESCRITOS_FK                      */
/*==============================================================*/
create index PRESCRICAOELEMENTOSPRESCRITOS_FK on PrescricaoElementosPrescritos (
IdElemento ASC
)
go

/*==============================================================*/
/* Table: Sala                                                  */
/*==============================================================*/
create table Sala (
   IdEntidadeDeSaude    int                  null,
   IdSala               int                  not null,
   Designacao           varchar(254)         null,
   constraint PK_SALA primary key (IdSala)
)
go

/*==============================================================*/
/* Index: ASSOCIATION1_FK                                       */
/*==============================================================*/
create index ASSOCIATION1_FK on Sala (
IdEntidadeDeSaude ASC
)
go

/*==============================================================*/
/* Table: Tratamento                                            */
/*==============================================================*/
create table Tratamento (
   IdElemento           int                  not null,
   Descricao            varchar(254)         null,
   constraint PK_TRATAMENTO primary key (IdElemento)
)
go

/*==============================================================*/
/* Index: GENERALIZATION_3_FK                                   */
/*==============================================================*/
create index GENERALIZATION_3_FK on Tratamento (
IdElemento ASC
)
go

/*==============================================================*/
/* Table: Utente                                                */
/*==============================================================*/
create table Utente (
   IdUtente             int                  not null,
   IdFichaClinica       int                  null,
   Nome                 varchar(254)         null,
   Morada               varchar(254)         null,
   Telefone             int                  null,
   Email                varchar(254)         null,
   DataNascimento       datetime             null,
   CodigoPostal         varchar(254)         null,
   Fotografia           varchar(254)         null,
   constraint PK_UTENTE primary key (IdUtente)
)
go

/*==============================================================*/
/* Index: ASSOCIATION13_FK                                      */
/*==============================================================*/
create index ASSOCIATION13_FK on Utente (
IdFichaClinica ASC
)
go

alter table Administrativo
   add constraint FK_ADMINIST_GENERALIZ_EMPREGAD foreign key (IdEmpregado)
      references Empregado (IdEmpregado)
go

alter table Consulta
   add constraint FK_CONSULTA_ASSOCIATI_SALA foreign key (IdSala)
      references Sala (IdSala)
go

alter table Consulta
   add constraint FK_CONSULTA_ASSOCIATI_MEDICO foreign key (IdEmpregado)
      references Medico (IdEmpregado)
go

alter table Consulta
   add constraint FK_CONSULTA_ASSOCIATI_UTENTE foreign key (IdUtente)
      references Utente (IdUtente)
go

alter table Diagnostico
   add constraint FK_DIAGNOST_ASSOCIATI_CONSULTA foreign key (IdConsulta)
      references Consulta (IdConsulta)
go

alter table Diagnostico
   add constraint FK_DIAGNOST_ASSOCIATI_PRESCRIC foreign key (IdPrescricao)
      references Prescricao (IdPrescricao)
go

alter table DiagnosticoDoenca
   add constraint FK_DIAGNOST_DIAGNOSTI_DIAGNOST foreign key (IdDiagnostico)
      references Diagnostico (IdDiagnostico)
go

alter table DiagnosticoDoenca
   add constraint FK_DIAGNOST_DIAGNOSTI_DOENCA foreign key (IdDoenca)
      references Doenca (IdDoenca)
go

alter table EntidadeDeSaudeEmpregado
   add constraint FK_ENTIDADE_ENTIDADED_EMPREGAD foreign key (IdEmpregado)
      references Empregado (IdEmpregado)
go

alter table EntidadeDeSaudeEmpregado
   add constraint FK_ENTIDADE_ENTIDADED_ENTIDADE foreign key (IdEntidadeDeSaude)
      references EntidadeDeSaude (IdEntidadeDeSaude)
go

alter table Exame
   add constraint FK_EXAME_ASSOCIATI_ESPECIAL foreign key (IdEspecialidade)
      references Especialidade (IdEspecialidade)
go

alter table Exame
   add constraint FK_EXAME_GENERALIZ_ELEMENTO foreign key (IdElemento)
      references ElementosPrescritos (IdElemento)
go

alter table FichaClinica
   add constraint FK_FICHACLI_ASSOCIATI_UTENTE foreign key (IdUtente)
      references Utente (IdUtente)
go

alter table FichaClinicaDiagnostico
   add constraint FK_FICHACLI_FICHACLIN_DIAGNOST foreign key (IdDiagnostico)
      references Diagnostico (IdDiagnostico)
go

alter table FichaClinicaDiagnostico
   add constraint FK_FICHACLI_FICHACLIN_FICHACLI foreign key (IdFichaClinica)
      references FichaClinica (IdFichaClinica)
go

alter table Medicamento
   add constraint FK_MEDICAME_GENERALIZ_ELEMENTO foreign key (IdElemento)
      references ElementosPrescritos (IdElemento)
go

alter table Medico
   add constraint FK_MEDICO_ASSOCIATI_ESPECIAL foreign key (IdEspecialidade)
      references Especialidade (IdEspecialidade)
go

alter table Medico
   add constraint FK_MEDICO_GENERALIZ_EMPREGAD foreign key (IdEmpregado)
      references Empregado (IdEmpregado)
go

alter table PrescricaoElementosPrescritos
   add constraint FK_PRESCRIC_PRESCRICA_ELEMENTO foreign key (IdElemento)
      references ElementosPrescritos (IdElemento)
go

alter table PrescricaoElementosPrescritos
   add constraint FK_PRESCRIC_PRESCRICA_PRESCRIC foreign key (IdPrescricao)
      references Prescricao (IdPrescricao)
go

alter table Sala
   add constraint FK_SALA_ASSOCIATI_ENTIDADE foreign key (IdEntidadeDeSaude)
      references EntidadeDeSaude (IdEntidadeDeSaude)
go

alter table Tratamento
   add constraint FK_TRATAMEN_GENERALIZ_ELEMENTO foreign key (IdElemento)
      references ElementosPrescritos (IdElemento)
go

alter table Utente
   add constraint FK_UTENTE_ASSOCIATI_FICHACLI foreign key (IdFichaClinica)
      references FichaClinica (IdFichaClinica)
go

INSERT INTO EntidadeDeSaude			VALUES (1, 'Hospital de Santa Maria', 'Lisboa', 501555777, 'hsm@hsm.pt');
/*---------- ESPECIALIDADES MEDICAS ----------*/
INSERT INTO Especialidade			VALUES (1, 'Radiologia');
INSERT INTO Especialidade			VALUES (2, 'Cardiologia');
INSERT INTO Especialidade			VALUES (3, 'Cirurgia');
INSERT INTO Especialidade			VALUES (4, 'Reumatologia');
INSERT INTO Especialidade			VALUES (5, 'Dermatologia');
INSERT INTO Especialidade			VALUES (6, 'Gastroenterologiaa');
/*---------- ESPECIALIDADES MEDICAS ----------*/

INSERT INTO Sala 					VALUES (1,1,'OS1');
INSERT INTO Sala 					VALUES (1,2,'LABa3');
INSERT INTO Sala 					VALUES (1,3,'C300');
INSERT INTO Sala 					VALUES (1,4,'C001');
INSERT INTO Sala 					VALUES (1,5,'EX21');

/*---------- UTENTES ----------*/
INSERT INTO Utente 					VALUES (1,NULL,'Maria Silva', 'Rua do Ouro, Lote 2', 214586678, 'mariadores@gmail.com', NULL, '1245-752', '../imagensUtentes/fotoUtente1.jpg');
INSERT INTO FichaClinica 			VALUES (1,1);
UPDATE Utente SET idFichaClinica=1 WHERE idUtente = 1;

INSERT INTO Utente 					VALUES (2,NULL,'Ricardo Amorim', 'Av. das Aguas, 32-D', 213657745, 'ramorim@mail.pt', NULL, '2455-658', '../imagensUtentes/fotoUtente2.jpg');
INSERT INTO FichaClinica 			VALUES (2,2);
UPDATE Utente SET idFichaClinica=2 WHERE idUtente = 2;

INSERT INTO Utente 					VALUES (3,NULL,'Antonio Virgulino', 'Praceta da Prata, L58-G', 916874455, 'antonio.virgulino@sapo.pt', NULL, '3254-587', '../imagensUtentes/fotoUtente3.jpg');
INSERT INTO FichaClinica 			VALUES (3,3);
UPDATE Utente SET idFichaClinica=3 WHERE idUtente = 3;
/*---------- UTENTES ----------*/

/*---------- MEDICOS ----------*/
INSERT INTO Empregado 				VALUES (1,'Dra. Raquel Bastinhas', 'Rua do Liceu', 219573698, 'raquel.bastinhas@hsm.pt');
INSERT INTO Medico 					VALUES (1,2);
INSERT INTO Empregado 				VALUES (2,'Dr. Artur Kaspersky', 'Av. Raul Rogerio, Lote 3', 935478452, 'artur.kaspersky@hsm.pt');
INSERT INTO Medico 					VALUES (2,4);
INSERT INTO Empregado 				VALUES (3,'Dra. Fatima Silva', 'Largo dos Pombos, Lote 342, 7 D', 965487422, 'fatima.silva@hsm.pt');
INSERT INTO Medico 					VALUES (3,5);
/*---------- MEDICOS ----------*/

/*---------- MEDICOS ----------*/
INSERT INTO Consulta 				VALUES (1,1,1,1,4, ' ', '2013-05-24');
INSERT INTO Consulta 				VALUES (2,2,3,2,2, ' ', '2013-05-24');
INSERT INTO Consulta 				VALUES (3,2,3,2,2, ' ', '2013-05-25');
INSERT INTO Consulta 				VALUES (4,3,5,1,2, ' ', '2013-07-26');
INSERT INTO Consulta 				VALUES (5,1,1,3,2, ' ', '2013-07-24');
/*---------- MEDICOS ----------*/

/*---------- DOENCAS ----------*/
INSERT INTO Doenca 					VALUES (1, 'Anemia', 'Cansaco, fraqueza e indisposicao');
INSERT INTO Doenca 					VALUES (2, 'Artrite psoriatica', 'Rigidez matinal nas articulacoes');
INSERT INTO Doenca 					VALUES (3, 'Sindrome de Sjogren', 'Secura da boca (xerostomia) e dos olhos');
INSERT INTO Doenca 					VALUES (4, 'Esclerose multipla', 'Perda de sensibilidade tactil ou formigueiro, parestesia, fadiga muscular, clonus, espasmos musculares ou dificuldades locomotoras');
INSERT INTO Doenca 					VALUES (5, 'Sindrome de Tourette', 'Desordem neurologica ou neuroquimica caracterizada por tiques, reacoes rapidas, movimentos repentinos (espasmos) ou vocalizacoes que ocorre repetidamente da mesma maneira com considerável frequencia');
INSERT INTO Doenca 					VALUES (6, 'Hipotiroidismo', 'Fadiga, sonolencia, lentidao muscular, aumento do peso corporal, diminuicao da frequencia cardíaca e mixedema');
INSERT INTO Doenca 					VALUES (7, 'Hiperparatiroidismo', 'Doenca caracterizada pelo excessivo funcionamento das glandulas paratiroides');
/*---------- DOENCAS ----------*/

INSERT INTO ElementosPrescritos 	VALUES (1,'Aspegic');
INSERT INTO Exame 					VALUES (1, 1);
INSERT INTO Medicamento 			VALUES (1, '1 vez por dia');
INSERT INTO Prescricao 				VALUES (1);

INSERT INTO Tratamento 				VALUES (1, 'Radioiodoterapia');

INSERT INTO Diagnostico 			VALUES (1, 1, 1,'Diagnostico de teste');

INSERT INTO DiagnosticoDoenca		 VALUES (1, 1);
INSERT INTO EntidadeDeSaudeEmpregado VALUES (1, 1);
INSERT INTO FichaClinicaDiagnostico  VALUES (1, 1);
INSERT INTO PrescricaoElementosPrescritos VALUES (1, 1, 1);