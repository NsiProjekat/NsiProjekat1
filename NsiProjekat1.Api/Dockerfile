FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["NsiProjekat1.Api/NsiProjekat1.Api.csproj", "NsiProjekat1.Api/"]
COPY ["NsiProjekat1.Infrastructure/NsiProjekat1.Infrastructure.csproj", "NsiProjekat1.Infrastructure/"]
COPY ["NsiProjekat1.Application/NsiProjekat1.Application.csproj", "NsiProjekat1.Application/"]
COPY ["NsiProjekat1.Domain/NsiProjekat1.Domain.csproj", "NsiProjekat1.Domain/"]
RUN dotnet restore "NsiProjekat1.Api/NsiProjekat1.Api.csproj"
COPY . .
WORKDIR "/src/NsiProjekat1.Api"
RUN dotnet build "NsiProjekat1.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NsiProjekat1.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NsiProjekat1.Api.dll"]
