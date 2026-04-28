---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.SetConfiguration(Autodesk.Revit.DB.FabricationConfigurationInfo)
source: html/9bc0cfaf-df04-ec3b-cd06-76a8c6902439.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.SetConfiguration Method

Set the fabrication configuration with global profile.

## Syntax (C#)
```csharp
public void SetConfiguration(
	FabricationConfigurationInfo fabricationConfigurationInfo
)
```

## Parameters
- **fabricationConfigurationInfo** (`Autodesk.Revit.DB.FabricationConfigurationInfo`) - The desired fabrication configuration.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The fabrication configuration cannot be swapped because the exiting fabrication configuration has already been used in the document.
 -or-
 Cannot set the configuration.

