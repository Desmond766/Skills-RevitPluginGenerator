---
kind: method
id: M:Autodesk.Revit.DB.Analysis.AnalysisDisplayStyle.IsTextTypeIdValid(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Document)
source: html/bf01d634-9d7c-9bc5-330a-0d883ae92e12.htm
---
# Autodesk.Revit.DB.Analysis.AnalysisDisplayStyle.IsTextTypeIdValid Method

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

