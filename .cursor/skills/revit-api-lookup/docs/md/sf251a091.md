---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.FlexPipe.IsPipingSystemTypeId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/89bd462f-a178-5c9b-a897-44423c97bd2d.htm
---
# Autodesk.Revit.DB.Plumbing.FlexPipe.IsPipingSystemTypeId Method

Checks if given type is valid piping system type.

## Syntax (C#)
```csharp
public static bool IsPipingSystemTypeId(
	Document document,
	ElementId systemTypeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **systemTypeId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the piping system type to check.

## Returns
True if the given systemTypeId is the piping system type, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

