# Persistencia

`AppDbContext` usa Entity Framework Core y SQLite. La cadena `FreelanceHubDb` se configura en `appsettings.json`; el archivo local resultante está excluido del control de versiones.

## Esquema de ofertas

`JobOffers` conserva la plataforma y URL original como datos obligatorios. Los identificadores externos, presupuesto, moneda, modalidad, publicación, ubicación, remoto, etiquetas y postulantes son opcionales porque no todas las fuentes los proporcionan.

Los estados y modalidades se almacenan como texto. Las etiquetas se guardan como JSON. Existen índices para plataforma, publicación y estado, además de claves únicas filtradas por plataforma + identificador externo y plataforma + URL canónica.

## Migraciones

```powershell
dotnet tool restore
dotnet ef database update
```
