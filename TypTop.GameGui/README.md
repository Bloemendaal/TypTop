#### GameGui
![Imgur](https://i.imgur.com/jRxQReU.png)

GameGui is het venster waar de GameWindow control in draait. GameWindow is geïmplementeerd als een WPF control. Dit maakt het mogelijk om de GameWindow als content voor een ViewBox te gebruiken. De integratie met de ViewBox is belangrijk, omdat die de game kan schalen naar de juiste resolutie.

Omdat de GameWindow geïmplementeerd is als Control, worden de Input events alleen afgevangen als de GameWindow de gefocuste control is. Dit is niet altijd het geval, daarom wordt de Input afgevangen in de GameGui en doorgestuurd naar de GameWindow. Deze stuurt het vervolgens weer naar de geladen game.

GameGui bevat ook de GameLoader class. Deze class heeft een referentie naar de GameWindow en is verantwoordelijk voor het schakelen tussen verschillende games.