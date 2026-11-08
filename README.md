# Game Store REST API

[Screenshot]

.NET Version License: MIT

## Table of Contents
- [Short Description](#short-description)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Short Description

A high-performance REST API built with ASP.NET Core for managing a comprehensive video game catalog.

## Features

*   **CRUD Operations**: Full Create, Read, Update, and Delete functionality for games and genres.
*   **Database Integration**: Powered by Entity Framework Core with SQLite support for flexible data persistence.
*   **Input Validation**: Robust data integrity using Data Annotations to ensure valid client requests.
*   **Asynchronous Architecture**: Optimized for scalability using the asynchronous programming model.
*   **Frontend Ready**: Seamlessly integrates with modern frontend frameworks like React.

## Installation

### Prerequisites

*   .NET SDK 10.0
*   Visual Studio Code
*   C# Dev Kit extension

### Setup Steps

1.  Clone the repository to your local machine.

2.  Navigate to the project directory:
    ```bash
    cd game-store-api
    ```

3.  Restore the necessary NuGet packages:
    ```bash
    dotnet restore
    ```

4.  Apply database migrations to initialize the SQLite store:
    ```bash
    dotnet ef database update
    ```

## Usage

Start the API server to begin handling requests:
```bash
dotnet run
```

To interact with your API endpoints, use the included `games.http` file within Visual Studio Code or your preferred REST client.

## Contributing

We welcome contributions from the community! Please read our CONTRIBUTING.md to learn about our development workflow and code standards.

## License

This project is licensed under the MIT License. See the LICENSE file for more details.
