#### Shared

Het Shared project bestaat om circular dependencies te voorkomen. Dingen die vrij onafhankelijk zijn en door meerdere projecten moeten worden gebruikt, worden hierin geplaatst. Als ze in een normaal project A geplaatst zouden worden en dit project is al afhankelijk van project B, dan kan project B er geen gebruik van maken.

Op dit moment staan er drie elementen in Shared:
- De enum WinConditionType
- De class Settings
- De class ContextFactory
