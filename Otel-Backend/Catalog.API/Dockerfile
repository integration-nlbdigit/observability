# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy project files and restore dependencies
COPY ["Catalog.API.csproj", "./"]
RUN dotnet restore

 
# Copy the rest of the source code and build the project
COPY . .
RUN dotnet publish -c Release -o /app/publish
 
# Use a smaller runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
 
# Expose the port on which the API runs
EXPOSE 6001
 
# Start the application
ENTRYPOINT ["dotnet", "Catalog.API.dll"]