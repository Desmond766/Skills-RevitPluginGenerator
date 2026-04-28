---
kind: property
id: P:Autodesk.Revit.DB.BaseImportOptions.Unit
source: html/bb0e0e8e-f5bc-e39c-13f5-e3cce98c7652.htm
---
# Autodesk.Revit.DB.BaseImportOptions.Unit Property

The unit of measure for imported geometry.

## Syntax (C#)
```csharp
public ImportUnit Unit { get; set; }
```

## Remarks
Units are used to calculate the import scale unless scale is defined explicitly using CustomScale, in which case Units will be ignored.
 Feet, inches, meters, centimeters, decimeters, millimeters are all supported. If Default unit is set, Revit will read and use the units
 from the file. If units are not available or accessible there, Revit will default to %overrideUnit%.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

