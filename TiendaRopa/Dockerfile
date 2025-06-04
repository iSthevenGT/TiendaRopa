# Usar imagen base de .NET Framework (Windows)
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8-windowsservercore-ltsc2019

WORKDIR /app
COPY . .

# Restaurar paquetes NuGet
RUN nuget restore

# Compilar la aplicación
RUN msbuild TiendaRopa.csproj /p:Configuration=Release /p:Platform="Any CPU"

# Exponer puerto
EXPOSE 80

# Comando de inicio
CMD ["C:\\ServiceMonitor.exe", "w3svc"]
