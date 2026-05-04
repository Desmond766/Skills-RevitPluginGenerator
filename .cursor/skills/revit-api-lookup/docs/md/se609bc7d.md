---
kind: method
id: M:Autodesk.Revit.DB.ShapeImporter.SetDefaultLengthUnit(Autodesk.Revit.DB.ImportUnit)
source: html/41ffab1e-4b54-72e0-7eb4-ad44dee582bc.htm
---
# Autodesk.Revit.DB.ShapeImporter.SetDefaultLengthUnit Method

Sets the length unit to be used when the input is a unitless SAT file.

## Syntax (C#)
```csharp
public ShapeImporter SetDefaultLengthUnit(
	ImportUnit defaultLengthUnit
)
```

## Parameters
- **defaultLengthUnit** (`Autodesk.Revit.DB.ImportUnit`) - The length unit to be used for when the input is a unitless SAT file.

## Remarks
Values ImportUnit::Default and ImportUnit::Custom are ignored. ImportUnit::Centimeter is used instead.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

