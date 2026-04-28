---
kind: method
id: M:Autodesk.Revit.DB.FormatOptions.GetUnitTypeId
source: html/32e858f2-d143-fe2c-76a5-38485382fb95.htm
---
# Autodesk.Revit.DB.FormatOptions.GetUnitTypeId Method

Gets the identifier of the unit used to quantify values.

## Syntax (C#)
```csharp
public ForgeTypeId GetUnitTypeId()
```

## Remarks
Most units, such as square feet or degrees, are formatted as decimal
 decimal numbers. Other units may be displayed with specialized
 formatting methods like "feet and fractional inches" or "degrees,
 minutes and seconds".

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - UseDefault is true in this FormatOptions.

