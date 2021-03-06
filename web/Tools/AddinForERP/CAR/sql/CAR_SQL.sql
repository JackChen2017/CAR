drop proc PROC_CAR_GetSerialNo
drop procedure [dbo].[UP_CAR_Table_SAList_ADD]
drop table [CAR_Table_Data01]
drop table [CAR_Table_LOG]
drop table [CAR_Table_SAList]
drop view  [View_CAR_Base]
drop PROCEDURE Proc_CAR_InsertCARData01
drop PROCEDURE Proc_CAR_UpdateCARData01
drop PROCEDURE Proc_CAR_DelCARData01
drop PROCEDURE Proc_CAR_InsertCARLog
drop PROCEDURE Proc_CAR_UpdateCARLog
drop PROCEDURE Proc_CAR_DelCARLog

GO
create table [CAR_Table_SAList]
(
	rkey int identity(1,1) primary key,
	sn_ptr int not null,
	custCode varchar(10),
	custName varchar(80),
	recordDateTime datetime not null,
	founderMaterilNo varchar(30),
	custPartNo varchar(50),
	cycleValue varchar(10),
	happenAddress varchar(50),
	LOT varchar(20),
	ET varchar(20),
	T varchar(20),
	reason varchar(50),
	mateialType varchar(10),
	results varchar(10),
	quantity float,
	signDate datetime,
	signingPerson varchar(20),
	factoryName varchar(10),
	discountPrice float,
	discountAmount float
)

