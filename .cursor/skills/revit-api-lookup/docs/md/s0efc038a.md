---
kind: method
id: M:Autodesk.Revit.DB.ExternalFileUtils.GetAllExternalFileReferences(Autodesk.Revit.DB.Document)
source: html/be61b425-020c-61c6-9199-05feb39a0ebf.htm
---
# Autodesk.Revit.DB.ExternalFileUtils.GetAllExternalFileReferences Method

Gets the ids of all elements which are external file references.

## Syntax (C#)
```csharp
public static ICollection<ElementId> GetAllExternalFileReferences(
	Document aDoc
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - A Revit Document.

## Returns
The ids of all elements which are external file references.

## Remarks
This function will not return the ids of nested Revit links;
 it only returns top-level references.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

