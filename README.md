# BlazorApp.ComponentsIntro

A Blazor Server application built with .NET 9.0 for learning and demonstrating Blazor component concepts.

## Overview

This project serves as an introduction to Blazor components and demonstrates various Blazor features including:

## Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- A code editor (Visual Studio, Visual Studio Code, or JetBrains Rider)

## Getting Started

### Option 1: Using the existing project

1. Clone or download this repository
2. Open a terminal/command prompt in the project root directory
3. Restore dependencies:

   ```bash
   dotnet restore
   ```

4. Run the application:

   ```bash
   dotnet run --project src/BlazorApp.ComponentsIntro
   ```

5. Open your browser and navigate to the URL shown in the terminal (typically `https://localhost:5001` or `http://localhost:5000`)

## Project Structure

``` text
BlazorApp.ComponentsIntro/
├── src/
│   └── BlazorApp.ComponentsIntro/
│       ├── Components/
│       │   ├── Layout/          # Layout components
│       │   └── Pages/           # Page components
│       │       ├── Home.razor   # Home page
│       │       ├── Counter.razor # Interactive counter demo
│       │       ├── Weather.razor # Weather forecast demo
│       │       └── Error.razor  # Error handling page
│       ├── Properties/          # Application properties
│       ├── wwwroot/            # Static web assets
│       │   └── lib/            # Client-side libraries
│       └── BlazorApp.ComponentsIntro.csproj
├── BlazorApp.ComponentsIntro.sln
└── createBlazorApp-ComponentsIntro.ps1
```

## Features

- **Home Page**: Welcome page with basic information
- **Counter Component**: Interactive component demonstrating state management and event handling
- **Weather Forecast**: Sample data display component showing table rendering
- **Error Handling**: Built-in error page for debugging
- **Bootstrap Integration**: Pre-configured with Bootstrap for responsive styling

## Development

### Building the Project

```bash
dotnet build
```

### Running Tests

```bash
dotnet test
```

### Publishing

To publish the application for deployment:

```bash
dotnet publish -c Release -o ./publish
```

## Technologies Used

- **.NET 9.0**: The latest .NET framework
- **Blazor Server**: Server-side Blazor hosting model
- **ASP.NET Core**: Web framework
- **Bootstrap**: CSS framework for responsive design
- **C#**: Primary programming language

## License

This project is for educational purposes and demonstration of Blazor concepts.
