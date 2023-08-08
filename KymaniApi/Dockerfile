FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["KymaniApi/KymaniApi.csproj", "KymaniApi/"]
RUN dotnet restore "KymaniApi/KymaniApi.csproj"

COPY . .

WORKDIR "/src/KymaniApi"
RUN dotnet build "KymaniApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KymaniApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KymaniApi.dll"]