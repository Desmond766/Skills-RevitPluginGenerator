---
kind: method
id: M:Autodesk.Revit.DB.Analysis.SpatialFieldManager.IsTextTypeIdValid(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Document)
source: html/5ef78392-a65f-d26b-28b8-5583404c772a.htm
---
# Autodesk.Revit.DB.Analysis.SpatialFieldManager.IsTextTypeIdValid Method

Verify if text type id is valid.

## Syntax (C#)
```csharp
public static bool IsTextTypeIdValid(
	ElementId textTypeId,
	Document doc
)
```

## Parameters
- **textTypeId** (`Autodesk.Revit.DB.ElementId`) - Text type id to be validated.
- **doc** (`Autodesk.Revit.DB.Document`) - Document for which %textTypeId% is validated.

## Returns
True if text type id is valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

