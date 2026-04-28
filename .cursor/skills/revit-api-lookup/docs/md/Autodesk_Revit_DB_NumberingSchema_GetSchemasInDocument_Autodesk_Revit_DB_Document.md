---
kind: method
id: M:Autodesk.Revit.DB.NumberingSchema.GetSchemasInDocument(Autodesk.Revit.DB.Document)
source: html/9bd7a9f5-49af-1d41-9f55-932723b7023e.htm
---
# Autodesk.Revit.DB.NumberingSchema.GetSchemasInDocument Method

Returns a set of Ids of all Numbering Schema elements for a given document.

## Syntax (C#)
```csharp
public static ISet<ElementId> GetSchemasInDocument(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - A document to get numbering schema from.

## Returns
Ids of NumberingSchema elements. An empty set if no schemas are found in the given document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

