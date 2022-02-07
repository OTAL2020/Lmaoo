CREATE TABLE [dbo].[Comment]
(
  [CommentId]		 INT			NOT NULL	IDENTITY(1,1),
  [Content]			 VARCHAR(255)   NOT NULL,
  [Created]			 DATETIME		NOT NULL	DEFAULT CURRENT_TIMESTAMP,
  [TicketId]		 INT			NOT NULL,
  [UserId]			 INT			NULL,

  CONSTRAINT [PK_Comment_CommentId]	PRIMARY KEY ([CommentId]),
  CONSTRAINT [FK_Comment_TicketId]	FOREIGN KEY ([TicketId])	REFERENCES [dbo].[Ticket] ([TicketId]),
  CONSTRAINT [FK_Comment_UserId]	FOREIGN KEY ([UserId])		REFERENCES [dbo].[User] ([UserId])
);