# Use the ASP.NET runtime image as a base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Adapter/Driver/TechMedicos.API/TechMedicos.API.csproj", "Adapter/Driver/TechMedicos.API/"]
RUN dotnet restore "Adapter/Driver/TechMedicos.API/TechMedicos.API.csproj"
COPY . .
WORKDIR "/src/Adapter/Driver/TechMedicos.API"
RUN dotnet build "TechMedicos.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TechMedicos.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TechMedicos.API.dll"]
