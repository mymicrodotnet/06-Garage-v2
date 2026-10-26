# C# Övning 6 – Garage 2.0

Ett första övergripande projekt

För att koppla samman mycket av det ni lärt er ska vi nu bygga en garage-
/konsolapplikation. Applikationen ska tillhandahålla den funktionalitet ett system kan
behöva för att simulera ett enkelt garage.

Det ska alltså gå att parkera fordon, hämta ut fordon, se vilka fordon som finns i garaget och vilka egenskaper de har. Allt detta ska ske i en konsolapplikation med huvudmeny och undermenyer.

Anledningen till att ni ska programmera ett garage är att det är enkelt att förankra
uppdelningen i systemet. Vi kan huvudsakligen dela upp ett garage i följande delar:

- Garaget: En representation av själva byggnaden. Garaget är en plats där ett antal
  fordon kan förvaras. Garaget kan därför representeras som en samling av fordon.
- Fordon: Bilar, motorcyklar, enhjulingar eller andra typer av fordon som kan ställas
  in i garaget.

Detta är de två huvudsakliga “objekttyperna” i ett fysiskt garage. Om vi tittar närmare bör det också finnas subklasser till fordon, alltså att varje fordonstyp är en egen subklass i systemet. Utöver detta krävs funktionalitet som hanterar att fordon ställs in i garaget, att fordon kan tas ut ur garaget samt att vi kan presentera och söka bland fordonen.

I mer programmeringsvänliga termer ska vi som minimum ha:

- En kollektion av fordon; klassen Garage.
- En fordonsklass; klassen Vehicle.
- Ett antal subklasser till fordon.
- Ett användargränssnitt som låter användaren använda garagefunktionerna. Här
  sker all interaktion med användaren.

# Kravspecifikation

- Fordonen ska implementeras som klassen Vehicle och subklasser till den.
- Vehicle innehåller samtliga egenskaper som ska finnas i samtliga fordonstyper,
  till exempel registreringsnummer, färg, antal hjul och andra egenskaper ni kan
  komma på.
- Registreringsnumret ska vara unikt.
- Det måste minst finnas följande subklasser: - Motorcycle - Airplane - Car - Bus - Boat
  Dessa subklasser ska implementera minst en egen egenskap var, till exempel:
- Number of Engines
- Cylinder volume
- Fuel type (Gasoline/Diesel)
- Number of seats
- Length

Klassen behöver inte ärva från någon annan klass eller implementera något interface.
Samlingen av fordon ska internt i klassen Garage hanteras som en `List<Vehicle>`.

Listan ska vara privat. Vid instansieringen av ett nytt garage måste kapaciteten anges
som argument till konstruktorn.

# VI SKA ANVÄNDA OSS AV EN `List<Vehicle>` INTERNT I GARAGE-KLASSEN!

Ni ska inte använda:

- En array internt i Garage-klassen.
- Generics, exempelvis `Garage<T>` where T : Vehicle.
- LINQ.
- Enhetstester.

# Funktionalitet

Det ska gå att:

- Lista samtliga parkerade fordon.
- Lista fordonstyper och hur många av varje typ som står i garaget.
- Lägga till och ta bort fordon ur garaget.
- Sätta en kapacitet, alltså antal parkeringsplatser, vid instansieringen av ett nytt
  garage.
- Möjlighet att populera garaget med ett antal fordon från start.
- Hitta ett specifikt fordon via registreringsnumret. Sökningen ska fungera oavsett
  om användaren skriver ABC123, Abc123 eller AbC123.
- Söka efter fordon utifrån en eller flera egenskaper från basklassen Vehicle.
  Exempel:
- Alla svarta fordon med fyra hjul.
- Alla motorcyklar som är rosa och har tre hjul.
- Alla lastbilar.
- Alla röda fordon.

Användaren ska få tydlig feedback på om något gått bra eller dåligt. Till exempel ska
användaren få bekräftelse när ett fordon har parkerats. Om det inte går ska användaren få veta varför.

# Användargränssnitt

Programmet ska vara en konsolapplikation med ett textbaserat användargränssnitt.
Från gränssnittet ska det gå att:

- Navigera till all funktionalitet i garaget.
- Skapa ett garage med en användarspecificerad storlek.
- Stänga av applikationen.

Applikationen ska hantera felaktiga indata på ett robust sätt, så att den inte kraschar vid felaktig inmatning eller användning.

# Förslag på extra funktionalitet

Följande funktionalitet är inte ett krav, men kan läggas till för att utöka projektet:

- Möjlighet att även söka på de fordonsspecifika egenskaperna.
- Hantera flera garage med olika typer av fordon, till exempel en hangar, ett vanligt
  garage och ett motorcykelgarage.
- Möjlighet att växla mellan olika garage i användargränssnittet, så att tidigare
  nämnda funktioner bara utförs på det garage som för tillfället är valt.
