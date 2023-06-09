#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Respirar.Authentication.BackEnd/Respirar.Authentication.BackEnd.csproj", "Respirar.Authentication.BackEnd/"]
RUN dotnet restore "Respirar.Authentication.BackEnd/Respirar.Authentication.BackEnd.csproj"
COPY . .
WORKDIR "/src/Respirar.Authentication.BackEnd"
RUN dotnet build "Respirar.Authentication.BackEnd.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Respirar.Authentication.BackEnd.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Respirar.Authentication.BackEnd.dll"]