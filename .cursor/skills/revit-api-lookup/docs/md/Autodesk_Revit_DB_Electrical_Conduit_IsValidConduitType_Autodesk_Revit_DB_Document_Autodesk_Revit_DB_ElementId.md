---
kind: method
id: M:Autodesk.Revit.DB.Electrical.Conduit.IsValidConduitType(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 线管
source: html/96ef9f2c-049a-19ee-8011-f4fd96cd9a67.htm
---
# Autodesk.Revit.DB.Electrical.Conduit.IsValidConduitType Method

**中文**: 线管

Identifies if a conduit type is valid.

## Syntax (C#)
```csharp
public static bool IsValidConduitType(
	Document document,
	ElementId conduitType
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **conduitType** (`Autodesk.Revit.DB.ElementId`) - The conduit type.

## Returns
True if the conduit type is valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

