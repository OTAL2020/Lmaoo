CREATE TABLE [dbo].[Ticket]
(
  [TicketId]	INT				NOT NULL	IDENTITY(1,1),
  [Summary]		VARCHAR(50)		NOT NULL,
  [FeatureId]	INT				NOT NULL,
  [ReporterKey] INT				DEFAULT		NULL,
  [AssigneeKey] INT				DEFAULT		NULL,
  [Created]		DATETIME		NOT NULL	DEFAULT CURRENT_TIMESTAMP,
  [Updated]		DATETIME		NOT NULL,
  [Progress]	VARCHAR(20)		NOT NULL	DEFAULT 'Open',
  [Deadline]	DATETIME		NULL DEFAULT NULL,
  PRIMARY KEY (TicketId),

  CONSTRAINT [FK_Ticket_AssigneeKey]	FOREIGN KEY ([Assigneekey])		REFERENCES [dbo].[User] ([userId]),
  CONSTRAINT [FK_Ticket_FeatureKey]		FOREIGN KEY ([featureId])		REFERENCES [dbo].[Feature] ([featureId]),
  CONSTRAINT [FK_Ticket_ReporterKey]	FOREIGN KEY ([ReporterKey])		REFERENCES [dbo].[User] ([userId])
)