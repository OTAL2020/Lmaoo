CREATE TABLE [dbo].[Comment]
(
  [CommentId]		 int			NOT NULL	IDENTITY(1,1),
  [CommentContent]	 varchar(255)   NOT NULL,
  [CommentCreated]   timestamp		NOT NULL	DEFAULT CURRENT_TIMESTAMP,
  [TicketId]		 int DEFAULT	NULL,
  [UserId]			 int DEFAULT	NULL,

  PRIMARY KEY ([commentId]),

  CONSTRAINT [PK_Comment_TicketId]	FOREIGN KEY ([ticketId])	REFERENCES [dbo].[Ticket] ([TicketId]),
  CONSTRAINT [FK_Comment_UserId]	FOREIGN KEY ([UserId])		REFERENCES [dbo].[User] ([userId])
);