# MultiClient-Server-Chat
This is a Multi-Client Chatting WinForm Project, written in C# .NET 9.0. The full project is divided into two parts: Client (WinForm Application) and Server (Console Application), and is further divided into different Classes for specific functions and procedures.

Overall, this uses TCP Sockets to establish a connection between the Client and Server. The data Sent/received by the Client/Server is in a unique format, as the ClientClient/Server understands how to process Data. Both Client and server haves a Class to handle uniquely formatted Data.
The Connection and Data Communication is asynchronous, therefore the Client and server do not pause for a single task.

# How it Works
1. Run the Server. The Server starts listening for the clients's SOCKET.
2. If the clients join it will add that client to a dictionary. And Broadcast to everyone Client joins if there is someone already.
3. Server runs an async task for any data transfer
4. Then The Data is processed by the PacketHandler/PacketReader/PacketWriter.
5. Repeats.

This Program is not fully functional. There may be Bugs and errors.

If Anyone is interested to sending any feedback, feel free to do so.
