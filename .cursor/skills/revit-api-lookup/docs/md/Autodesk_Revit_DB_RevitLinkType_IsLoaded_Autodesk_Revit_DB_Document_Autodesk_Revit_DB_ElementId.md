---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkType.IsLoaded(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/a59a0c41-0fe3-9ecf-e448-82414966b745.htm
---
# Autodesk.Revit.DB.RevitLinkType.IsLoaded Method

Checks whether the link with this id is loaded.

## Syntax (C#)
```csharp
public static bool IsLoaded(
	Document document,
	ElementId typeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - A document. Revit will see if typeId corresponds to a loaded link in this document.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - An element id. Revit will check if typeId corresponds to a loaded link in the given document.

## Returns
True if typeId corresponds to a loaded RevitLinkType. False otherwise.

## Remarks
Returns false if typeId is not the id of a RevitLinkType.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

