CREATE TABLE [dbo].[Comment] 
(
  [commentId]		int			 NOT NULL	IDENTITY,
  [commentContent]  varchar(255) NOT NULL,
  [commentCreated]  datetime2	 NOT NULL	DEFAULT GETDATE(),
  [ticketId]		int DEFAULT  NULL,
  [userId]			int DEFAULT  NULL,

  PRIMARY KEY ([commentId]),
  
  CONSTRAINT [FK_TicketId]  FOREIGN KEY ([TicketId])	REFERENCES [dbo].[Ticket] ([ticketId]),
  CONSTRAINT [FK_UserId]	FOREIGN KEY ([UserId])		REFERENCES [dbo].[User]  ([userId])
)