- Tydlig visning av vilket garage användaren för närvarande arbetar med.
- Ett garage som består av parkeringsplatser, där varje parkeringsplats kan hålla ett
  fordon.
- Spara och läsa garage till och från filsystemet, exempelvis via meny eller
  automatiskt vid start och avstängning.
- Olika fordon tar olika mycket plats. Till exempel kan en bil ta en plats, en båt två
  platser, ett flygplan tre platser och en motorcykel en tredjedels plats.
- När man parkerar ska endast de fordon som garaget har plats för visas som
  alternativ.
- Läsa in garagets storlek via konfiguration.
- Valfri ytterligare funktionalitet som ni tycker borde finnas.
  Lycka till!

# C# Exercise 6 – Garage 2.0 | English

A First Comprehensive Project

To bring together much of what you have learned, we will now build a garage/console application. The application should provide the functionality a system might need to simulate a simple garage.

It should be possible to park vehicles, retrieve vehicles, see which vehicles are in the garage, and view their properties. All of this should take place in a console application with a main menu and submenus.

The reason for programming a garage is that it is easy to establish a clear structure for the system. We can mainly divide a garage into the following parts:

- The garage: A representation of the physical building itself. The garage is a place where a number of vehicles can be stored. The garage can therefore be represented as a collection of vehicles.
- Vehicles: Cars, motorcycles, unicycles, or other types of vehicles that can be parked in the garage.

These are the two main “object types” in a physical garage. Looking more closely, there should also be subclasses of vehicles, meaning that each vehicle type should have its own subclass in the system. In addition, functionality is required to handle parking vehicles in the garage, removing vehicles from the garage, and presenting and searching through the vehicles.

In more programming-friendly terms, we should have at least:

- A collection of vehicles: the `Garage` class.
- A vehicle class: the `Vehicle` class.
- A number of subclasses of `Vehicle`.
- A user interface that allows the user to access the garage functionality. All user interaction takes place here.

# Requirements Specification

- Vehicles must be implemented using the `Vehicle` class and its subclasses.
- `Vehicle` contains all properties that should be shared by every vehicle type, such as registration number, color, number of wheels, and any other properties you can think of.
- Registration numbers must be unique.
- There must be at least the following subclasses:
  - `Motorcycle`
  - `Airplane`
  - `Car`
  - `Bus`
  - `Boat`

These subclasses must each implement at least one property of their own, for example:

- Number of engines
- Cylinder volume
- Fuel type (Gasoline/Diesel)
- Number of seats
- Length

The class does not need to inherit from any other class or implement any interface.

The collection of vehicles must be managed internally in the `Garage` class using a `List<Vehicle>`.

The list must be private. When a new garage is instantiated, its capacity must be specified as an argument to the constructor.

# WE MUST USE A `List<Vehicle>` INTERNALLY IN THE GARAGE CLASS!

You must not use:

- An array internally in the `Garage` class.
- Generics, for example `Garage<T> where T : Vehicle`.
- LINQ.
- Unit tests.

# Functionality

It must be possible to:

- List all parked vehicles.
- List the vehicle types and how many of each type are in the garage.
- Add and remove vehicles from the garage.
- Set a capacity, meaning the number of parking spaces, when instantiating a new garage.
- Populate the garage with a number of vehicles from the start.
- Find a specific vehicle by its registration number. The search must work regardless of whether the user enters `ABC123`, `Abc123`, or `AbC123`.
- Search for vehicles based on one or more properties from the base `Vehicle` class.

Examples:

- All black vehicles with four wheels.
- All motorcycles that are pink and have three wheels.
- All trucks.
- All red vehicles.

The user must receive clear feedback about whether an operation succeeded or failed. For example, the user must receive confirmation when a vehicle has been parked. If parking is not possible, the user must be informed of the reason.

# User Interface

The program must be a console application with a text-based user interface.

The interface must allow the user to:

- Navigate to all garage functionality.
- Create a garage with a user-specified capacity.
- Exit the application.

The application must handle invalid input robustly so that it does not crash because of incorrect input or usage.

# Suggestions for Additional Functionality

The following functionality is not required, but can be added to extend the project:

- The ability to search by vehicle-specific properties as well.
- Manage multiple garages containing different types of vehicles, for example, a hangar, a regular garage, and a motorcycle garage.
- The ability to switch between different garages in the user interface, so that the previously mentioned functions are performed only on the currently selected garage.
- Clearly display which garage the user is currently working with.
- A garage consisting of parking spaces, where each parking space can hold one vehicle.
- Save garages to and load garages from the file system, for example, through a menu or automatically at startup and shutdown.
- Different vehicles occupy different amounts of space. For example, a car can occupy one space, a boat two spaces, an airplane three spaces, and a motorcycle one-third of a space.
- When parking a vehicle, only vehicles that the garage has room for should be displayed as options.
- Load the garage capacity from configuration.
- Any additional functionality you think should be included.

Good luck!

# END
