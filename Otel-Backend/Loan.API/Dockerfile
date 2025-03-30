# Use the .NET 9.0 runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

EXPOSE 6002
 
# Use the .NET 9.0 SDK for building the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
# Copy the .csproj file and restore any dependencies
COPY ["Loan.API.csproj", "Loan.API/"]
RUN dotnet restore "Loan.API/Loan.API.csproj"
 
# Copy the rest of the application files
COPY . .
# Build the application and output the files to the /app/build directory
RUN dotnet publish "Loan.API.csproj" -c Release -o /app/publish
 
# Create the final image from the base image and copy the build artifacts
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
# Set the entry point for the application
ENTRYPOINT ["dotnet", "Loan.API.dll"]