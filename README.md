# Garage 2.0

## Overview

Garage 2.0 is a C# console application built with .NET 10 for managing vehicles parked in a garage. It supports parking and removing vehicles, listing parked vehicles, searching by different criteria, and managing garage capacity.

The application uses object-oriented programming (OOP), a `Vehicle` base class with specialized vehicle subclasses, and a `List<Vehicle>` collection to manage parked vehicles.

## How to Run this project

### Requirements:

.NET 10 SDK

### Project Structure:

```
06-Garage-v2
├── 06-Garage-v2
|  ├── 06-Garage-v2.csproj
|  ├── Garage.cs
|  ├── Program.cs
|  └── Vehicles
|     ├── Airplane.cs
|     ├── Boat.cs
|     ├── Bus.cs
|     ├── Car.cs
|     ├── Motorcycle.cs
|     └── Vehicle.cs
├── 06-Garage-v2.slnx
└── README.md
```

### Run the Application

#### Option 1: From the repository root

```bash
dotnet run --project 06-Garage-v2/06-Garage-v2.csproj
```

#### Option 2: From the project directory

First, navigate to the directory containing 06-Garage-v2.csproj:

```bash
cd 06-Garage-v2
```

Then run:

```bash
dotnet run
```

### Build the Project

To compile the project without running the application, execute:

```bash
dotnet build
```

## Classes and Responsibilities

1. Vehicle: Base class containing properties shared by all vehicles, including registration number, color, and number of wheels.
2. Car: Represents a car and includes its fuel type.
3. Motorcycle: Represents a motorcycle and includes its cylinder volume.
4. Airplane: Represents an airplane and includes its number of engines.
5. Bus: Represents a bus and includes its number of seats.
6. Boat: Represents a boat and includes its length.
7. Garage: Manages parked vehicles, garage capacity, parking and removal, searches, and garage-related operations.
8. Program.cs: Contains the console interface, menus, user input, validation, and interaction with the garage.

## Background Documents

### Assignment – Övning 6 (Swedish)

[View Övning 6 – C-Sharp Garage med listor (PDF)](documents/2026-10-22-%C3%96vning%206%20C-Sharp%20Garage%20med%20listor.pdf)

### Group Code Review Assignment (Swedish)

[View Gruppuppgift – Genomföra Code Review på Garage-ver 2 (PDF)](documents/2026-10-26-Gruppuppgift%20-%20Genomf%C3%B6ra%20Code%20Review%20p%C3%A5%20Garage-ver%202.pdf)

### Group Code Review Assignment (English)

[View Group Assignment – Conducting a Code Review (PDF)](documents/2026-10-26-Gruppuppgift-Code_Review_Garage_V2_English.pdf)

### Original README

[View the original README](documents/README-original.md)

# **Code Review Feedback**

These are the questions from the "Group Assignment – Conducting a Code Review" document.

I would like feedback on the following:

## **1. Architecture and responsibilities**

### 1.1 Is the division of responsibilities between Garage and Program clear?

### 1.2. I have put a lot of menu and input-handling logic in Program. Is that reasonable, or should I create a separate `nuHandler` or `UserInterface` class?

### 1.3. How can I improve handling of invalid input?

### 1.4. My `Garage` class handles vehicles, capacity, searching, and printing. Does it have too many responsibilities?

### 1.5. Would you split Program.cs into several classes? Which classes would you create, and why?

## **2. OOP and class design**

### 2.1 Is it clear which properties should be in the base class Vehicle and which should belong in subclasses?

### 2.2 How should I handle capacity when different vehicles take up different amounts of space—for example, a motorcycle takes one-third of a space and a boat takes two spaces?

## **3. Garage and List**

### 3.1 How should I handle capacity when different vehicles take up different amounts of space—for example, a motorcycle takes one-third of a space and a boat takes two spaces?

## **4. Searching and filtering**

### 4.1 I search by registration number, colour, and number of wheels separately. How can I build a search with several optional criteria?

## **5. Error handling and robustness**

### 5.1 How should the program behave if someone tries to park a vehicle with a registration number that already exists?

### 5.2 What happens if the garage is full and the user tries to park a vehicle?
