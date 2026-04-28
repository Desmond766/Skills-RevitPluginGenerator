---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.DuctSizeSettings.RemoveSize(Autodesk.Revit.DB.Mechanical.DuctShape,System.Double)
source: html/9c4ba863-f8c4-574f-97e4-40fd3f2b6013.htm
---
# Autodesk.Revit.DB.Mechanical.DuctSizeSettings.RemoveSize Method

Erase the existing MEPSize with this nominal diameter. The duct shape determines the location of the size in the size table.

## Syntax (C#)
```csharp
public void RemoveSize(
	DuctShape shape,
	double nominalDiameter
)
```

## Parameters
- **shape** (`Autodesk.Revit.DB.Mechanical.DuctShape`) - The shape of duct.
- **nominalDiameter** (`System.Double`) - Nominal diameter.

## Remarks
Does nothing if there is no existing MEPSize with this nominal diameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Throws if the function is called during iterating the size set.

