#### Database-interactie

Er wordt gebruik gemaakt van Microsoft SQL Server in een docker container die wordt gedraaid op een virtuele machine die die vervolgens draait op Ubuntu. Deze virtuele machine staat vervolgens op het zogenaamde SkyLab van Windesheim. Hoe het Skylab precies in elkaar zit staat vermeld in de onderstaande afbeelding. 

![Imgur](https://i.imgur.com/X7ayy8k.png)

##### Repository

![Imgur](https://i.imgur.com/hPhaAZb.png)

Het hoofdprogramma interacteert niet direct met de database, maar met de Repository-laag. Deze heeft vervolgens weer een link naar Entity Framework (EF), dat de database bijgewerkt. Door het op deze manier te doen hoeft dezelfde query maar één keer in de code hoeft te staan, namelijk in een herbruikbare methode in de Repository-laag.

Deze laag bestaat uit twee delen: het Repository Pattern en het UnitOfWork Pattern. Het Repository is een opslag van objecten in het geheugen. Het UnitOfWork zorgt voor de opslag van deze objecten in de database.

Er staat in de classes in Repository een aantal methodes die nog niet geïmplementeerd zijn. Deze staan er wel omdat ze idealiter wel gebruikt worden. In de toekomst zouden deze methodes ervoor zorgen dat de Entities van EF niet voorbij Repository komen om de hoofdcode onafhankelijk te maken van EF. Dit is op dit moment nog niet gedaan omdat andere backlogitems prioriteit hadden.

###### Code

De figuur is een export vanuit Visual Studio. Zie de pijlen onder de naam van de class voor de overerving. Zie de tekst naast het rondje boven de classes voor de interface implementaties.

![Imgur](https://i.imgur.com/Ql99l3L.png)

##### Entity Framework

Entity Framework
Voor de directe manipulatie van de database wordt Entity Framework (EF) gebruikt. Zie de Microsoft documentatie [hier](https://docs.microsoft.com/en-us/ef/core/) voor een introductie. Dit maakt het makkelijk om objecten in de database op te slaan. Ook stelt EF de ontwikkelaars in staat om gegevens uit de database snel en efficiënt op te vragen met gebruikt van LINQ. Als gevolg hiervan gaat de ontwikkelingstijd omlaag. EF wordt code-first gebruikt zodat de database makkelijk en snel te onderhouden en aan te passen is op basis van de code. De onderdelen in de code die voor EF gebruikt worden staan in het project TypTop.Database.

Delen van de huidige opslag worden nog niet gebruikt in de applicatie. De teacher-velden in User en de tabel UserLevels bijvoorbeeld. Deze onderdelen zijn nodig voor geplande functionaliteiten.

###### Code

De figuur is een export vanuit Visual Studio. Zie de pijlen onder de naam van de class voor de overerving.

![Imgur](https://i.imgur.com/IUv4rDl.png)

