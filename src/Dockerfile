FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Debugger.Web/Debugger.Web.csproj", "Debugger.Web/"]
RUN dotnet restore "Debugger.Web/Debugger.Web.csproj"
COPY . .
WORKDIR "/src/Debugger.Web"
RUN dotnet build "Debugger.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Debugger.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Debugger.Web.dll"]