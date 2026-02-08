# Base image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

# SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy csproj files and restore dependencies
COPY ["src/FiveThreeOne.Api/FiveThreeOne.Api.csproj", "src/FiveThreeOne.Api/"]
COPY ["src/FiveThreeOne.Application/FiveThreeOne.Application.csproj", "src/FiveThreeOne.Application/"]
COPY ["src/FiveThreeOne.Domain/FiveThreeOne.Domain.csproj", "src/FiveThreeOne.Domain/"]
COPY ["src/FiveThreeOne.Infrastructure/FiveThreeOne.Infrastructure.csproj", "src/FiveThreeOne.Infrastructure/"]

RUN dotnet restore "src/FiveThreeOne.Api/FiveThreeOne.Api.csproj"

# Copy the rest of the code and build
COPY . .
WORKDIR "/src/src/FiveThreeOne.Api"
RUN dotnet build "FiveThreeOne.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "FiveThreeOne.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FiveThreeOne.Api.dll"]