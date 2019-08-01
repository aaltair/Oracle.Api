FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["oracle.api/oracle.api.csproj", "oracle.api/"]
RUN dotnet restore "oracle.api/oracle.api.csproj"
COPY . .
WORKDIR "/src/oracle.api"
RUN dotnet build "oracle.api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "oracle.api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "oracle.api.dll"]