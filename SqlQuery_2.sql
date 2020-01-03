﻿CREATE TABLE [dbo].[City] (
    [Id] [int] NOT NULL IDENTITY,
    [Postal] [varchar](20) NOT NULL,
    [CityName] [varchar](100) NOT NULL,
    CONSTRAINT [PK_dbo.City] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Customer] (
    [Id] [int] NOT NULL IDENTITY,
    [IsActive] [bit] NOT NULL,
    [Name] [nvarchar](100) NOT NULL,
    [Mail] [nvarchar](50) NOT NULL,
    [Street] [varchar](200) NOT NULL,
    [HouseNr] [varchar](4) NOT NULL,
    [Bus] [varchar](4),
    [CityId] [int] NOT NULL,
    [PhoneNr] [varchar](90) NOT NULL,
    [VAT] [varchar](90) NOT NULL,
    CONSTRAINT [PK_dbo.Customer] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_CityId] ON [dbo].[Customer]([CityId])
CREATE TABLE [dbo].[Invoice] (
    [Id] [int] NOT NULL IDENTITY,
    [CustumorId] [int] NOT NULL,
    [InvoiceDate] [datetime] NOT NULL,
    [Code] [nvarchar](20) NOT NULL,
    [State] [bit],
    [IsActive] [bit] NOT NULL,
    [DeleteMessage] [nvarchar](300),
    [Customer_Id] [int],
    CONSTRAINT [PK_dbo.Invoice] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_Customer_Id] ON [dbo].[Invoice]([Customer_Id])
CREATE TABLE [dbo].[DetailLine] (
    [Id] [int] NOT NULL IDENTITY,
    [InvoiceId] [int] NOT NULL,
    [Item] [varchar](8000) NOT NULL,
    [UnitPrice] [decimal](18, 2) NOT NULL,
    [Discount] [decimal](18, 2) NOT NULL,
    [Amount] [decimal](18, 0) NOT NULL,
    [VATPercentage] [decimal](18, 2) NOT NULL,
    CONSTRAINT [PK_dbo.DetailLine] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_InvoiceId] ON [dbo].[DetailLine]([InvoiceId])
