#### Login GUI

![Imgur](https://i.imgur.com/LDyb2bD.png)

LoginGui is de launcher van TypTop. De functie van het component is het behandelen van account creatie en inloggen, hiervoor communiceert het met Repository. Als er is ingelogd opent het een GameGui MainWindow.

##### Code

![Imgur](https://i.imgur.com/THOP5UA.png)

LoginWindow is de hoofdklasse van het project. LoginWindow is een WPF Window verantwoordelijk voor het tonen van het inlogscherm en het verwerken van de user input.

LoginWindow maakt gebruik van een aantal WPF Controls. De controls die in de code worden gebruikt zijn te verdelen in twee categorieën: ‘Inloggen’ en ‘Account Aanmaken’. Er wordt altijd slechts één van deze categorieën getoond op het scherm. Daarom zijn er twee canvassen waarvan er één tegelijk zichtbaar is.

De static class PasswordHasher is verantwoordelijk voor de hashing en verificatie van de wachtwoorden. Het doet dit met Argon2id (github). Dit algoritme is zeer aanpasbaar en is bestendig tegen GPU-aanvallen en gebruikt veel geheugen. Dit maakt het zeer geschikt als hashing-algoritme en maakt het relatief toekomstbestendig. Alle methodes voor het Hashen en verifiëren staan in de static class TypTop.LoginGui.PasswordHasher.
