---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralConnectionHandler.AddElementIds(System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId})
source: html/707dc3c9-bd26-65b2-14ae-2e345c5ad977.htm
---
# Autodesk.Revit.DB.Structure.StructuralConnectionHandler.AddElementIds Method

Adds element ids to the connection.
 All element ids in an array should be of applicable category.

## Syntax (C#)
```csharp
public void AddElementIds(
	IList<ElementId> elemIds
)
```

## Parameters
- **elemIds** (`System.Collections.Generic.IList < ElementId >`) - The ElementIdArr containing ids of elements to be added.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more element ids was not permitted to be add to the connection.
 Elements should be of applicable category.
 -or-
 One or more element ids was not permitted to be added to the connection.
 Elements should not be duplicated.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

