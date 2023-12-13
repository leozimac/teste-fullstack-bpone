#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Lecommerce.API/Lecommerce.API.csproj", "Lecommerce.API/"]
COPY ["Lecommerce.Application/Lecommerce.Application.csproj", "Lecommerce.Application/"]
COPY ["Lecommerce.Domain/Lecommerce.Domain.csproj", "Lecommerce.Domain/"]
COPY ["Lecommerce.Infra/Lecommerce.Infra.csproj", "Lecommerce.Infra/"]
COPY ["Lecommerce.IoC/Lecommerce.IoC.csproj", "Lecommerce.IoC/"]
RUN dotnet restore "Lecommerce.API/Lecommerce.API.csproj"
COPY . .
WORKDIR "/src/Lecommerce.API"
RUN dotnet build "Lecommerce.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lecommerce.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lecommerce.API.dll"]