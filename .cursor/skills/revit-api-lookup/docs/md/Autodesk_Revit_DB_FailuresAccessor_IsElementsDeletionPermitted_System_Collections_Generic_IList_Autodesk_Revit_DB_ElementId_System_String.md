---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.IsElementsDeletionPermitted(System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId},System.String@)
source: html/d138c9cb-b343-d38e-c4c9-a22ffd6baae4.htm
---
# Autodesk.Revit.DB.FailuresAccessor.IsElementsDeletionPermitted Method

Checks if resolution of the failures by deleting given collection of elements is permitted.

## Syntax (C#)
```csharp
public bool IsElementsDeletionPermitted(
	IList<ElementId> idsToDelete,
	out string reason
)
```

## Parameters
- **idsToDelete** (`System.Collections.Generic.IList < ElementId >`) - The Ids of elements to be deleted.
- **reason** (`System.String %`) - A localized string explaining reason why the elements cannot be deleted.

## Returns
True if resolution of the failures by deleting given elements is permitted

## Remarks
Method does not confirm if deletion of the elements will or may resolve the failure - it simply verifies
 that given elements can be deleted in the current state of the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

