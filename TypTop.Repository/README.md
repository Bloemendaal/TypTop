##### Repository

![Imgur](https://i.imgur.com/hPhaAZb.png)

Het hoofdprogramma interacteert niet direct met de database, maar met de Repository-laag. Deze heeft vervolgens weer een link naar Entity Framework (EF), dat de database bijgewerkt. Door het op deze manier te doen hoeft dezelfde query maar één keer in de code hoeft te staan, namelijk in een herbruikbare methode in de Repository-laag.

Deze laag bestaat uit twee delen: het Repository Pattern en het UnitOfWork Pattern. Het Repository is een opslag van objecten in het geheugen. Het UnitOfWork zorgt voor de opslag van deze objecten in de database.

Er staat in de classes in Repository een aantal methodes die nog niet geïmplementeerd zijn. Deze staan er wel omdat ze idealiter wel gebruikt worden. In de toekomst zouden deze methodes ervoor zorgen dat de Entities van EF niet voorbij Repository komen om de hoofdcode onafhankelijk te maken van EF. Dit is op dit moment nog niet gedaan omdat andere backlogitems prioriteit hadden.

###### Code

De figuur is een export vanuit Visual Studio. Zie de pijlen onder de naam van de class voor de overerving. Zie de tekst naast het rondje boven de classes voor de interface implementaties.

![Imgur](https://i.imgur.com/Ql99l3L.png)