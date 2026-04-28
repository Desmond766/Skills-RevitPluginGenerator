---
kind: method
id: M:Autodesk.Revit.DB.ThermalAsset.EqualsThermalOnly(Autodesk.Revit.DB.ThermalAsset)
source: html/7fc1c932-1edd-2837-0f45-f3a1ae6ca870.htm
---
# Autodesk.Revit.DB.ThermalAsset.EqualsThermalOnly Method

Determines whether this thermal asset is equal to another, but ignore data from base class.

## Syntax (C#)
```csharp
public bool EqualsThermalOnly(
	ThermalAsset other
)
```

## Parameters
- **other** (`Autodesk.Revit.DB.ThermalAsset`) - The thermal asset to compare with this one.

## Returns
True if the given thermal asset is equal to this one, otherwise false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

