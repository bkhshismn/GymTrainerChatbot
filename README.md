Gym Personal Trainer Chatbot API
Overview
The Gym Personal Trainer Chatbot API is a .NET Web API application built with .NET 8/9 that serves as a chatbot for answering gym-related questions. This API integrates with the OpenAI Assistant API to provide intelligent, interactive responses to user queries regarding gym exercises, workout plans, nutrition, and other gym-related topics. The application adheres to clean architecture principles and follows best practices for maintainability, scalability, and testability.

Features
Gym-related queries handling: The chatbot answers only gym-related questions. Any unrelated queries are politely rejected.
Integration with OpenAI API: The chatbot utilizes OpenAI's API to process user input and return meaningful responses.
Dockerized deployment: The application is containerized using Docker for consistent and reliable deployments.
Unit testing: Key functionality like query validation and OpenAI API interaction are covered with unit tests.
Swagger API Documentation: Endpoints are exposed via Swagger for easy testing and integration.
Technical Stack
Programming Language: C# (.NET 8/9)
Web Framework: ASP.NET Core Web API
Architecture: Clean Architecture / Onion Architecture
API Integration: OpenAI Assistant API (GPT-3.5 Turbo model)
Testing Framework: xUnit, NUnit, or MSTest
Containerization: Docker
Swagger: For API documentation and testing
Prerequisites
Before running this project locally, ensure that you have the following installed:

.NET 8/9 SDK: Download .NET SDK
Docker: Download Docker Desktop
OpenAI API Key: Obtain your API key from OpenAI here.
Setup Instructions
1. Clone the Repository
Clone this repository to your local machine:

bash
Copy code
git clone https://github.com/yourusername/gym-trainer-chatbot.git
cd gym-trainer-chatbot
2. Install Dependencies
Make sure to restore the NuGet packages:

bash
Copy code
dotnet restore
3. Set Up OpenAI API Key
In order to communicate with the OpenAI API, you will need to add your OpenAI API key. For security, store the key in your environment variables or use a configuration file.

Option 1: Add to appsettings.json
json
Copy code
{
  "OpenAiApiKey": "YOUR_OPENAI_API_KEY"
}
Option 2: Add as an environment variable:
bash
Copy code
setx OPENAI_API_KEY "YOUR_OPENAI_API_KEY"
4. Build the Application
To build the project, run the following command:

bash
Copy code
dotnet build
5. Run the Application Locally
To run the application locally, execute:

bash
Copy code
dotnet run
The API will be available at http://localhost:5000.

6. Test the Application
You can test the API using Swagger, which is automatically available at:

bash
Copy code
http://localhost:5000/swagger
7. Run with Docker
To run the application using Docker, follow these steps:

Build the Docker Image
bash
Copy code
docker build -t gym-trainer-chatbot .
Run the Docker Container
bash
Copy code
docker run -d -p 5000:80 gym-trainer-chatbot
The API will be available at http://localhost:5000.

API Endpoints
1. POST /api/chat
Description: Accepts user queries and returns chatbot responses.

Request Body:

json
Copy code
{
  "userQuery": "What are the best exercises for weight loss?"
}
Response:

json
Copy code
{
  "response": "To lose weight, you should focus on exercises like cardio, strength training, and high-intensity interval training (HIIT). It's important to also combine exercise with a healthy diet."
}
2. GET /api/status
Description: Health check endpoint to verify if the API is running.

Response:

json
Copy code
{
  "status": "ok"
}
Error Handling
Invalid API Key: If the API key for OpenAI is invalid or missing, a 401 Unauthorized error will be returned.
Network Issues: If there are any issues with the OpenAI API, a 500 Internal Server Error will be returned.
Unrelated Queries: If the user asks a non-gym-related question, the chatbot will politely respond with an error message:
json
Copy code
{
  "response": "Sorry, I can only answer questions related to gym exercises, workout plans, and nutrition."
}
Unit Testing
Unit tests are included for the following components:

Query Validation Service: Ensures that only gym-related queries are allowed.
OpenAI API Service: Ensures proper interaction with OpenAI's API.
You can run the tests using:

bash
Copy code
dotnet test
Dockerfile Explanation
The project includes a Dockerfile to containerize the application. Here's a breakdown of the file:

dockerfile
Copy code
# Use the official .NET SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the project files and restore the dependencies
COPY . ./
RUN dotnet restore

# Publish the application as a self-contained executable
RUN dotnet publish -c Release -o /out

# Use the official .NET runtime image for the final container
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Set the working directory inside the final container
WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /out .

# Expose the application port
EXPOSE 80

# Define the entry point for the container
ENTRYPOINT ["dotnet", "GymTrainerChatbot.dll"]
Contributing
If you want to contribute to this project, please fork the repository, create a new branch, and submit a pull request. Ensure that all contributions are well-tested and well-documented.

License
This project is licensed under the MIT License - see the LICENSE file for details.
