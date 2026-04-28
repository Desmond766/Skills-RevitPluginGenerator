---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.SetConfiguration(Autodesk.Revit.DB.FabricationConfigurationInfo,System.String)
source: html/827a0153-d51d-b34f-70d9-bf757a02494f.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.SetConfiguration Method

Set the fabrication configuration with specific profile.

## Syntax (C#)
```csharp
public void SetConfiguration(
	FabricationConfigurationInfo fabricationConfigurationInfo,
	string profile
)
```

## Parameters
- **fabricationConfigurationInfo** (`Autodesk.Revit.DB.FabricationConfigurationInfo`) - The desired fabrication configuration.
- **profile** (`System.String`) - The desired profile of the fabrication configuration. Use empty string for the global profile.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The profile "profile" is invalid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The fabrication configuration cannot be swapped because the exiting fabrication configuration has already been used in the document.
 -or-
 Cannot set the configuration.

