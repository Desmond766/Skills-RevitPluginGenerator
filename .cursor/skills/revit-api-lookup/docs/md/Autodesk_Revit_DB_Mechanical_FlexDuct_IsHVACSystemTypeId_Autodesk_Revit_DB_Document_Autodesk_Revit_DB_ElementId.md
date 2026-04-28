---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.FlexDuct.IsHVACSystemTypeId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/2fae60e5-94e0-4fb5-60d3-3b7ce4dd3e51.htm
---
# Autodesk.Revit.DB.Mechanical.FlexDuct.IsHVACSystemTypeId Method

Checks if given type is valid HVAC system type.

## Syntax (C#)
```csharp
public static bool IsHVACSystemTypeId(
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

