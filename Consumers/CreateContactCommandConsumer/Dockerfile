FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Ensure these paths are correct based on your project structure
COPY ["Consumers/CreateContactCommandConsumer/CreateContactCommandConsumer.csproj", "Consumers/CreateContactCommandConsumer/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Persistence/Persistence.csproj", "Persistence/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]

# Restore dependencies
RUN dotnet restore "./Consumers/CreateContactCommandConsumer/CreateContactCommandConsumer.csproj"

# Copy the rest of the files
COPY . .

# Build the application
WORKDIR "/src/Consumers/CreateContactCommandConsumer"
RUN dotnet build "./CreateContactCommandConsumer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CreateContactCommandConsumer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CreateContactCommandConsumer.dll"]
