CREATE TABLE [dbo].[Ticket]
(
  [TicketId]	int				NOT NULL	IDENTITY(1,1),
  [Summary]		varchar(50)		NOT NULL,
  [FeatureId]	int				NOT NULL,
  [ReporterKey] int				DEFAULT		NULL,
  [AssigneeKey] int				DEFAULT		NULL,
  [Created]		datetime		NOT NULL	DEFAULT CURRENT_TIMESTAMP,
  [Updated]		datetime		NOT NULL,
  [Progress]	varchar(20)		NOT NULL	DEFAULT 'Open',
  [Deadline]	datetime		NULL DEFAULT NULL,
  PRIMARY KEY (TicketId),

  CONSTRAINT [FK_Ticket_AssigneeKey]	FOREIGN KEY ([Assigneekey])		REFERENCES [dbo].[User] ([userId]),
  CONSTRAINT [FK_Ticket_FeatureKey]		FOREIGN KEY ([featureId])		REFERENCES [dbo].[Feature] ([featureId]),
  CONSTRAINT [FK_Ticket_ReporterKey]	FOREIGN KEY ([ReporterKey])		REFERENCES [dbo].[User] ([userId])
)