---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.Duct.IsHvacSystemTypeId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 风管
source: html/d7726059-8e4c-98b6-1dda-18d11e09a1ff.htm
---
# Autodesk.Revit.DB.Mechanical.Duct.IsHvacSystemTypeId Method

**中文**: 风管

Checks if given type is valid HVAC system type.

## Syntax (C#)
```csharp
public static bool IsHvacSystemTypeId(
	Document document,
	ElementId systemTypeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **systemTypeId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the HVAC system type to check.

## Returns
True if the given systemTypeId is the HVAC system type, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

