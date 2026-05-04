---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.IsElementsDeletionPermitted(System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId})
source: html/d6bc3b54-d1a5-ee5b-3c58-64370f1129ca.htm
---
# Autodesk.Revit.DB.FailuresAccessor.IsElementsDeletionPermitted Method

Checks if resolution of the failures by deleting given collection of elements is permitted.

## Syntax (C#)
```csharp
public bool IsElementsDeletionPermitted(
	IList<ElementId> idsToDelete
)
```

## Parameters
- **idsToDelete** (`System.Collections.Generic.IList < ElementId >`) - The Ids of elements to be deleted.

## Returns
True if resolution of the failures by deleting given elements is permitted.

## Remarks
Method does not confirm if deletion of the elements will or may resolve the failure - it simply verifies
 that given elements exist and can be deleted in the current state of the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

