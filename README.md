# CryptoChat
Tiny chat written with C# and Blazor. It's not user-friendly at all yet, but idea behind it is to learn more about how Blazor works and what are it's limitations. It currently deployed at https://7342915.529473-cx47623.tmweb.ru
## Structure
Solution consists of 3 projects: Client, Server and Share
#### Client
Contains all frontend logic.

`Storage.cs` is supposed to be the global event listener and state manager. It is injected into components and pages as singleton named `Global`.

`Components` folder contains all components such as input field combined with button. All of components use isolated CSS styling.

Currently there is only one page - `Messenger.razor` which implements all modals, components and logic.

Client connects to the server over __SignalR__.

#### Server
Backend and deployment project, it is build on WebApi pattern and uses __SignalR__ service with only one hub.

#### Shared
This project is supposed to carry all the models of solution, it is used as dependency in both Client and Server projects.
