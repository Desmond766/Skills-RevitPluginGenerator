---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.ReloadConfiguration
source: html/4a40d755-029f-5a44-b2a4-b4bb749eae52.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.ReloadConfiguration Method

Reloads the fabrication configuration from its source fabrication configuration.

## Syntax (C#)
```csharp
public ConfigurationReloadInfo ReloadConfiguration()
```

## Returns
The information about the reload of the fabrication configuration.

## Remarks
The configuration must be reloaded from its source fabrication configuration before loading new fabrication services or additional parts.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The fabrication configuration is not set yet.
 -or-
 The source fabrication configuration could not be found.
 -or-
 this operation failed.