CREATE TABLE [dbo].[Role] (
    [Id] [int] NOT NULL IDENTITY,
    [RoleName] [varchar](20) NOT NULL,
    CONSTRAINT [PK_dbo.Role] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[User] (
    [IdU] [int] NOT NULL IDENTITY,
    [IsActive] [bit] NOT NULL,
    [FirstName] [nvarchar](50) NOT NULL,
    [LastName] [nvarchar](50) NOT NULL,
    [Street] [varchar](200) NOT NULL,
    [HouseNr] [varchar](4) NOT NULL,
    [Bus] [varchar](4),
    [CityId] [int] NOT NULL,
    [Email] [nvarchar](max),
    [EmailConfirmed] [bit] NOT NULL,
    [PasswordHash] [nvarchar](max),
    [SecurityStamp] [nvarchar](max),
    [PhoneNumber] [nvarchar](max),
    [PhoneNumberConfirmed] [bit] NOT NULL,
    [TwoFactorEnabled] [bit] NOT NULL,
    [LockoutEndDateUtc] [datetime],
    [LockoutEnabled] [bit] NOT NULL,
    [AccessFailedCount] [int] NOT NULL,
    [Id] [nvarchar](max),
    [UserName] [nvarchar](max),
    CONSTRAINT [PK_dbo.User] PRIMARY KEY ([IdU])
)
CREATE INDEX [IX_CityId] ON [dbo].[User]([CityId])
CREATE TABLE [dbo].[IdentityUserClaims] (
    [Id] [int] NOT NULL IDENTITY,
    [UserId] [nvarchar](max),
    [ClaimType] [nvarchar](max),
    [ClaimValue] [nvarchar](max),
    [User_IdU] [int],
    CONSTRAINT [PK_dbo.IdentityUserClaims] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_User_IdU] ON [dbo].[IdentityUserClaims]([User_IdU])
CREATE TABLE [dbo].[IdentityUserLogin] (
    [LoginProvider] [nvarchar](128) NOT NULL,
    [UserId] [nvarchar](128) NOT NULL,
    [ProviderKey] [nvarchar](max),
    [User_IdU] [int],
    CONSTRAINT [PK_dbo.IdentityUserLogin] PRIMARY KEY ([LoginProvider], [UserId])
)
CREATE INDEX [IX_User_IdU] ON [dbo].[IdentityUserLogin]([User_IdU])
CREATE TABLE [dbo].[IdentityUserRole] (
    [RoleId] [nvarchar](128) NOT NULL,
    [UserId] [nvarchar](128) NOT NULL,
    [User_IdU] [int],
    CONSTRAINT [PK_dbo.IdentityUserRole] PRIMARY KEY ([RoleId], [UserId])
)
CREATE INDEX [IX_User_IdU] ON [dbo].[IdentityUserRole]([User_IdU])
CREATE TABLE [dbo].[UserRole] (
    [Id] [int] NOT NULL IDENTITY,
    [UserId] [int] NOT NULL,
    [RoleId] [int] NOT NULL,
    [User_IdU] [int],
    CONSTRAINT [PK_dbo.UserRole] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_RoleId] ON [dbo].[UserRole]([RoleId])
CREATE INDEX [IX_User_IdU] ON [dbo].[UserRole]([User_IdU])
ALTER TABLE [dbo].[Customer] ADD CONSTRAINT [FK_dbo.Customer_dbo.City_CityId] FOREIGN KEY ([CityId]) REFERENCES [dbo].[City] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Invoice] ADD CONSTRAINT [FK_dbo.Invoice_dbo.Customer_Customer_Id] FOREIGN KEY ([Customer_Id]) REFERENCES [dbo].[Customer] ([Id])
ALTER TABLE [dbo].[DetailLine] ADD CONSTRAINT [FK_dbo.DetailLine_dbo.Invoice_InvoiceId] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoice] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[User] ADD CONSTRAINT [FK_dbo.User_dbo.City_CityId] FOREIGN KEY ([CityId]) REFERENCES [dbo].[City] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[IdentityUserClaims] ADD CONSTRAINT [FK_dbo.IdentityUserClaims_dbo.User_User_IdU] FOREIGN KEY ([User_IdU]) REFERENCES [dbo].[User] ([IdU])
ALTER TABLE [dbo].[IdentityUserLogin] ADD CONSTRAINT [FK_dbo.IdentityUserLogin_dbo.User_User_IdU] FOREIGN KEY ([User_IdU]) REFERENCES [dbo].[User] ([IdU])
ALTER TABLE [dbo].[IdentityUserRole] ADD CONSTRAINT [FK_dbo.IdentityUserRole_dbo.User_User_IdU] FOREIGN KEY ([User_IdU]) REFERENCES [dbo].[User] ([IdU])
ALTER TABLE [dbo].[UserRole] ADD CONSTRAINT [FK_dbo.UserRole_dbo.Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[UserRole] ADD CONSTRAINT [FK_dbo.UserRole_dbo.User_User_IdU] FOREIGN KEY ([User_IdU]) REFERENCES [dbo].[User] ([IdU])
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'202001031059325_Initial', N'InvoiceSystem.DAL.Migrations.Configuration',  0x1F8B0800000000000400ED1DD96EE4B8F13D40FE41E8A724F076FB9859CC18EE5D78ECF1AE115F70DB83BC19B444B785D1D191D45E1B41BE2C0FF9A4FC42489DBC0F1D6D8D61F8C5CDA358C5AA22AB4A24EB7FFFF9EFC1AFCF61E03CC124F5E3683ED9996E4F1C18B9B1E747CBF9649D3DFCF469F2EB2F7FFED3C1572F7C76BE55EDF6703BD4334AE793C72C5BEDCF66A9FB0843904E43DF4DE2347EC8A66E1CCE8017CF76B7B73FCF76766610819820588E7370BD8E323F84F90FF4F3288E5CB8CAD620388F3D18A46539AA59E4509D0B10C274055C389F9C464FB1EFC2C54B9AC1707A7C7836710E031F20441630789838208AE20C6408CDFDDB142EB2248E968B152A00C1CDCB0AA2760F20486189FE7ED3DC9492ED5D4CC9ACE9588172D7691687960077F6CAA999B1DD5B4DF0A49E3A34795FD124672F98EA7C02E79323F473E2B003ED1F05096E2498DB69C18F29EEB8E570D55BB54420C1C17F5BCED13AC8D6099C47709D2520D872AED6F781EFFE1DBEDCC4DF61348FD641402289D0447554012ABA4AE2154CB2976BF850A27EEA4D9C19DD6FC676ACBB117D2AC2B2BDDD8973810607F701AC65809884451627F03718C10464D0BB0259069308C380F92C72A333635DC56906826A3C2476488126CE39783E83D1327B9C4F7691C69CF8CFD0AB0A4A146E231FA91BEA93256B2840513D2C660CFE4F31F0CE760F231FCC1A61528B582E5C3069276665E77751538E951EBA99FF54F3FC4B1C071044D6B2B309B9E1473D07BE4A4D3E0E32281A08C24CA99D838CFB7BBC4EE145A218F8C310C37E59A79D87D4AF3B7A99D72C998F71A49E9CCF8330E5DBE1CDF0635E80277F99ABBB60E626CE350CF2CAF4D15F15964BBDF8DD152D4E9238BC8E036249CD2BEE16F13A71B1DEC6A2DA1B902CB1A09B6253AEB3A910A3B2F2AE59D31BA4D8BA7AE40A2FAE418578AB6DA584D66A57292BDE3715A542A3795D8771D255A9CB393E46485480F0FF377ED8C2B841FCDBB845B5C808D4EBAD75333BF235042936FCA524EF196E53C68B51ADD95DD59F5D96A4EB83296AC7304396C2991F691627AA1D8F20512DC5916C2342D378956A00B55AA89AEEEF6B95C11AD379A94233ABD035F4EF10EB0BEA9D5D25F95E562E8FD0F543EC3A5E25E8BF320EF369E22C5C8081DAD375ECA76EBC8EB2C106380C49F0ED261F1961571069639481658F53A13374FA5A4A64D68E68B969B59420B0B940B658468AAEEF4B8872A7455CD3F8BF7D9817C6ECBE4D5B864C70C7D766F56D1B5EDFFE780193133F49338DD40C13BF3803AF34F07BE064848193AFA13A86666AB9188C7214470F7E1242AFABEE5C8134FD234EBCDF41FA3838EA0BE8AE1334D1C8970B57838F56C4B1D6E13D54C96BEF63F5C69A9B3FE213E0A225F66B847B75867716BBDFE375F635F2B0E77F9BB97C20C010402FE81CBA2E4CD31324CCD03BEA6EB836CA3B1893F19EAE59ED5B0E641F95C4B87011C9BA9073A99B1A5B7FFF28007E2876F50BA0653D8B455E2CC1A3A8B3C5E42C5EFA910293AA9EC1A428166352D6D9628221281029AB193CF252311A4555A7104765736178F9FCAAACD6F3FA53F561BABA80D9B4EA3D2DE09E240826DA15BE4F39B05B8E71E7C6D6DD35B575F776EE1FF63E7DFC19787B3F7F807B1FDFA28B83A772038B55CE2D3CC66646FA068275DF43B512FE5CA5FB17FE1CECF8853F4713153FF91EB67A66FA1E9538DAAA0C3392FC73F5EEA741C2753A2D1A68DC8A62343D639076BC73F42FEC18EAF8651D63C94B6EAF425E0DF136A5DB2A0AA693346524AC10A8F7C0A729C7DBB940B4B41AC2501AB9521B1757DE152D6833B7AE105ABA4DADADC95D046255D8142D04D8E426B6149BBCD6C6F43E4CD3D8F5733498AFB5853F461384BC6D47795CA4D070F2A0095274A404FE0A893D6A399FFC8D9B2519D0FAEB070134973D1AE0CE84D597CBE8180630830E0EC8E2AF3B47207581C74B0B9A138F2E412A06132CE30007A552A4B47E94F1FAE847AEBF02810A6DA693A11A63A46AF06CCD315CC1086BA08A0726E356E1417EEC7A0866A274F372302304492D5FDC077F9934C8BFFE3702517F70331732F99922BDF06E4FA73BAC5E59134E7E00D421293C58A025BF5795502325983CF27C828E2DADF44D31391BD03AC52C188DDE1C2B7815F56B426D32360BE26E0D738B7DC95CDBF850DDE897730EE50D081537E7A35FC6C970A99AF94CEC542D4BFC0A2B8528102841DC5029AAB6F496415925766C84B63BBD4C5C57426F192AEA95DE22F6AB448E090477A7960E1F4B882D8CF53E696D7C001576028780A6D80031055001D5D5119D31AE921CE21B5A29392E988C2B0DB06C6AB56CFC3AAD30D04E5E4F1246F986D68A2A25B6F02BD10421732882096DE614D1115C099F3341C0058D5DC65CD232C8C39281812F60D66C793EFE1AD538B39429C14D02D33BC6C7CF612204509BFC1A20CD65060E466D8E6B405047003928A4FDAC01547E9BE340548B86A63BE6BCA87B2111BA7960F75AE18CF01BB205D8EA1BA8126CB9EF598095CD1ABFC198CC9F0C9A140AA1478468D2F7728836C28B3BEC1AA60BCCD498534AC02D85BA500C09A6D4447677A1A933A09CBF00C013AF8E1998450D08DC1B1556CC80344E6032971DE6815A1CE453218D2218C711DA4E88C8FD276051F8779E15E264083F17125F56E3CD12B8960BA08268DE7F1D4207A8B327323A05BE96D6DB6A412BED5C91422258F0FBA1BC5AE725948BBC2EADDF654F39E3664928AF70ED87F272F390102E70BF740E983DD9B4BF25A1BAC4B317A289AF2D62BA25AE988133C6522F44DBC0FF22E0F44E79615C2928E75D040327A103E5945FA0931F05E5D527A6DA15A8EB0E66C50B2B65C1C14CF214CBC13958AD90E14A3CCD5296388BE25D96A39F16F62F9684058C994BE912EBB8D4236571029690A92DEE89E667F38F4106EE01FEF878E4855C33A1E3233123AB2129DF86E758655856CDF1FF022F2BFF4C2DDA0D9B693C419485D897CEBFEFD23B99A09B839FC6010148049F928FE2601D4672975EDEBB7AC484845095994369DE2421E134A53CA48319330B5C20809B6A2E724233CE8CADB58DD891B312DBD784BBD2AEC370B8B90A43C1A84BCD21F11C96715706A17809848450949843A86EA79030AA327328F55D13124C5D680E27BF3C42C2C80BECF486E5AEEC43821C4AFDAA06A5C455A1399CFC950C12465E301ADDADFDA26EAA5BC585EC3557DA7318C525DF67A0048428B75806C8571A28A4C80A0BECF2971A28BC623EC0AD82503EBB406BB22516FD2D6ED5430C249C22887F0ED334BFB13C1A4D50871B6C9481086FDAEB83AAF3407B59F3BD5E20C296B0F2B700283079893904E25E3F0986283687D5DCE0A704B02E3587545DD527E15465567B0179599FD915C8AAD16885CC41B7D18732566FAF0BB28EC3E84173979D84D1948E862785DBDA8D272217DC8023E26E727EDCB20CE1EEB82BFBF7B6111157CE495044B139ACE6123909AA297DB7BBBBD8DDE5A56C124859640983B8D7CB0123EA2C3C02EAEA35E516503516FCA7EF5753624057D9FA2DE52D6ADE77292B5AC193CCA8B885F908FCBD69123A5F6BA1A9FC0D6A4A65F9EA16B00538B3751676067FC99A3239F86A8BD5B4D3EED85CA6A6CCB2BA7434BBA3E0234E47DF96FBC2DFC2CBD5C3188E6D2C04F1ED2A1514E2722AB5BA37C596B0CAEBA71CB0B27C94C224FD48D756988A731DDD84490243BE6A51B740E9454B7915756811A32E6A52DB0B59314AC1E8C347E24EE674130B310895E7C372507698B02F39784DDFA90F867560943D83C6B007D809C9D0ECA5BFD10A63DAC4792B83D035D1DA30448DBF348B4369DC892A7E7A8CD85C83119FEA25C66F819AF460716B095462845C03CFCFCF0B9FA6F88E6B7DBFD59060F6B3BCB554502790749A5D37B436E404532F38B6643CEBB7BCDADE09A32896E2203809352A499011DA8F1854479CB4625035B436C164534E9FE11A8718D0C7C20C71EA624976DFA6C62E60E5E124AD7C95ED6C4D391927A99372E3102EEAF09D214A96A6C65B9726E2509D89455A3635B53A258CE30ECE8D429CB863816F64D3E24E16B24D6A7BBA2CA97FD7270BCB537DFACC6FDC31BFA2097E2DBC58B2E7934AAA5083E9E29FC151E0431C6BAC1A9C83C87F8069563CF132D9DDDED965B2C78D2793DB2C4D3DEA051A493A379A611B78A3C6C733AA7D85C6F6B92B2A7DDA1348DC479070CF71774C8E26029B67B9EA39F5D9DB6009FB6AF6BD9F754A3116B59B7E1E2899414C08F4A33D4CFA9D6BB1FCD943655EB11681FDD0E58D6A2D40FB17A97351E22E839E461E7C9E4FFE9577D9774EFF7157F4DA722E13B4AEEE3BDBCEBFBBE6FF1211F3D97ECE89EC5EAD205AA7A47A1BDA4E9E232486E99EFDC943FF675DB33F09D5BCC58E402577621634135DE9634D64CE112A08DCA3971C2365260351961ADD7495A97587C72465C7037F5885E1921099CE73DDB1D3E249262F12C9CEA7ED16FB15979BC81B3A3751EF03D0B98934E05BED2E575CDAA28E44D8E6047A1BFAD39C4FEC60F3DBE5D7693571DD92DB8CD632E772D9F46549B3A96ADE2DF41FD742A712CD548CFC4B089EFF6A4B8238994C1BC1152592E9849A30594C27888284307DC1EB650A65095FDAC092267B11D9FD26C48A93BFB4414D9AF8A59567E3F5C2CAE6DCA135B00E293ADE86C5507D05E9810D5CD28AEED0A8C4149D65E48EB5210C16FCAADF00DE9BE6B3F10F9133421C7FC4EFDBF722879DC15EF1191FDEB218091E741C673686B1CBCD08F9DC85BFA3DF78DA580FB4449972A8E8D5C9827F7DE1689DC620E714F16ADFE04F52F34FECB54C9BD02E5581F87918130571DAA42618FF3BD6C6E908ACD8A579E8B87E289400659CCAA0538E8A0DBE906FC67BF521DE0D0A80455A8657CCC1403E0E4B20B1A99C0B9B101FE5031182D1469F50E1353799E6609C550287516F2E92DBF923DB58A48F76DA7247B797F04F2C93AB93654684B6BC37E689E4ACA3F9E66270DF54ECA4C98E596E4A160C9247F4290BE5BBD8125930C916F143C982ECBAE838654170C76E4051281E5B954882593E811F471024D70E47290792976E0936562FF913CCBB1E3E2308FF4A6CCB3414ADC446FA22D2209684B1BC486382E34A20D247129E4D737C630BC5781708E68603713C917E7498655B7983853CAC2FCB8E52DC64984FBCFB1831B708B199E54DA9A31C3CE4E65EB008BA655215554E15117CFB842B9A7C2BA241ECF2B1E44B3337465521827F6D9A6A449AA94504B5A8D14D3BEF1DF00CE0DB0859A1CF0EA01ABDB44795A3976D74A3B74B0863940F4637B4312B2523AA47928E30704619624D691E0BE7D74451A894EC255B0B5E3D658C15BAE278A0E03D84FEC81C22238C09CAD2C023D155B138BE42B2177B5125D7D5E60DC7BE48E921A38B16395D3048F93C434F84F691C0A53DA1D4DE217980A02742AF3BE76B694F26B96788EFC1F74364E39476C8CF425B42E47BB53A6DE4C81C82BC62E2BB2561B1E3645FA4596459E1EF3C23FF641DE1F392C5AF6398FACB0604BEC61D4197F24CEA36A7D1435CB9480C465513F60625DA1A3CE4B61C2699FF00DC0C55E3A392B90CE4E7D8F081DD7BE89D4697EB6CB5CE10C930BC0FA8F51A3B5AAAF1F3543234CE07972BFC2BED830484A68F8F985E465FD67EE0D5789F082E094840600FAE3C25827999E1D322CB971AD245CCEE9C3240E5F4D58EE70D0C570102965E460B808FE9DBE386C4EF0C2E81FBD29C629301D133829EF683631F2C1310A6258CA63FFA8964D80B9F7FF93FBD1066B91AAE0000 , N'6.1.0-30225')

