# TypTop
In dit document zijn de technische ontwerp keuzes de ontwikkelaars van TypTop vastgelegd. Om een duidelijk beeld te geven, wordt gebruik gemaakt van het [C4 model](https://c4model.com/). Aangezien TypTop een losstaande applicatie is, wordt niveau 1, de [systeem context](https://c4model.com/#SystemContextDiagram), overgeslagen.

### Inhoudsopgave
- [Inleiding](#TypTop)
   - [Wat is TypTop?](#Wat-is-TypTop)
   - [Leeswijzer](#Leeswijzer)
- [Containers](#Containers)
   - [TypTop Applicatie](#TypTop-Applicatie)
      - [GameEngine](#GameEngine)
      - [Minigames](#Minigames)
      - [Levels en Werelden](#Levels-en-Werelden)
      - [GUI](#GUI)
      - [Logica](#Logica)
   - [Database](#Database)

### Wat is TypTop?
In het kort, TypTop is een applicatie om kinderen te voorzien van een typecursus waarbij de focus ligt op de plezierervaring. Daarom zal deze cursus bestaan uit verschillende onderdelen, het voornaamste deel bestaat uit minigames. De minigames zijn opgedeeld in werelden, binnen één wereld kan alleen één soort minigame voorkomen. Deze specifieke minigame wordt vervolgens aangeboden in verschillende levels met daarin variaties in moeilijkheidsgraad.
Voor meer informatie wordt aangeraden om het [functioneel ontwerp](https://drive.google.com/open?id=1qqM9IFvPuHZJvfruBH2EnciZkMkmVayF5MyXXwGspPk) te raadplegen om een beter inzicht te geven wat de doelen zijn van deze applicatie.

### Leeswijzer
Beschrijving voor:
- Algemene structuur
- Minigame programmeurs
- Level/Wereldmap programmeurs
- Logica ontwerpers

## Containers
[Diagram]
[Korte beschrijving Diagram]

### TypTop Applicatie
[Project Diagram]

Bovenstaand diagram bevat alle referencies tussen de projecten in de solution TypTop. De volgende projecten hiervan zijn uitgebreider gedocumenteerd.
- GameEngine
   - TypTop.GameEngine
   - TypTop.GameWindow
- Minigames
   - TypTop.Minigame
   - TypTop.TavernMinigame
   - TypTop.SpaceMinigame
   - TypTop.JumpMinigame
- Levels en Werelden
   - TypTop.WorldScreen
   - TypTop.LevelScreen
- GUI
   - TypTop.GameGui
   - TypTop.LoginGui
- Logica
   - TypTop.Database
   - TypTop.Repository
   - TypTop.Logic

#### GameEngine
##### TypTop.GameEngine
##### TypTop.GameWindow
##### TypTop.GameGui

#### Minigames
##### TypTop.Minigame
##### TypTop.TavernMinigame
##### TypTop.SpaceMinigame
##### TypTop.JumpMinigame

#### Levels en Werelden
##### TypTop.WorldScreen
##### TypTop.LevelScreen

#### GUI
##### TypTop.GameGui
##### TypTop.LoginGui

#### Logica
##### TypTop.Database
##### TypTop.Repository
##### TypTop.Logic


### Database
[ERD]
