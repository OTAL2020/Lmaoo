CREATE TABLE [dbo].[Comment]
(
  [CommentId]		 INT			NOT NULL	IDENTITY(1,1),
  [CommentContent]	 VARCHAR(255)   NOT NULL,
  [CommentCreated]   DATETIME		NOT NULL	DEFAULT CURRENT_TIMESTAMP,
  [TicketId]		 INT			DEFAULT		NULL,
  [UserId]			 INT			DEFAULT		NULL,

  CONSTRAINT [PK_Comment_CommentId]	PRIMARY KEY ([CommentId]),

  CONSTRAINT [FK_Comment_TicketId]	FOREIGN KEY ([TicketId])	REFERENCES [dbo].[Ticket] ([TicketId]),
  CONSTRAINT [FK_Comment_UserId]	FOREIGN KEY ([UserId])		REFERENCES [dbo].[User] ([userId])
);