#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["My_API.Infrastructure.RestAPI/My_API.Infrastructure.RestAPI.csproj", "My_API.Infrastructure.RestAPI/"]
COPY ["My_API.Application/My_API.Application.csproj", "My_API.Application/"]
COPY ["My-API.Domain/My_API.Domain.csproj", "My-API.Domain/"]
COPY ["My_API.Infrastructure.DataSource/My_API.Infrastructure.DataSource.csproj", "My_API.Infrastructure.DataSource/"]
RUN dotnet restore "My_API.Infrastructure.RestAPI/My_API.Infrastructure.RestAPI.csproj"
COPY . .
WORKDIR "/src/My_API.Infrastructure.RestAPI"
RUN dotnet build "My_API.Infrastructure.RestAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "My_API.Infrastructure.RestAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "My_API.Infrastructure.RestAPI.dll"]