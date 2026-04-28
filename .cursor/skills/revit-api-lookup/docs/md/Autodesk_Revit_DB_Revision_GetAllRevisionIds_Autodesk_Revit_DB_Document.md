---
kind: method
id: M:Autodesk.Revit.DB.Revision.GetAllRevisionIds(Autodesk.Revit.DB.Document)
source: html/1d7ae44e-1a2f-32ea-fe16-daa34ee3b481.htm
---
# Autodesk.Revit.DB.Revision.GetAllRevisionIds Method

Returns the ids of all Revisions in the project ordered by sequence number.

## Syntax (C#)
```csharp
public static IList<ElementId> GetAllRevisionIds(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the Revisions.

## Returns
The ids of all the Revisions in the document ordered by sequence number.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

