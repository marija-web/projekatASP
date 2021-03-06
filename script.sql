USE [projekatASP]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1, N'Fun', CAST(N'2022-06-10T23:06:09.7311230' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Category] ([Id], [Name], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (2, N'News', CAST(N'2022-06-10T23:06:09.7311237' AS DateTime2), NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Email], [Username], [Password], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1, N'Maki', N'Makic', N'maki@gmail.com', N'makiM', N'$2a$11$397cq1gBrsk/Sc0QUPfC.OueVB52kgY6SiBj6lDyeVkFzgc6hVjPe', CAST(N'2022-06-10T23:06:09.7310169' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Email], [Username], [Password], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (2, N'Mici', N'Micic', N'mici@gmail.com', N'miciM', N'$2a$11$nWArz9JprFOsHITdH8Emte2HLr9IUEOPNioVA6S1X5hfqnFPJ7Sa2', CAST(N'2022-06-10T23:06:09.7311210' AS DateTime2), NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([Id], [Title], [Caprtion], [UserId], [CategoryId], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1, N'Title1', N'Lorem ipsum1', 1, 1, CAST(N'2022-06-10T23:06:09.7311262' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Post] ([Id], [Title], [Caprtion], [UserId], [CategoryId], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (2, N'Title2', N'Lorem ipsum2', 2, 2, CAST(N'2022-06-10T23:06:09.7311270' AS DateTime2), NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[Image] ON 

INSERT [dbo].[Image] ([Id], [Path], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1, N'something.png', CAST(N'2022-06-10T23:06:09.7311252' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Image] ([Id], [Path], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (2, N'something2.jpg', CAST(N'2022-06-10T23:06:09.7311258' AS DateTime2), NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Image] OFF
GO
INSERT [dbo].[PostImage] ([PostId], [ImageId]) VALUES (1, 1)
INSERT [dbo].[PostImage] ([PostId], [ImageId]) VALUES (2, 2)
GO
SET IDENTITY_INSERT [dbo].[Tag] ON 

INSERT [dbo].[Tag] ([Id], [Name], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1, N'Riality', CAST(N'2022-06-10T23:06:09.7311242' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Tag] ([Id], [Name], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (2, N'Baskteball', CAST(N'2022-06-10T23:06:09.7311248' AS DateTime2), NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Tag] OFF
GO
INSERT [dbo].[PostTag] ([PostId], [TagId]) VALUES (1, 1)
INSERT [dbo].[PostTag] ([PostId], [TagId]) VALUES (2, 2)
GO
SET IDENTITY_INSERT [dbo].[UseCaseLogs] ON 

INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1, N'Ef search tags', 2, CAST(N'2022-06-10T23:52:23.5936174' AS DateTime2), N'{"Keyword":null,"PerPage":1,"Page":1}', 1, CAST(N'2022-06-10T23:52:23.7503406' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (2, N'Ef search use cse logs', 2, CAST(N'2022-06-11T00:16:47.1439775' AS DateTime2), N'{"Keyword":null,"PerPage":1,"Page":1}', 0, CAST(N'2022-06-11T00:16:48.8754831' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (3, N'Ef search use cse logs', 2, CAST(N'2022-06-11T00:18:25.8064886' AS DateTime2), N'{"Keyword":null,"PerPage":1,"Page":1}', 0, CAST(N'2022-06-11T00:18:25.8228778' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (4, N'Ef search use cse logs', 2, CAST(N'2022-06-11T00:20:41.2575723' AS DateTime2), N'{"Keyword":null,"PerPage":1,"Page":1}', 1, CAST(N'2022-06-11T00:20:41.4343231' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (5, N'Ef search use cse logs', 2, CAST(N'2022-06-11T00:22:15.8652253' AS DateTime2), N'{"Keyword":null,"PerPage":1,"Page":1}', 1, CAST(N'2022-06-11T00:22:17.8292634' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (6, N'Ef search use cse logs', 2, CAST(N'2022-06-11T00:23:06.5476355' AS DateTime2), N'{"Keyword":null,"PerPage":1,"Page":1}', 1, CAST(N'2022-06-11T00:23:08.3154409' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (7, N'Ef search use cse logs', 2, CAST(N'2022-06-11T00:23:34.9999678' AS DateTime2), N'{"Keyword":"tags","PerPage":1,"Page":1}', 1, CAST(N'2022-06-11T00:23:35.0457042' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1002, N'Ef search tags', 2, CAST(N'2022-06-11T10:08:31.9604902' AS DateTime2), N'{"Keyword":null,"PerPage":1,"Page":1}', 0, CAST(N'2022-06-11T10:08:32.1208023' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1005, N'Ef create comment', 2, CAST(N'2022-06-11T10:55:34.2745093' AS DateTime2), N'{"Comment":"Ovo je moj okomentar","PostId":1,"UserId":1,"Id":0}', 1, CAST(N'2022-06-11T10:55:34.2899719' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1006, N'Ef delete comment', 2, CAST(N'2022-06-11T11:08:20.3137693' AS DateTime2), N'1002', 1, CAST(N'2022-06-11T11:08:20.4497566' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1007, N'Ef edit comment', 2, CAST(N'2022-06-11T11:28:43.1370343' AS DateTime2), N'{"Comment":"New Comment","PostId":0,"UserId":0,"Id":1}', 1, CAST(N'2022-06-11T11:28:43.2821817' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1008, N'Ef edit comment', 2, CAST(N'2022-06-11T11:38:38.7811403' AS DateTime2), N'{"Comment":"New Comment","PostId":1,"UserId":5,"Id":1}', 1, CAST(N'2022-06-11T11:38:40.8264462' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1009, N'Ef edit comment', 2, CAST(N'2022-06-11T11:39:23.4215424' AS DateTime2), N'{"Comment":"New Comment","PostId":1,"UserId":1,"Id":1}', 1, CAST(N'2022-06-11T11:39:23.4644406' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1010, N'Ef create like', 2, CAST(N'2022-06-11T12:26:24.8609989' AS DateTime2), N'{"PostId":1,"UserId":5,"Like":false,"Id":0}', 1, CAST(N'2022-06-11T12:26:25.3012145' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1011, N'Ef create like', 2, CAST(N'2022-06-11T12:29:20.9309576' AS DateTime2), N'{"PostId":1,"UserId":5,"Like":true,"Id":0}', 1, CAST(N'2022-06-11T12:29:20.9541568' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1012, N'Ef create like', 2, CAST(N'2022-06-11T12:29:31.4553385' AS DateTime2), N'{"PostId":1,"UserId":1,"Like":true,"Id":0}', 1, CAST(N'2022-06-11T12:29:31.4558964' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1013, N'Ef create like', 2, CAST(N'2022-06-11T12:30:42.9874329' AS DateTime2), N'{"PostId":1,"UserId":1,"Like":false,"Id":0}', 1, CAST(N'2022-06-11T12:30:44.5000138' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1014, N'Ef create like', 2, CAST(N'2022-06-11T12:31:04.6841600' AS DateTime2), N'{"PostId":1,"UserId":1,"Like":false,"Id":0}', 1, CAST(N'2022-06-11T12:31:04.7249394' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1015, N'Ef create like', 2, CAST(N'2022-06-11T12:33:30.3092765' AS DateTime2), N'{"PostId":1,"UserId":1,"Like":false,"Id":0}', 1, CAST(N'2022-06-11T12:33:31.8466090' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1016, N'Ef create like', 2, CAST(N'2022-06-11T12:34:50.4576976' AS DateTime2), N'{"PostId":1,"UserId":1,"Like":true,"Id":0}', 1, CAST(N'2022-06-11T12:34:50.4998455' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1017, N'Ef create like', 2, CAST(N'2022-06-11T12:43:29.3180771' AS DateTime2), N'{"PostId":1,"UserId":1,"Like":false,"Id":0}', 1, CAST(N'2022-06-11T12:43:30.9652251' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1018, N'Ef create like', 2, CAST(N'2022-06-11T12:44:12.9717549' AS DateTime2), N'{"PostId":2,"UserId":1,"Like":false,"Id":0}', 1, CAST(N'2022-06-11T12:44:13.0195641' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1019, N'Ef create like', 2, CAST(N'2022-06-11T12:57:00.7552708' AS DateTime2), N'{"PostId":2,"UserId":1,"Like":false,"Id":0}', 1, CAST(N'2022-06-11T12:57:00.9169665' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1020, N'Ef create like', 2, CAST(N'2022-06-11T12:57:46.6262942' AS DateTime2), N'{"PostId":2,"UserId":1,"Like":true,"Id":0}', 1, CAST(N'2022-06-11T12:57:46.6392800' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1021, N'Ef create like', 2, CAST(N'2022-06-11T13:03:28.1731899' AS DateTime2), N'{"PostId":2,"UserId":2,"Like":true,"Id":0}', 1, CAST(N'2022-06-11T13:03:29.7283406' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1022, N'Ef create like', 2, CAST(N'2022-06-11T13:05:59.4346711' AS DateTime2), N'{"PostId":2,"UserId":1,"Like":true,"Id":0}', 1, CAST(N'2022-06-11T13:05:59.4773546' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1023, N'Ef edit use case', 2, CAST(N'2022-06-11T13:38:02.8221926' AS DateTime2), N'{"UserId":2,"UseCaseIds":[1,2,3,4,5,7,8,10,11,12,13,14,15,16,17,18,19,20,25]}', 1, CAST(N'2022-06-11T13:38:02.9767939' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1024, N'Ef edit use case', 2, CAST(N'2022-06-11T13:39:24.4317619' AS DateTime2), N'{"UserId":2,"UseCaseIds":[21]}', 1, CAST(N'2022-06-11T13:39:24.4505810' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1025, N'Ef edit use case', 2, CAST(N'2022-06-11T13:39:57.0925408' AS DateTime2), N'{"UserId":2,"UseCaseIds":[1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25]}', 1, CAST(N'2022-06-11T13:39:57.0930135' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1026, N'Ef delete like/dislike', 2, CAST(N'2022-06-11T13:44:26.7039863' AS DateTime2), N'{"PostId":2,"UserId":2,"Like":false,"Id":0}', 1, CAST(N'2022-06-11T13:44:28.3636750' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1027, N'Ef delete like/dislike', 2, CAST(N'2022-06-11T13:44:43.8657975' AS DateTime2), N'{"PostId":2,"UserId":2,"Like":false,"Id":0}', 1, CAST(N'2022-06-11T13:44:43.9140422' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1028, N'Ef delete like/dislike', 2, CAST(N'2022-06-11T13:45:28.8989698' AS DateTime2), N'{"PostId":2,"UserId":2,"Like":false,"Id":0}', 1, CAST(N'2022-06-11T13:45:30.4648191' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1029, N'Ef edit like/dislike', 2, CAST(N'2022-06-11T14:03:55.3524305' AS DateTime2), N'{"PostId":1,"UserId":1,"Like":false,"Id":0}', 1, CAST(N'2022-06-11T14:03:55.4967046' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1030, N'Ef edit like/dislike', 2, CAST(N'2022-06-11T14:04:11.9386872' AS DateTime2), N'{"PostId":3,"UserId":1,"Like":false,"Id":0}', 1, CAST(N'2022-06-11T14:04:11.9508902' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [UserId], [ExecutionDateTime], [Data], [IsAuthorized], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1031, N'Ef search categories', 2, CAST(N'2022-06-12T10:25:32.9151724' AS DateTime2), N'{"Keyword":null,"PerPage":1,"Page":1}', 1, CAST(N'2022-06-12T10:25:33.0593806' AS DateTime2), NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[UseCaseLogs] OFF
GO
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 1)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 2)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 3)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 4)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 5)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 6)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 7)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 8)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 9)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 10)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 11)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 12)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 13)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 14)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 15)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 16)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 17)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 18)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 19)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 20)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 21)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 22)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 23)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 24)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 25)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 26)
GO
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([Id], [Content], [PostId], [UserId], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1, N'New Comment', 1, 1, CAST(N'2022-06-10T23:06:09.7311283' AS DateTime2), NULL, NULL, CAST(N'2022-06-11T11:39:24.4295265' AS DateTime2), NULL, 1)
INSERT [dbo].[Comment] ([Id], [Content], [PostId], [UserId], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (2, N'Comment2', 2, 2, CAST(N'2022-06-10T23:06:09.7311286' AS DateTime2), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Comment] ([Id], [Content], [PostId], [UserId], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy], [IsActive]) VALUES (1002, N'Ovo je moj okomentar', 1, 1, CAST(N'2022-06-11T10:55:55.3466595' AS DateTime2), CAST(N'2022-06-11T11:08:21.0720299' AS DateTime2), NULL, CAST(N'2022-06-11T11:08:21.0841386' AS DateTime2), NULL, 0)
SET IDENTITY_INSERT [dbo].[Comment] OFF
GO
INSERT [dbo].[LikeDislike] ([PostId], [UserId], [Like]) VALUES (1, 1, 0)
INSERT [dbo].[LikeDislike] ([PostId], [UserId], [Like]) VALUES (2, 1, 0)
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220610230439_Initial', N'5.0.17')
GO
