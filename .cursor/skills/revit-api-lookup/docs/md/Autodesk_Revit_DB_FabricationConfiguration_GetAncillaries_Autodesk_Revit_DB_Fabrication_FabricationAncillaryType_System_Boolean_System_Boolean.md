---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.GetAncillaries(Autodesk.Revit.DB.Fabrication.FabricationAncillaryType,System.Boolean,System.Boolean)
source: html/b224007e-150d-c5a1-c703-d7abb8a37d29.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.GetAncillaries Method

Gets fabrication ancillaries of the specified type.

## Syntax (C#)
```csharp
public IList<int> GetAncillaries(
	FabricationAncillaryType type,
	bool includeKits,
	bool filterKits
)
```

## Parameters
- **type** (`Autodesk.Revit.DB.Fabrication.FabricationAncillaryType`) - The type of ancillaries to get.
- **includeKits** (`System.Boolean`) - Whether or not to include ancillary kits as well.
- **filterKits** (`System.Boolean`) - Whether kits should be filtered to only those that contain the specified ancillary type.

## Returns
An array of ancillary identifiers.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

