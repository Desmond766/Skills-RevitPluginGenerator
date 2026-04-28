---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfigurationInfo.FindSourceFabricationConfiguration(Autodesk.Revit.DB.FabricationConfigurationInfo)
source: html/39baf971-3d20-1997-ce18-979d42cdc307.htm
---
# Autodesk.Revit.DB.FabricationConfigurationInfo.FindSourceFabricationConfiguration Method

Finds the source fabrication configuration on disk which matches the input fabrication configuration.

## Syntax (C#)
```csharp
public static FabricationConfigurationInfo FindSourceFabricationConfiguration(
	FabricationConfigurationInfo fabricationConfiguration
)
```

## Parameters
- **fabricationConfiguration** (`Autodesk.Revit.DB.FabricationConfigurationInfo`) - The fabrication configuration to match.

## Returns
The matching source fabrication configuration.

## Remarks
Fabrication configuration is matched by configuration GUID and version. The GUIDs are required to be the same.
 For version, we first try to match the version exactly. If Revit cannot find an exact match, then it looks for
 the closest version later than the input configuration, then the closest earlier version.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

