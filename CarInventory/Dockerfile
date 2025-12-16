# ---------- Build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy project file and restore dependencies
COPY CarInventory/CarInventory.csproj CarInventory/
RUN dotnet restore CarInventory/CarInventory.csproj

# Copy the rest of the source code
COPY CarInventory/. CarInventory/

# Build and publish
WORKDIR /app/CarInventory
RUN dotnet publish -c Release -o /app/out

# ---------- Runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy published output
COPY --from=build /app/out .

# Expose port Render expects
EXPOSE 8080

# Start the app
ENTRYPOINT ["dotnet", "CarInventory.dll"]