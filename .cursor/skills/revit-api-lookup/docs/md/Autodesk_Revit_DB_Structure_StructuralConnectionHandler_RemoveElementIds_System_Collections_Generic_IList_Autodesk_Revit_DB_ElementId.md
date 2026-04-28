---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralConnectionHandler.RemoveElementIds(System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId})
source: html/ae145719-5699-3f78-d995-981319b4703f.htm
---
# Autodesk.Revit.DB.Structure.StructuralConnectionHandler.RemoveElementIds Method

Removes element ids from the connection.
 All element ids in an array should belong to the connection.

## Syntax (C#)
```csharp
public void RemoveElementIds(
	IList<ElementId> elemIds
)
```

## Parameters
- **elemIds** (`System.Collections.Generic.IList < ElementId >`) - The ElementIdArr containing ids of elements to be removed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more element ids was not permitted to be removed from the connection.
 Elements should be members of the connection.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

