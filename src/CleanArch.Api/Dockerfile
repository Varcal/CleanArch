#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/CleanArch.Api/CleanArch.Api.csproj", "src/CleanArch.Api/"]
COPY ["src/CleanArch.Application/CleanArch.Application.csproj", "src/CleanArch.Application/"]
COPY ["src/CleanArch.Domain/CleanArch.Domain.csproj", "src/CleanArch.Domain/"]
COPY ["src/CleanArch.Data/CleanArch.Data.csproj", "src/CleanArch.Data/"]
COPY ["src/CleanArch.Cache/CleanArch.Cache.csproj", "src/CleanArch.Cache/"]
RUN dotnet restore "src/CleanArch.Api/CleanArch.Api.csproj"
COPY . .
WORKDIR "/src/src/CleanArch.Api"
RUN dotnet build "CleanArch.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanArch.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanArch.Api.dll"]