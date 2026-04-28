---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.Pipe.IsPipingSystemTypeId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 管道、水管、管线
source: html/c770c18c-d93f-0e8f-b4c4-60a0468e9444.htm
---
# Autodesk.Revit.DB.Plumbing.Pipe.IsPipingSystemTypeId Method

**中文**: 管道、水管、管线

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

