---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceUtils.GetAllExternalResourceReferences(Autodesk.Revit.DB.Document)
source: html/0bfac259-4cc2-6a40-1a5f-7dd26f6ec3a5.htm
---
# Autodesk.Revit.DB.ExternalResourceUtils.GetAllExternalResourceReferences Method

Gets the ids of all elements which refer to external resources.

## Syntax (C#)
```csharp
public static ISet<ElementId> GetAllExternalResourceReferences(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Revit Document containing the external resource references.

## Returns
The ids of all elements which refer to external resources.

## Remarks
This function will not return the ids of nested Revit links;
 it only returns top-level references.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

