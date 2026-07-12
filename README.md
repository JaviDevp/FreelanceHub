# FreelanceHub

Aplicación personal en .NET 10 y Blazor Web App (Interactive Server) para centralizar ofertas freelance.

## Requisitos

- .NET SDK 10
- Node.js 22 o superior

## Ejecución local

```powershell
npm install
npm run css:build
dotnet run
```

Durante trabajo de interfaz puede ejecutarse `npm run css:watch` en otra terminal. Si las dependencias de Node están instaladas, `dotnet build` también regenera el CSS antes de compilar.

La configuración no sensible vive en `appsettings*.json`. Las credenciales futuras de conectores deben proporcionarse mediante variables de entorno o secretos de usuario y nunca almacenarse en el código fuente.

## Organización

- `Components/`: infraestructura general de Blazor, rutas y layouts.
- `Features/`: páginas, componentes, DTOs y servicios agrupados por funcionalidad.
- `Models/`: entidades persistidas, sin subdirectorios.
- `Data/`: contexto, configuraciones y migraciones de Entity Framework Core.
- `Shared/`: elementos reutilizados por más de una feature.
- `wwwroot/`: recursos estáticos y estilos.
