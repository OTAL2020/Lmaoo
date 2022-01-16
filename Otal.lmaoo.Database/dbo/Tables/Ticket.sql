CREATE TABLE [dbo].[Ticket]
(
  [TicketId]	INT				NOT NULL	IDENTITY(1,1),
  [Summary]		VARCHAR(50)		NOT NULL,
  [FeatureId]	INT				NOT NULL,
  [ReporterId]	INT							DEFAULT		NULL,
  [AssigneeId]	INT							DEFAULT		NULL,
  [Created]		DATETIME		NOT NULL	DEFAULT		CURRENT_TIMESTAMP,
  [Updated]		DATETIME		NOT NULL,
  [Progress]	VARCHAR(20)		NOT NULL	DEFAULT		'Open',
  [Deadline]	DATETIME		NULL,

  CONSTRAINT [PK_Ticket_TicketId]		PRIMARY KEY (TicketId),
  CONSTRAINT [FK_Ticket_AssigneeId]		FOREIGN KEY ([AssigneeId])		REFERENCES [dbo].[User] ([userId]),
  CONSTRAINT [FK_Ticket_FeatureKey]		FOREIGN KEY ([FeatureId])		REFERENCES [dbo].[Feature] ([featureId]),
  CONSTRAINT [FK_Ticket_ReporterId]		FOREIGN KEY ([ReporterId])		REFERENCES [dbo].[User] ([userId])
)