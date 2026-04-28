---
kind: method
id: M:Autodesk.Revit.DB.Architecture.Stairs.IsByComponent(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 楼梯
source: html/a2a67884-d354-3e11-14e6-8dc6a1d06a5b.htm
---
# Autodesk.Revit.DB.Architecture.Stairs.IsByComponent Method

**中文**: 楼梯

Indicates if the stairs is created by stairs components(runs, landings and supports).

## Syntax (C#)
```csharp
public static bool IsByComponent(
	Document document,
	ElementId stairsId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **stairsId** (`Autodesk.Revit.DB.ElementId`) - The stairs element to check.

## Returns
True if the stairs is created by components, False otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element stairsId does not exist in the document
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

