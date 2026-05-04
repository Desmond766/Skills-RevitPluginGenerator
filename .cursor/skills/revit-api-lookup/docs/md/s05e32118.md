---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.DeleteElements(System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId})
source: html/bb23c934-3314-b5ef-7fbc-22cccd0aba84.htm
---
# Autodesk.Revit.DB.FailuresAccessor.DeleteElements Method

Resolves failures by deletion of elements related to the failures.

## Syntax (C#)
```csharp
public void DeleteElements(
	IList<ElementId> idsToDelete
)
```

## Parameters
- **idsToDelete** (`System.Collections.Generic.IList < ElementId >`) - Ids of elements to be deleted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Resolution of the failures by deleting idsToDelete is not permitted
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

