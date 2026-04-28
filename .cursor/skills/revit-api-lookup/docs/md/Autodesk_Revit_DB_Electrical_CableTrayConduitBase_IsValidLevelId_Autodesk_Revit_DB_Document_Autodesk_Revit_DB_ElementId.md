---
kind: method
id: M:Autodesk.Revit.DB.Electrical.CableTrayConduitBase.IsValidLevelId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/152e60e9-3c1e-fbf6-17f9-98b774547694.htm
---
# Autodesk.Revit.DB.Electrical.CableTrayConduitBase.IsValidLevelId Method

Identifies if a level id is valid.

## Syntax (C#)
```csharp
public static bool IsValidLevelId(
	Document document,
	ElementId levelId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The level id.

## Returns
True if the level id is valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

