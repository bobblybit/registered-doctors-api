#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["RegisteredDoctors.csproj", "Doctors/"]

RUN dotnet restore "Doctors/RegisteredDoctors.csproj"

COPY . .

WORKDIR "/src"


RUN dotnet build "RegisteredDoctors.csproj" -c Release -o /app/build

#RUN dotnet ef database update

FROM build AS publish
RUN dotnet publish "RegisteredDoctors.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app


COPY --from=publish /src/RegisteredDoctors.db .
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "sd009Portfolio.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet RegisteredDoctors.dll