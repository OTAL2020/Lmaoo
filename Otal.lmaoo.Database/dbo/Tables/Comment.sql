CREATE TABLE [dbo].[Comment]
(
  [CommentId]		 int			NOT NULL	IDENTITY(1,1),
  [CommentContent]	 varchar(255)   NOT NULL,
  [TicketId]		 int DEFAULT	NULL,
  [UserId]			 int DEFAULT	NULL,
  [CommentCreated]   datetime		NOT NULL	DEFAULT CURRENT_TIMESTAMP,

  PRIMARY KEY ([commentId]),

  CONSTRAINT [PK_Comment_TicketId]	FOREIGN KEY ([TicketId])	REFERENCES [dbo].[Ticket] ([TicketId]),
  CONSTRAINT [FK_Comment_UserId]	FOREIGN KEY ([UserId])		REFERENCES [dbo].[User] ([userId])
);