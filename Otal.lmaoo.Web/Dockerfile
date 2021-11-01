#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Otal.lmaoo.Web/Otal.lmaoo.Web.csproj", "Otal.lmaoo.Web/"]
COPY ["Otal.lmaoo.Services/Otal.lmaoo.Services.csproj", "Otal.lmaoo.Services/"]
COPY ["Otal.lmaoo.Core/Otal.lmaoo.Core.csproj", "Otal.lmaoo.Core/"]
COPY ["Otal.lmaoo.Data/Otal.lmaoo.Data.csproj", "Otal.lmaoo.Data/"]
RUN dotnet restore "Otal.lmaoo.Web/Otal.lmaoo.Web.csproj"
COPY . .
WORKDIR "/src/Otal.lmaoo.Web"
RUN dotnet build "Otal.lmaoo.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Otal.lmaoo.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Otal.lmaoo.Web.dll"]