GO
CREATE TABLE [dbo].[CAR_Table_Data01](
	[rkey] [int] IDENTITY(1,1) NOT NULL primary key,
	[Serial_No] [varchar](15) COLLATE Chinese_PRC_CI_AS NULL,
	[FactoryID] [decimal](2, 0) NULL,
	[FactoryName] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[FactoryType] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[CustName] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[CustType] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Fahuo_Quan] [decimal](18, 0) NULL,
	[JianCha_Quan] [decimal](18, 0) NULL,
	[badness_bi] [decimal](5, 2) NULL,
	[badness_DC] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[zaixian_quan] [decimal](18, 0) NULL,
	[kuchun_quan] [decimal](18, 0) NULL,
	[tuihuo_status] [int] NULL,
	[tuihuo_quan] [decimal](18, 0) NULL,
	[kuhuhappen_address] [decimal](2, 0) NULL,
	[tijiao_status] [decimal](2, 0) NULL,
	[tijiao_type] [decimal](2, 0) NULL,
	[DC_quan] [decimal](18, 0) NULL,
	[zaitu_status] [decimal](2, 0) NULL,
	[zaitu_quan] [decimal](18, 0) NULL,
	[chuli_status] [decimal](1, 0) NULL,
	[changleikuchun_status] [decimal](1, 0) NULL,
	[chuli_type] [decimal](2, 0) NULL,
	[Happen_Date] [datetime] NOT NULL,
	[Required_Date] [datetime] NULL,
	[CONF_Date] [datetime] NULL,
	[Issued_Date] [datetime] NULL,
	[From_Comp] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[CAR_Comp] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Issued_User] [varchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[Issued_APP] [varchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[Issued_MG] [varchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[Received_User] [varchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[HSF_Happen_Type] [varchar](30) COLLATE Chinese_PRC_CI_AS NULL,
	[CAR_Part_Num] [varchar](30) COLLATE Chinese_PRC_CI_AS NULL,
	[CAR_Content] [varchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[LOT] [varchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[batch] [float] NULL,
	[sample] [float] NULL,
	[badness_Num] [float] NULL,
	[ReWork] [float] NULL,
	[Reject] [float] NULL,
	[NoWork] [float] NULL,
	[Info_Type_1] [int] NULL,
	[Info_Type_2] [int] NULL,
	[Info_Type_3] [int] NULL,
	[Info_Type_4] [int] NULL,
	[Info_Type_5] [int] NULL,
	[Info_Content] [varchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[Interim_Action] [varchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[IA_Date] [datetime] NULL,
	[Corrective_Action] [varchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[CA_Date] [datetime] NULL,
	[IPCA] [varchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[IPCA_Date] [datetime] NULL,
	[ATPR] [varchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[ATPR_Date] [datetime] NULL,
	[Z_User] [varchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[Z_APP] [varchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[Z_MG] [varchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[Levels] [varchar](200) COLLATE Chinese_PRC_CI_AS NULL,
	[Together_Write] [varchar](200) COLLATE Chinese_PRC_CI_AS NULL,
	[SOP_Status] [int] NULL CONSTRAINT [DF_CAR_Table_Data01_SOP_Status]  DEFAULT ((0)),
	[SOP_Name] [varchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[SOP_Content] [varchar](200) COLLATE Chinese_PRC_CI_AS NULL,
	[SOP_User] [varchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[SOP_Date] [datetime] NULL,
	[CONF_Status] [int] NULL,
	[CONF_Content] [varchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[Pre_Date] [datetime] NULL,
	[END_Date] [datetime] NULL,
	[CONF_User] [varchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[CONF_User_Date] [datetime] NULL,
	[CONF_APP] [varchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[CONF_APP_Date] [datetime] NULL,
	[CONF_MG] [varchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[CONF_MG_Date] [datetime] NULL,
	[COMP_MG] [varchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[Other_Together_Write] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[OP_Type] [int] NULL,
	[Status] [int] NULL,
	[NowUser] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ReqReplyDate] [datetime] NULL,
	[Happen_Address] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[CycleValue] [varchar](30) COLLATE Chinese_PRC_CI_AS NULL,
	[ReceiveDate] [datetime] NULL,
	[ReceiveUser] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ReqSolution] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ReqTimeLimit] [varchar](30) COLLATE Chinese_PRC_CI_AS NULL,
	[ShadinessQty] [float] NULL,
	[IA_APP] [varchar](30) COLLATE Chinese_PRC_CI_AS NULL,
	[IA_User] [varchar](30) COLLATE Chinese_PRC_CI_AS NULL,
	[IPCA_APP] [varchar](30) COLLATE Chinese_PRC_CI_AS NULL,
	[IPCA_User] [varchar](30) COLLATE Chinese_PRC_CI_AS NULL,
	[Info_Date] [datetime] NULL
) 


go
CREATE TABLE [dbo].[CAR_Table_LOG](
	[rkey] [int] IDENTITY(1,1) NOT NULL primary key,
	[SN_PTR] [int] NULL,
	[SN_type] varchar(10),
	[SP_Total_Step] [int] NULL,
	[SP_Start_Date] [datetime] NULL,
	[SP_End_Date] [datetime] NULL,
	[SP_Type] [int] NULL,
	[SP_Step] [int] NULL,
	[SP_User] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[SP_Content] [varchar](200) COLLATE Chinese_PRC_CI_AS NULL,
	[Status] [int] NULL
)

go
CREATE VIEW [dbo].[View_CAR_Base]
AS
SELECT     rkey AS 流水号, Serial_No AS 编号, CONVERT(varchar(20), Happen_Date, 23) AS 发出日期, CONVERT(varchar(20), Required_Date, 23) 
                      AS 要求回复日期, CONVERT(varchar(20), CONF_Date, 23) AS 回复日期, From_Comp AS 发出单位, CAR_Comp AS 异常单位, Issued_User AS 报告者, 
                      Received_User AS 签收者, CASE WHEN (OP_Type = 1) THEN '8D' WHEN (OP_Type = 2) THEN '异常处理' WHEN (OP_Type = 3) 
                      THEN '异常矫正' END AS 类型, CASE WHEN (status = 0) THEN '未审批' WHEN (status = 1) THEN '审批通过' WHEN (status = 2) 
                      THEN '发出单位审批中' WHEN (status = 5) THEN '管理员编码阶段' WHEN (status = 6) THEN '责任部门审批阶段' WHEN (status = 9) 
                      THEN '水平展开' WHEN (status = 10) THEN '品质确认阶段' WHEN (status = 13) THEN '厂长确认阶段' END AS 状态, NowUser AS 当前操作人
FROM         dbo.CAR_Table_Data01

GO

CREATE Procedure [dbo].[Proc_CAR_InsertCARData01]
@RKEY                              int output,
@Serial_No                        varchar(15)=null,
@FactoryID decimal(2,0)=null,
@FactoryName varchar(50)=null,
@FactoryType varchar(50)=null,
@CustName varchar(50)=null,
@CustType varchar(50)=null,
@Fahuo_Quan decimal(18,0)=null,
@JianCha_Quan decimal(18,0)=null,
@badness_bi decimal(7,2)=null,
@badness_DC varchar(50)=null,
@zaixian_quan decimal(18,0)=null,
@kuchun_quan decimal(18,0)=null,
@tuihuo_status int=null,
@tuihuo_quan decimal(18,0)=null,
@kuhuhappen_address decimal(2,0)=null,
@tijiao_status decimal(2,0)=null,
@tijiao_type decimal(2,0)=null,
@DC_quan decimal(18,0)=null,
@zaitu_status decimal(2,0)=null,
@zaitu_quan decimal(18,0)=null,
@chuli_status decimal(1,0)=null,
@changleikuchun_status decimal(1,0)=null,
@chuli_type decimal(2,0)=null,
@Happen_Date                    datetime =null   ,
@Required_Date                     datetime=null ,
@CONF_Date                         datetime=null ,
@Issued_Date                       datetime=null ,
@From_Comp                         varchar(50)=null,
@CAR_Comp                          varchar(50)=null,
@Issued_User                       varchar(20)=null,
@Issued_APP                        varchar(20)=null,
@Issued_MG                         varchar(20)=null,
@Received_User                     varchar(20)=null,
@HSF_Happen_Type                   varchar(30)=null,
@CAR_Part_Num                      varchar(30)=null,
@CAR_Content                       varchar(max)=null,
@LOT                               varchar(30)=null,
@batch                             float=null,
@sample                            float=null ,
@badness_Num                       float=null ,
@ReWork                            float =null,
@Reject                            float=null ,
@NoWork                            float =null,
@Info_Type_1                       int =null,
@Info_Type_2                       int =null,
@Info_Type_3                       int =null,
@Info_Type_4                       int=null ,
@Info_Type_5                       int=null ,
@Info_Content                      varchar(max)=null,
@Interim_Action                    varchar(max)=null,
@IA_Date                           datetime =null,
@Corrective_Action                 varchar(max)=null,
@CA_Date                           datetime =null,
@IPCA                              varchar(max)=null,
@IPCA_Date                         datetime=null ,
@ATPR                              varchar(max)=null,
@ATPR_Date                         datetime=null ,
@Z_User                            varchar(20)=null,
@Z_APP                             varchar(20)=null,
@Z_MG                              varchar(20)=null,
@Levels                            varchar(200)=null,
@Together_Write                    varchar(200)=null,
@SOP_Status                        int =null,
@SOP_Name                          varchar(20)=null,
@SOP_Content                       varchar(200)=null,
@SOP_User                          varchar(20)=null,
@SOP_Date                          datetime =null,
@CONF_Status                       int =null,
@CONF_Content                      varchar(max)=null,
@Pre_Date                          datetime =null,
@END_Date                          datetime =null,
@CONF_User                         varchar(20)=null,
@CONF_User_Date                    datetime =null,
@CONF_APP                          varchar(20)=null,
@CONF_APP_Date                     datetime=null ,
@CONF_MG                           varchar(20)=null,
@CONF_MG_Date                      datetime=null ,
@COMP_MG                           varchar(20)=null,
@Other_Together_Write              varchar(50)=null,
@OP_Type                           int =null,
@Status                            int =null,
@NowUser                           varchar(50) =null,
@ReqReplyDate                   datetime= NULL,
@Happen_Address               varchar(50)=NULL,
@CycleValue                   varchar(50)= NULL,
@ReceiveDate                   datetime =NULL,
@ReceiveUser                 varchar(50)= NULL,
@ReqSolution                varchar(50)= NULL,
@ReqTimeLimit                varchar(30)= NULL,
@ShadinessQty               float= NULL,
@IA_APP                            varchar(30)= NULL,
@IA_USER                           varchar(30)= NULL,
@IPCA_APP                            varchar(30)= NULL,
@IPCA_USER                            varchar(30)= NULL,
@Info_Date                            datetime= NULL,
@returnID int output

AS
--- 开始数据库操作事务
begin tran t1

INSERT INTO CAR_Table_Data01
(
Serial_No,
[FactoryID],
[FactoryName],
[FactoryType],
[CustName],
[CustType],
[Fahuo_Quan],
[JianCha_Quan],
[badness_bi],
[badness_DC],
[zaixian_quan],
[kuchun_quan],
[tuihuo_status],
[tuihuo_quan],
[kuhuhappen_address],
[tijiao_status],
[tijiao_type],
[DC_quan],
[zaitu_status],
[zaitu_quan],
[chuli_status],
[changleikuchun_status],
[chuli_type],
Happen_Date,
Required_Date,
CONF_Date,
Issued_Date,
From_Comp,
CAR_Comp,
Issued_User,
Issued_APP,
Issued_MG,
Received_User,
HSF_Happen_Type,
CAR_Part_Num,
CAR_Content,
LOT,
batch,
sample,
badness_Num,
ReWork,
Reject,
NoWork,
Info_Type_1,
Info_Type_2,
Info_Type_3,
Info_Type_4,
Info_Type_5,
Info_Content,
Interim_Action,
IA_Date,
Corrective_Action,
CA_Date,
IPCA,
IPCA_Date,
ATPR,
ATPR_Date,
Z_User,
Z_APP,
Z_MG,
Levels,
Together_Write,
SOP_Status,
SOP_Name,
SOP_Content,
SOP_User,
SOP_Date,
CONF_Status,
CONF_Content,
Pre_Date,
END_Date,
CONF_User,
CONF_User_Date,
CONF_APP,
CONF_APP_Date,
CONF_MG,
CONF_MG_Date,
COMP_MG,
Other_Together_Write,
OP_Type,
Status,
NowUser ,
ReqReplyDate,
Happen_Address,
CycleValue,
ReceiveDate ,
ReceiveUser,
ReqSolution ,
ReqTimeLimit ,
ShadinessQty,
IA_APP,
IA_USER,
IPCA_APP,
IPCA_USER,
Info_Date
)
VALUES
(
@Serial_No,
@FactoryID,
@FactoryName,
@FactoryType,
@CustName,
@CustType,
@Fahuo_Quan,
@JianCha_Quan,
@badness_bi,
@badness_DC,
@zaixian_quan,
@kuchun_quan,
@tuihuo_status,
@tuihuo_quan,
@kuhuhappen_address,
@tijiao_status,
@tijiao_type,
@DC_quan,
@zaitu_status,
@zaitu_quan,
@chuli_status,
@changleikuchun_status,
@chuli_type,
@Happen_Date,
@Required_Date,
@CONF_Date,
@Issued_Date,
@From_Comp,
@CAR_Comp,
@Issued_User,
@Issued_APP,
@Issued_MG,
@Received_User,
@HSF_Happen_Type,
@CAR_Part_Num,
@CAR_Content,
@LOT,
@batch,
@sample,
@badness_Num,
@ReWork,
@Reject,
@NoWork,
@Info_Type_1,
@Info_Type_2,
@Info_Type_3,
@Info_Type_4,
@Info_Type_5,
@Info_Content,
@Interim_Action,
@IA_Date,
@Corrective_Action,
@CA_Date,
@IPCA,
@IPCA_Date,
@ATPR,
@ATPR_Date,
@Z_User,
@Z_APP,
@Z_MG,
@Levels,
@Together_Write,
@SOP_Status,
@SOP_Name,
@SOP_Content,
@SOP_User,
@SOP_Date,
@CONF_Status,
@CONF_Content,
@Pre_Date,
@END_Date,
@CONF_User,
@CONF_User_Date,
@CONF_APP,
@CONF_APP_Date,
@CONF_MG,
@CONF_MG_Date,
@COMP_MG,
@Other_Together_Write,
@OP_Type,
@Status,
@NowUser ,
@ReqReplyDate,
@Happen_Address,
@CycleValue,
@ReceiveDate ,
@ReceiveUser,
@ReqSolution ,
@ReqTimeLimit ,
@ShadinessQty,
@IA_APP,
@IA_USER,
@IPCA_APP,
@IPCA_USER,
@Info_Date
)

---新记录ID
select @RKEY=@@identity


if(@@error >0 )
begin
	rollback tran t1
	select @returnID= 3 --'保存失败,[数据回滚]'
end
else
begin
	commit tran t1
	select @returnID=0  --保存成功
end

GO
Create Procedure [dbo].[Proc_CAR_UpdateCARData01]
@rkey                              int ,
@Serial_No                         varchar(15)=null,
@FactoryID decimal(2,0)=null,
@FactoryName varchar(50)=null,
@FactoryType varchar(50)=null,
@CustName varchar(50)=null,
@CustType varchar(50)=null,
@Fahuo_Quan decimal(18,0)=null,
@JianCha_Quan decimal(18,0)=null,
@badness_bi decimal(7,2)=null,
@badness_DC varchar(50)=null,
@zaixian_quan decimal(18,0)=null,
@kuchun_quan decimal(18,0)=null,
@tuihuo_status int=null,
@tuihuo_quan decimal(18,0)=null,
@kuhuhappen_address decimal(2,0)=null,
@tijiao_status decimal(2,0)=null,
@tijiao_type decimal(2,0)=null,
@DC_quan decimal(18,0)=null,
@zaitu_status decimal(2,0)=null,
@zaitu_quan decimal(18,0)=null,
@chuli_status decimal(1,0)=null,
@changleikuchun_status decimal(1,0)=null,
@chuli_type decimal(2,0)=null,
@Happen_Date                       datetime=null ,
@Required_Date                     datetime=null ,
@CONF_Date                         datetime=null ,
@Issued_Date                       datetime=null ,
@From_Comp                         varchar(50)=null,
@CAR_Comp                          varchar(50)=null,
@Issued_User                       varchar(20)=null,
@Issued_APP                        varchar(20)=null,
@Issued_MG                         varchar(20)=null,
@Received_User                     varchar(20)=null,
@HSF_Happen_Type                   varchar(30)=null,
@CAR_Part_Num                      varchar(30)=null,
@CAR_Content                       varchar(max)=null,
@LOT                               varchar(30)=null ,
@batch                             float=null ,
@sample                            float=null ,
@badness_Num                       float=null ,
@ReWork                            float =null,
@Reject                            float =null,
@NoWork                            float =null,
@Info_Type_1                       int =null,
@Info_Type_2                       int =null,
@Info_Type_3                       int =null,
@Info_Type_4                       int =null,
@Info_Type_5                       int=null ,
@Info_Content                      varchar(max)=null,
@Interim_Action                    varchar(max)=null,
@IA_Date                           datetime=null ,
@Corrective_Action                 varchar(max)=null,
@CA_Date                           datetime =null,
@IPCA                              varchar(max)=null,
@IPCA_Date                         datetime=null ,
@ATPR                              varchar(max)=null,
@ATPR_Date                         datetime=null ,
@Z_User                            varchar(20)=null,
@Z_APP                             varchar(20)=null,
@Z_MG                              varchar(20)=null,
@Levels                            varchar(200)=null,
@Together_Write                    varchar(200)=null,
@SOP_Status                        int =null,
@SOP_Name                          varchar(20)=null,
@SOP_Content                       varchar(200)=null,
@SOP_User                          varchar(20)=null,
@SOP_Date                          datetime=null ,
@CONF_Status                       int =null,
@CONF_Content                      varchar(max)=null,
@Pre_Date                          datetime =null,
@END_Date                          datetime =null,
@CONF_User                         varchar(20)=null,
@CONF_User_Date                    datetime =null,
@CONF_APP                          varchar(20)=null,
@CONF_APP_Date                     datetime=null ,
@CONF_MG                           varchar(20)=null,
@CONF_MG_Date                      datetime =null,
@COMP_MG                           varchar(20)=null,
@Other_Together_Write              varchar(50)=null,
@OP_Type                           int=null ,
@Status                            int =null,
@NowUser                           varchar(50) =null,
@ReqReplyDate                   datetime= NULL,
@Happen_Address               varchar(50)=NULL,
@CycleValue                   varchar(50)= NULL,
@ReceiveDate                   datetime =NULL,
@ReceiveUser                 varchar(50)= NULL,
@ReqSolution                varchar(50)= NULL,
@ReqTimeLimit                varchar(30)= NULL,
@ShadinessQty               float= NULL,
@IA_APP                            varchar(30)= NULL,
@IA_USER                           varchar(30)= NULL,
@IPCA_APP                            varchar(30)= NULL,
@IPCA_USER                            varchar(30)= NULL,
@Info_Date                            datetime= NULL,
@returnID int output
AS

--- 开始数据库操作事务
begin tran t1

UPDATE CAR_Table_Data01
SET
Serial_No = @Serial_No,
[FactoryID] = @FactoryID,
[FactoryName] = @FactoryName,
[FactoryType] = @FactoryType,
[CustName] = @CustName,
[CustType] = @CustType,
[Fahuo_Quan] = @Fahuo_Quan,
[JianCha_Quan] = @JianCha_Quan,
[badness_bi] = @badness_bi,
[badness_DC] = @badness_DC,
[zaixian_quan] = @zaixian_quan,
[kuchun_quan] = @kuchun_quan,
[tuihuo_status] = @tuihuo_status,
[tuihuo_quan] = @tuihuo_quan,
[kuhuhappen_address] = @kuhuhappen_address,
[tijiao_status] = @tijiao_status,
[tijiao_type] = @tijiao_type,
[DC_quan] = @DC_quan,
[zaitu_status] = @zaitu_status,
[zaitu_quan] = @zaitu_quan,
[chuli_status] = @chuli_status,
[changleikuchun_status] = @changleikuchun_status,
[chuli_type] = @chuli_type,
Happen_Date = @Happen_Date,
Required_Date = @Required_Date,
CONF_Date = @CONF_Date,
Issued_Date = @Issued_Date,
From_Comp = @From_Comp,
CAR_Comp = @CAR_Comp,
Issued_User = @Issued_User,
Issued_APP = @Issued_APP,
Issued_MG = @Issued_MG,
Received_User = @Received_User,
HSF_Happen_Type = @HSF_Happen_Type,
CAR_Part_Num = @CAR_Part_Num,
CAR_Content = @CAR_Content,
LOT = @LOT,
batch = @batch,
sample = @sample,
badness_Num = @badness_Num,
ReWork = @ReWork,
Reject = @Reject,
NoWork = @NoWork,
Info_Type_1 = @Info_Type_1,
Info_Type_2 = @Info_Type_2,
Info_Type_3 = @Info_Type_3,
Info_Type_4 = @Info_Type_4,
Info_Type_5 = @Info_Type_5,
Info_Content = @Info_Content,
Interim_Action = @Interim_Action,
IA_Date = @IA_Date,
Corrective_Action = @Corrective_Action,
CA_Date = @CA_Date,
IPCA = @IPCA,
IPCA_Date = @IPCA_Date,
ATPR = @ATPR,
ATPR_Date = @ATPR_Date,
Z_User = @Z_User,
Z_APP = @Z_APP,
Z_MG = @Z_MG,
Levels = @Levels,
Together_Write = @Together_Write,
SOP_Status = @SOP_Status,
SOP_Name = @SOP_Name,
SOP_Content = @SOP_Content,
SOP_User = @SOP_User,
SOP_Date = @SOP_Date,
CONF_Status = @CONF_Status,
CONF_Content = @CONF_Content,
Pre_Date = @Pre_Date,
END_Date = @END_Date,
CONF_User = @CONF_User,
CONF_User_Date = @CONF_User_Date,
CONF_APP = @CONF_APP,
CONF_APP_Date = @CONF_APP_Date,
CONF_MG = @CONF_MG,
CONF_MG_Date = @CONF_MG_Date,
COMP_MG = @COMP_MG,
Other_Together_Write = @Other_Together_Write,
OP_Type = @OP_Type,
Status = @Status,
NowUser = @NowUser ,
ReqReplyDate=@ReqReplyDate,
Happen_Address=@Happen_Address,
CycleValue=@CycleValue,
ReceiveDate=@ReceiveDate ,
ReceiveUser=@ReceiveUser,
ReqSolution=@ReqSolution ,
ReqTimeLimit=@ReqTimeLimit ,
ShadinessQty=@ShadinessQty ,
IA_APP=@IA_APP,
IA_USER =@IA_USER,
IPCA_APP=@IPCA_APP,
IPCA_USER=@IPCA_USER,
Info_Date=@Info_Date
WHERE rkey = @rkey

if(@@error >0 )
begin
	rollback tran t1
	select @returnID= 3 --'保存失败,[数据回滚]'
end
else
begin
	commit tran t1
	select @returnID=0  --保存成功
end

GO
CREATE PROCEDURE [dbo].[Proc_CAR_DelCARData01]
@RKEY      int,
@returnID  int output
as

--- 开始数据库操作事务
begin tran t1

delete CAR_Table_Data01 where rkey=@RKEY

if(@@error >0 )
begin
	rollback tran t1
	select @returnID= 3 --'保存失败,[数据回滚]'
end
else
begin
	commit tran t1
	select @returnID=0  --保存成功
end


GO

CREATE Procedure [dbo].[Proc_CAR_InsertCARLog]
@rkey                              int output,
@SN_PTR                            int =null,
@SN_TYPE                           varchar(10)=null,
@SP_Total_Step                     int =null,
@SP_Start_Date                     datetime =null,
@SP_End_Date                       datetime=null ,
@SP_Type                           int =null,
@SP_Step                           int=null ,
@SP_User                           varchar(50)=null,
@SP_Content                        varchar(200)=null,
@Status                            int  =null,
@returnID int output

AS
--- 开始数据库操作事务
begin tran t1
INSERT INTO CAR_Table_LOG
(
SN_PTR,
SN_Type,
SP_Total_Step,
SP_Start_Date,
SP_End_Date,
SP_Type,
SP_Step,
SP_User,
SP_Content,
Status 
)
VALUES
(
@SN_PTR,
@SN_TYPE,
@SP_Total_Step,
@SP_Start_Date,
@SP_End_Date,
@SP_Type,
@SP_Step,
@SP_User,
@SP_Content,
@Status 
)

---新记录ID
select @rkey=@@identity


if(@@error >0 )
begin
	rollback tran t1
	select @returnID= 3 --'保存失败,[数据回滚]'
end
else
begin
	commit tran t1
	select @returnID=0  --保存成功
end


GO
Create Procedure [dbo].[Proc_CAR_UpdateCARLog]
@rkey                              int=null ,
@SN_PTR                            int =null,
@SN_TYPE                           varchar(10)=null,
@SP_Total_Step                     int =null,
@SP_Start_Date                     datetime =null,
@SP_End_Date                       datetime =null,
@SP_Type                           int =null,
@SP_Step                           int =null,
@SP_User                           varchar(50)=null,
@SP_Content                        varchar(200)=null,
@Status                            int  =null,
@returnID int output

AS
--- 开始数据库操作事务
begin tran t1
UPDATE CAR_Table_LOG
SET
SN_PTR = @SN_PTR,
SN_TYPE=@SN_TYPE,
SP_Total_Step = @SP_Total_Step,
SP_Start_Date = @SP_Start_Date,
SP_End_Date = @SP_End_Date,
SP_Type = @SP_Type,
SP_Step = @SP_Step,
SP_User = @SP_User,
SP_Content = @SP_Content,
Status = @Status 
WHERE rkey = @rkey


if(@@error >0 )
begin
	rollback tran t1
	select @returnID= 3 --'保存失败,[数据回滚]'
end
else
begin
	commit tran t1
	select @returnID=0  --保存成功
end
 

GO
CREATE PROCEDURE [dbo].[Proc_CAR_DelCARLog]
@RKEY      int,
@returnID  int output
as

--- 开始数据库操作事务
begin tran t1

delete CAR_Table_LOG where rkey=@RKEY

if(@@error >0 )
begin
	rollback tran t1
	select @returnID= 3 --'保存失败,[数据回滚]'
end
else
begin
	commit tran t1
	select @returnID=0  --保存成功
end


go
create proc PROC_CAR_GetSerialNo
@type varchar(10)
as
begin
	
	declare @year varchar(2)
	declare @month varchar(2)
	declare @length int
	declare @temp1 int
	declare @temp2 nvarchar(10)
	set @year = substring(convert(char(10),getdate(),20),3,2)
	set @month = substring(convert(char(10),getdate(),20),6,2)
	set @length = len(rtrim(@type))

	select @temp1 = isnull(max(cast(right(Serial_No,3) as int)),0)
	from [CAR_Table_Data01]
	where len(rtrim(Serial_No)) > 5 
		and left(Serial_No,@length) = @type
		and substring(Serial_No,charindex('-',Serial_No)+1,2) = @year
		and substring(Serial_No,charindex('-',Serial_No,charindex('-',Serial_No)+1)+1,2) = @month

	set @temp1 = @temp1 + 1
	set @temp2 = rtrim(ltrim(cast(@temp1 as int)))

	if(len(@temp2) = 1)
	begin
		set @temp2 = '00'+ @temp2
	end
	if(len(@temp2) = 2)
	begin
		set @temp2 = '0'+ @temp2
	end

	select @type+'-'+@year+'-'+@month+'-'+ @temp2
end


GO
------------------------------------
--用途：增加一条记录 
--项目名称：CodematicDemo
--说明：
--时间：2009-7-9 14:37:10
------------------------------------
CREATE PROCEDURE [UP_CAR_Table_SAList_ADD]
@rkey int output,
@sn_ptr int= NULL,
@custCode varchar(10)= NULL,
@custName varchar(80)= NULL,
@recordDateTime datetime= NULL,
@founderMaterilNo varchar(30)= NULL,
@custPartNo varchar(50)= NULL,
@cycleValue varchar(10)= NULL,
@happenAddress varchar(50)= NULL,
@LOT varchar(20)= NULL,
@ET varchar(20)= NULL,
@T varchar(20)= NULL,
@reason varchar(50)= NULL,
@mateialType varchar(10)= NULL,
@results varchar(10)= NULL,
@quantity float= NULL,
@signDate datetime= NULL,
@signingPerson varchar(20)= NULL,
@factoryName varchar(10)= NULL,
@discountPrice float= NULL,
@discountAmount float= NULL

 AS 
	INSERT INTO [CAR_Table_SAList](
	[sn_ptr],[custCode],[custName],[recordDateTime],[founderMaterilNo],[custPartNo],[cycleValue],[happenAddress],[LOT],[ET],[T],[reason],[mateialType],[results],[quantity],[signDate],[signingPerson],[factoryName],[discountPrice],[discountAmount]
	)VALUES(
	@sn_ptr,@custCode,@custName,@recordDateTime,@founderMaterilNo,@custPartNo,@cycleValue,@happenAddress,@LOT,@ET,@T,@reason,@mateialType,@results,@quantity,@signDate,@signingPerson,@factoryName,@discountPrice,@discountAmount
	)
	SET @rkey = @@IDENTITY
