<a name='assembly'></a>
# TypTop.TavernMinigame

## Contents

- [Customer](#T-TypTop-TavernMinigame-Customer 'TypTop.TavernMinigame.Customer')
  - [OriginalCount](#F-TypTop-TavernMinigame-Customer-OriginalCount 'TypTop.TavernMinigame.Customer.OriginalCount')
  - [_orders](#F-TypTop-TavernMinigame-Customer-_orders 'TypTop.TavernMinigame.Customer._orders')
  - [Count](#P-TypTop-TavernMinigame-Customer-Count 'TypTop.TavernMinigame.Customer.Count')
  - [AddEntities()](#M-TypTop-TavernMinigame-Customer-AddEntities 'TypTop.TavernMinigame.Customer.AddEntities')
  - [GetOrder(orderType)](#M-TypTop-TavernMinigame-Customer-GetOrder-TypTop-TavernMinigame-Order-OrderType- 'TypTop.TavernMinigame.Customer.GetOrder(TypTop.TavernMinigame.Order.OrderType)')
  - [HasOrder(order)](#M-TypTop-TavernMinigame-Customer-HasOrder-TypTop-TavernMinigame-Order- 'TypTop.TavernMinigame.Customer.HasOrder(TypTop.TavernMinigame.Order)')
  - [HasOrder(order)](#M-TypTop-TavernMinigame-Customer-HasOrder-TypTop-TavernMinigame-Order-OrderType- 'TypTop.TavernMinigame.Customer.HasOrder(TypTop.TavernMinigame.Order.OrderType)')
  - [RemoveEntities(score)](#M-TypTop-TavernMinigame-Customer-RemoveEntities-System-Int32- 'TypTop.TavernMinigame.Customer.RemoveEntities(System.Int32)')
  - [RemoveOrder(order)](#M-TypTop-TavernMinigame-Customer-RemoveOrder-TypTop-TavernMinigame-Order- 'TypTop.TavernMinigame.Customer.RemoveOrder(TypTop.TavernMinigame.Order)')
  - [UpdateOrderPosition()](#M-TypTop-TavernMinigame-Customer-UpdateOrderPosition 'TypTop.TavernMinigame.Customer.UpdateOrderPosition')
  - [UpdatePosition(index)](#M-TypTop-TavernMinigame-Customer-UpdatePosition-System-Int32- 'TypTop.TavernMinigame.Customer.UpdatePosition(System.Int32)')
- [CustomerQueue](#T-TypTop-TavernMinigame-CustomerQueue 'TypTop.TavernMinigame.CustomerQueue')
  - [Count](#P-TypTop-TavernMinigame-CustomerQueue-Count 'TypTop.TavernMinigame.CustomerQueue.Count')
  - [UpdateCount()](#M-TypTop-TavernMinigame-CustomerQueue-UpdateCount 'TypTop.TavernMinigame.CustomerQueue.UpdateCount')
- [CustomerType](#T-TypTop-TavernMinigame-Customer-CustomerType 'TypTop.TavernMinigame.Customer.CustomerType')
- [Order](#T-TypTop-TavernMinigame-Order 'TypTop.TavernMinigame.Order')
  - [Type](#P-TypTop-TavernMinigame-Order-Type 'TypTop.TavernMinigame.Order.Type')
- [OrderType](#T-TypTop-TavernMinigame-Order-OrderType 'TypTop.TavernMinigame.Order.OrderType')
- [Satisfaction](#T-TypTop-TavernMinigame-Satisfaction 'TypTop.TavernMinigame.Satisfaction')
  - [Amount](#P-TypTop-TavernMinigame-Satisfaction-Amount 'TypTop.TavernMinigame.Satisfaction.Amount')
  - [Dispose()](#M-TypTop-TavernMinigame-Satisfaction-Dispose 'TypTop.TavernMinigame.Satisfaction.Dispose')
  - [SetInterval()](#M-TypTop-TavernMinigame-Satisfaction-SetInterval 'TypTop.TavernMinigame.Satisfaction.SetInterval')
  - [UpdateImage()](#M-TypTop-TavernMinigame-Satisfaction-UpdateImage 'TypTop.TavernMinigame.Satisfaction.UpdateImage')
- [TavernGame](#T-TypTop-TavernMinigame-TavernGame 'TypTop.TavernMinigame.TavernGame')
  - [DefaultTypeface](#F-TypTop-TavernMinigame-TavernGame-DefaultTypeface 'TypTop.TavernMinigame.TavernGame.DefaultTypeface')
  - [_customers](#F-TypTop-TavernMinigame-TavernGame-_customers 'TypTop.TavernMinigame.TavernGame._customers')
  - [_inputList](#F-TypTop-TavernMinigame-TavernGame-_inputList 'TypTop.TavernMinigame.TavernGame._inputList')
  - [_satisfactionTiming](#F-TypTop-TavernMinigame-TavernGame-_satisfactionTiming 'TypTop.TavernMinigame.TavernGame._satisfactionTiming')
  - [_tiles](#F-TypTop-TavernMinigame-TavernGame-_tiles 'TypTop.TavernMinigame.TavernGame._tiles')
  - [_timer](#F-TypTop-TavernMinigame-TavernGame-_timer 'TypTop.TavernMinigame.TavernGame._timer')
  - [_words](#F-TypTop-TavernMinigame-TavernGame-_words 'TypTop.TavernMinigame.TavernGame._words')
  - [CustomerMaxOrderAmount](#P-TypTop-TavernMinigame-TavernGame-CustomerMaxOrderAmount 'TypTop.TavernMinigame.TavernGame.CustomerMaxOrderAmount')
  - [CustomerMinOrderAmount](#P-TypTop-TavernMinigame-TavernGame-CustomerMinOrderAmount 'TypTop.TavernMinigame.TavernGame.CustomerMinOrderAmount')
  - [CustomerSpawnSpeed](#P-TypTop-TavernMinigame-TavernGame-CustomerSpawnSpeed 'TypTop.TavernMinigame.TavernGame.CustomerSpawnSpeed')
  - [CustomerSpawnSpeedMultiplier](#P-TypTop-TavernMinigame-TavernGame-CustomerSpawnSpeedMultiplier 'TypTop.TavernMinigame.TavernGame.CustomerSpawnSpeedMultiplier')
  - [CustomerSpawnSpeedOffset](#P-TypTop-TavernMinigame-TavernGame-CustomerSpawnSpeedOffset 'TypTop.TavernMinigame.TavernGame.CustomerSpawnSpeedOffset')
  - [MaxCustomers](#P-TypTop-TavernMinigame-TavernGame-MaxCustomers 'TypTop.TavernMinigame.TavernGame.MaxCustomers')
  - [ShowSatisfaction](#P-TypTop-TavernMinigame-TavernGame-ShowSatisfaction 'TypTop.TavernMinigame.TavernGame.ShowSatisfaction')
  - [StartSatisfaction](#P-TypTop-TavernMinigame-TavernGame-StartSatisfaction 'TypTop.TavernMinigame.TavernGame.StartSatisfaction')
  - [TileAmount](#P-TypTop-TavernMinigame-TavernGame-TileAmount 'TypTop.TavernMinigame.TavernGame.TileAmount')
  - [AddCustomer(customer)](#M-TypTop-TavernMinigame-TavernGame-AddCustomer-TypTop-TavernMinigame-Customer- 'TypTop.TavernMinigame.TavernGame.AddCustomer(TypTop.TavernMinigame.Customer)')
  - [CustomerIndex(customer)](#M-TypTop-TavernMinigame-TavernGame-CustomerIndex-TypTop-TavernMinigame-Customer- 'TypTop.TavernMinigame.TavernGame.CustomerIndex(TypTop.TavernMinigame.Customer)')
  - [GetOrder(amount)](#M-TypTop-TavernMinigame-TavernGame-GetOrder-System-Int32- 'TypTop.TavernMinigame.TavernGame.GetOrder(System.Int32)')
  - [GetSatisfaction(key)](#M-TypTop-TavernMinigame-TavernGame-GetSatisfaction-System-Int32- 'TypTop.TavernMinigame.TavernGame.GetSatisfaction(System.Int32)')
  - [NextCustomer()](#M-TypTop-TavernMinigame-TavernGame-NextCustomer 'TypTop.TavernMinigame.TavernGame.NextCustomer')
  - [OnTextInput(sender,e)](#M-TypTop-TavernMinigame-TavernGame-OnTextInput-System-Object,System-Windows-Input-TextCompositionEventArgs- 'TypTop.TavernMinigame.TavernGame.OnTextInput(System.Object,System.Windows.Input.TextCompositionEventArgs)')
  - [RemoveCustomer(customer)](#M-TypTop-TavernMinigame-TavernGame-RemoveCustomer-TypTop-TavernMinigame-Customer- 'TypTop.TavernMinigame.TavernGame.RemoveCustomer(TypTop.TavernMinigame.Customer)')
  - [UpdateWordlist()](#M-TypTop-TavernMinigame-TavernGame-UpdateWordlist 'TypTop.TavernMinigame.TavernGame.UpdateWordlist')
- [Tile](#T-TypTop-TavernMinigame-Tile 'TypTop.TavernMinigame.Tile')
  - [HeightOffset](#F-TypTop-TavernMinigame-Tile-HeightOffset 'TypTop.TavernMinigame.Tile.HeightOffset')
  - [Width](#F-TypTop-TavernMinigame-Tile-Width 'TypTop.TavernMinigame.Tile.Width')
  - [WidthOffset](#F-TypTop-TavernMinigame-Tile-WidthOffset 'TypTop.TavernMinigame.Tile.WidthOffset')

<a name='T-TypTop-TavernMinigame-Customer'></a>
## Customer `type`

##### Namespace

TypTop.TavernMinigame

<a name='F-TypTop-TavernMinigame-Customer-OriginalCount'></a>
### OriginalCount `constants`

##### Summary

Original amount of orders the customer had.

<a name='F-TypTop-TavernMinigame-Customer-_orders'></a>
### _orders `constants`

##### Summary

Customer's orders

<a name='P-TypTop-TavernMinigame-Customer-Count'></a>
### Count `property`

##### Summary

The amount of orders left to be served.

<a name='M-TypTop-TavernMinigame-Customer-AddEntities'></a>
### AddEntities() `method`

##### Summary

Voegt alle benodigde entities (Order’s, SpeechBubble, this) aan game toe.

##### Parameters

This method has no parameters.

<a name='M-TypTop-TavernMinigame-Customer-GetOrder-TypTop-TavernMinigame-Order-OrderType-'></a>
### GetOrder(orderType) `method`

##### Summary

Geeft een Order terug wanneer de OrderType overeenkomt. Pakt altijd de eerste van de lijst _orders als er meerdere zijn.

##### Returns

Geeft een Order terug wanneer de OrderType overeenkomt.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| orderType | [TypTop.TavernMinigame.Order.OrderType](#T-TypTop-TavernMinigame-Order-OrderType 'TypTop.TavernMinigame.Order.OrderType') | OrderType dat gecontroleerd moet worden. |

<a name='M-TypTop-TavernMinigame-Customer-HasOrder-TypTop-TavernMinigame-Order-'></a>
### HasOrder(order) `method`

##### Summary

Geeft terug of de Customer de specifieke Order heeft.

##### Returns

Geeft terug of de Customer de specifieke Order heeft.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| order | [TypTop.TavernMinigame.Order](#T-TypTop-TavernMinigame-Order 'TypTop.TavernMinigame.Order') | Order dat gecontroleerd moet worden. |

<a name='M-TypTop-TavernMinigame-Customer-HasOrder-TypTop-TavernMinigame-Order-OrderType-'></a>
### HasOrder(order) `method`

##### Summary

Geeft terug of de Customer de specifieke Order heeft.

##### Returns

Geeft terug of de Customer de specifieke Order heeft.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| order | [TypTop.TavernMinigame.Order.OrderType](#T-TypTop-TavernMinigame-Order-OrderType 'TypTop.TavernMinigame.Order.OrderType') | Order dat gecontroleerd moet worden. |

<a name='M-TypTop-TavernMinigame-Customer-RemoveEntities-System-Int32-'></a>
### RemoveEntities(score) `method`

##### Summary

Verwijdert alle entities die verwant zijn aan de Customer.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| score | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Voegt deze score toe aan de huidige score. |

<a name='M-TypTop-TavernMinigame-Customer-RemoveOrder-TypTop-TavernMinigame-Order-'></a>
### RemoveOrder(order) `method`

##### Summary

Verwijdert een specifieke Order uit _orders. Roept UpdateOrderPosition() aan.

##### Returns

Geeft terug of het verwijderen succesvol was.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| order | [TypTop.TavernMinigame.Order](#T-TypTop-TavernMinigame-Order 'TypTop.TavernMinigame.Order') | Order dat verwijdert moet worden. |

<a name='M-TypTop-TavernMinigame-Customer-UpdateOrderPosition'></a>
### UpdateOrderPosition() `method`

##### Summary

Werkt de posities van de Order’s in _orders bij.

##### Parameters

This method has no parameters.

<a name='M-TypTop-TavernMinigame-Customer-UpdatePosition-System-Int32-'></a>
### UpdatePosition(index) `method`

##### Summary

Werkt de posities van de Customer en de SpeechBubble bij. Roept daarna de UpdateOrderPosition() method aan.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| index | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Index van de rij waarin de Customer staat. |

<a name='T-TypTop-TavernMinigame-CustomerQueue'></a>
## CustomerQueue `type`

##### Namespace

TypTop.TavernMinigame

<a name='P-TypTop-TavernMinigame-CustomerQueue-Count'></a>
### Count `property`

##### Summary

Amount of customers in the queue.

<a name='M-TypTop-TavernMinigame-CustomerQueue-UpdateCount'></a>
### UpdateCount() `method`

##### Summary

Visually update the amount of customers in the queue.

##### Parameters

This method has no parameters.

<a name='T-TypTop-TavernMinigame-Customer-CustomerType'></a>
## CustomerType `type`

##### Namespace

TypTop.TavernMinigame.Customer

##### Summary

List of all available unique customers.

<a name='T-TypTop-TavernMinigame-Order'></a>
## Order `type`

##### Namespace

TypTop.TavernMinigame

<a name='P-TypTop-TavernMinigame-Order-Type'></a>
### Type `property`

##### Summary

Type of this order.

<a name='T-TypTop-TavernMinigame-Order-OrderType'></a>
## OrderType `type`

##### Namespace

TypTop.TavernMinigame.Order

##### Summary

List of all available unique orders.

<a name='T-TypTop-TavernMinigame-Satisfaction'></a>
## Satisfaction `type`

##### Namespace

TypTop.TavernMinigame

<a name='P-TypTop-TavernMinigame-Satisfaction-Amount'></a>
### Amount `property`

##### Summary

Amount of satisfaction the Customer has. Value from 0 - 5 where 0 will result in the customer leaving.

<a name='M-TypTop-TavernMinigame-Satisfaction-Dispose'></a>
### Dispose() `method`

##### Summary

Dispose the satisfactiontimer. Do not remove a Customer or Satisfaction class from the game without disposing.

##### Parameters

This method has no parameters.

<a name='M-TypTop-TavernMinigame-Satisfaction-SetInterval'></a>
### SetInterval() `method`

##### Summary

Reset the interval to the current amount of satisfaction.

##### Parameters

This method has no parameters.

<a name='M-TypTop-TavernMinigame-Satisfaction-UpdateImage'></a>
### UpdateImage() `method`

##### Summary

Update the satisfactionimage to match the amount.

##### Parameters

This method has no parameters.

<a name='T-TypTop-TavernMinigame-TavernGame'></a>
## TavernGame `type`

##### Namespace

TypTop.TavernMinigame

<a name='F-TypTop-TavernMinigame-TavernGame-DefaultTypeface'></a>
### DefaultTypeface `constants`

##### Summary

Standaard font dat gebruikt moet worden in de hele Tavern minigame, MV Boli.

<a name='F-TypTop-TavernMinigame-TavernGame-_customers'></a>
### _customers `constants`

##### Summary

Lijst met Customer’s die zichtbaar zijn in de taverne.

<a name='F-TypTop-TavernMinigame-TavernGame-_inputList'></a>
### _inputList `constants`

##### Summary

InputList uit TypTop.Logic die gebruikt wordt om de input van de gebruiker te analyseren. FocusOnHighIndex staat op true. De woordenlijst wordt pas meegegeven wanneer de method UpdateWordlist() aangeroepen wordt.

<a name='F-TypTop-TavernMinigame-TavernGame-_satisfactionTiming'></a>
### _satisfactionTiming `constants`

##### Summary

Tijden in milliseconden waarin waarin de Customer’s bozer worden. Eerste int, TKey, is de satisfaction. Tweede int, TValue, is het aantal milliseconden. Standaardwaardes per satisfaction is 0 milliseconden (geen timer ingesteld, satisfaction kan dus niet verspringen).

<a name='F-TypTop-TavernMinigame-TavernGame-_tiles'></a>
### _tiles `constants`

##### Summary

Lijst met alle Tile’s erin. Wordt gerenderd wanneer het TileAmount geset wordt.

<a name='F-TypTop-TavernMinigame-TavernGame-_timer'></a>
### _timer `constants`

##### Summary

Timer die nodig is om Customer’s toe te voegen aan de rij.

<a name='F-TypTop-TavernMinigame-TavernGame-_words'></a>
### _words `constants`

##### Summary

Lijst met Word’s die gebruikt kan worden door de Tiles.

<a name='P-TypTop-TavernMinigame-TavernGame-CustomerMaxOrderAmount'></a>
### CustomerMaxOrderAmount `property`

##### Summary

Maximum amount of orders a customer has to take.

<a name='P-TypTop-TavernMinigame-TavernGame-CustomerMinOrderAmount'></a>
### CustomerMinOrderAmount `property`

##### Summary

Minimum amount of orders a customer has to take.

<a name='P-TypTop-TavernMinigame-TavernGame-CustomerSpawnSpeed'></a>
### CustomerSpawnSpeed `property`

##### Summary

Every amount of milliseconds a customer should spawn.

<a name='P-TypTop-TavernMinigame-TavernGame-CustomerSpawnSpeedMultiplier'></a>
### CustomerSpawnSpeedMultiplier `property`

##### Summary

Multiply the spawnspeed of the customers with 1 + (x * [amount of customers in the queue])

<a name='P-TypTop-TavernMinigame-TavernGame-CustomerSpawnSpeedOffset'></a>
### CustomerSpawnSpeedOffset `property`

##### Summary

Maximum offset that is used when generating random spawn speeds in both directions.

<a name='P-TypTop-TavernMinigame-TavernGame-MaxCustomers'></a>
### MaxCustomers `property`

##### Summary

Maximaal aantal Customer’s dat in de taverne getekend wordt voordat ze in de CustomerQueue gestopt worden. Minimaal aantal is 0, maximaal is aanbevolen 3 omdat de rest (deels) buiten het scherm gerenderd wordt.

<a name='P-TypTop-TavernMinigame-TavernGame-ShowSatisfaction'></a>
### ShowSatisfaction `property`

##### Summary

Geef de satisfaction van een Customer weer. Standaardwaarde is false.

<a name='P-TypTop-TavernMinigame-TavernGame-StartSatisfaction'></a>
### StartSatisfaction `property`

##### Summary

Waarde tussen 1 en 5 waarop de Customer’s satisfaction standaard ingesteld staat. Standaardwaarde is 5.

<a name='P-TypTop-TavernMinigame-TavernGame-TileAmount'></a>
### TileAmount `property`

##### Summary

Minimale waarde is 1, maximale waarde is de lengte van het aantal OrderType’s. Wanneer deze property geset wordt, worden de Tiles willekeurig gegenereerd tot een lijst _tiles.

<a name='M-TypTop-TavernMinigame-TavernGame-AddCustomer-TypTop-TavernMinigame-Customer-'></a>
### AddCustomer(customer) `method`

##### Summary

Add customer to _customers unless it exceeds MaxCustomers. In that case it is added to _customerQueue.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| customer | [TypTop.TavernMinigame.Customer](#T-TypTop-TavernMinigame-Customer 'TypTop.TavernMinigame.Customer') | Customer to be added. |

<a name='M-TypTop-TavernMinigame-TavernGame-CustomerIndex-TypTop-TavernMinigame-Customer-'></a>
### CustomerIndex(customer) `method`

##### Summary

Geeft de index van de Customer in _customers.

##### Returns

Geeft de index van de Customer in _customers.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| customer | [TypTop.TavernMinigame.Customer](#T-TypTop-TavernMinigame-Customer 'TypTop.TavernMinigame.Customer') | Customer to be checked. |

<a name='M-TypTop-TavernMinigame-TavernGame-GetOrder-System-Int32-'></a>
### GetOrder(amount) `method`

##### Summary

Geeft een lijst met amount aantal willekeurige Order’s erin.

##### Returns

Geeft een lijst met amount aantal willekeurige Order’s erin.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| amount | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Aantal willekeurige Order's. |

<a name='M-TypTop-TavernMinigame-TavernGame-GetSatisfaction-System-Int32-'></a>
### GetSatisfaction(key) `method`

##### Summary

Get the amount of milliseconds for a certain satisfaction.

##### Returns

Time in milliseconds.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Satisfaction (0 - 5) |

<a name='M-TypTop-TavernMinigame-TavernGame-NextCustomer'></a>
### NextCustomer() `method`

##### Summary

Schuift de complete rij Customer’s een plekje door.

##### Returns

Geeft terug of dit gelukt is.

##### Parameters

This method has no parameters.

<a name='M-TypTop-TavernMinigame-TavernGame-OnTextInput-System-Object,System-Windows-Input-TextCompositionEventArgs-'></a>
### OnTextInput(sender,e) `method`

##### Summary

Controleert de input van de leerling. Controleert voor elke Customer of een Order afgehandeld is door die input en ook of de Customer volledig geholpen is. Een Word wordt verwijdert uit _words en de method UpdateWordlist() wordt aangeroepen wanneer een Word volledig goed getypt is.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| e | [System.Windows.Input.TextCompositionEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Input.TextCompositionEventArgs 'System.Windows.Input.TextCompositionEventArgs') |  |

<a name='M-TypTop-TavernMinigame-TavernGame-RemoveCustomer-TypTop-TavernMinigame-Customer-'></a>
### RemoveCustomer(customer) `method`

##### Summary

Verwijdert een Customer uit _customers en werkt de posities van alle Customer’s in _customers daarna bij. Daarna wordt de method UpdateWordlist() aangeroepen.

##### Returns

Geeft terug of het verwijderen gelukt is.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| customer | [TypTop.TavernMinigame.Customer](#T-TypTop-TavernMinigame-Customer 'TypTop.TavernMinigame.Customer') | Customer to be removed. |

<a name='M-TypTop-TavernMinigame-TavernGame-UpdateWordlist'></a>
### UpdateWordlist() `method`

##### Summary

Werkt de woordenlijst van _inputList bij zodat deze overeenkomt met de wensen van de Customer’s. Word’s op Tile’s die niet gevraagd worden door Customer’s, worden hierdoor niet geaccepteerd als input.

##### Parameters

This method has no parameters.

<a name='T-TypTop-TavernMinigame-Tile'></a>
## Tile `type`

##### Namespace

TypTop.TavernMinigame

<a name='F-TypTop-TavernMinigame-Tile-HeightOffset'></a>
### HeightOffset `constants`

##### Summary

Heigth offset of the Order that is drawn on top of the Tile.

<a name='F-TypTop-TavernMinigame-Tile-Width'></a>
### Width `constants`

##### Summary

Width of the tile.

<a name='F-TypTop-TavernMinigame-Tile-WidthOffset'></a>
### WidthOffset `constants`

##### Summary

Width offset of the Order that is drawn on top of the Tile.
