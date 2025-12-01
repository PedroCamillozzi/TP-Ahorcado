# Imagen base para ejecutar la app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# ⚠️ Render asigna el puerto dinámicamente mediante la variable de entorno PORT
# Configuramos ASP.NET para escuchar en ese puerto
ENV ASPNETCORE_URLS=http://+:${PORT}

# Exponer un puerto cualquiera (Render ignora este valor, pero lo dejamos por compatibilidad)
EXPOSE 8080

# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar los proyectos
COPY ["..WebAhorado/WebAhorado.csproj", "WebAhorado/"]
COPY ["..TP-Ahorcado/TP-Ahorcado.csproj", "TP-Ahorcado/"]

# Restaurar dependencias
RUN dotnet restore "./WebAhorado/WebAhorado.csproj"

# Copiar el resto del código
COPY . .

# Compilar el proyecto
WORKDIR "/src/WebAhorado"
RUN dotnet build "./WebAhorado.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publicar el proyecto
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebAhorado.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Imagen final para ejecución
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "WebAhorado.dll"]
