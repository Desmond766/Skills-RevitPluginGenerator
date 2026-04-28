---
kind: method
id: M:Autodesk.Revit.DB.ComponentRepeater.RepeatElements(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/fea4df07-ac92-08f3-ae93-8d0a512d0e76.htm
---
# Autodesk.Revit.DB.ComponentRepeater.RepeatElements Method

Repeats a set of adaptive component hosted on one or more repeating references.

## Syntax (C#)
```csharp
public static IList<ComponentRepeater> RepeatElements(
	Document document,
	ICollection<ElementId> elementIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that contains the elements.
- **elementIds** (`System.Collections.Generic.ICollection < ElementId >`) - The set of adaptive components used as an input pattern for the repeating operation.

## Returns
One or more component repeater objects representing the result pattern of the repeating operation.

## Remarks
All elements must be adaptive family instances and have no shape handles.
 At least one placement point must be hosted on a 1D or 2D repeating reference.
 All other placement points can be hosted on a 0D, 1D or 2D repeating reference,
 or must be unhosted.
 Use CanElementBeRepeated(Document, ElementId) to test whether an element meets these conditions.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The document does not allow creation of a component repeater.
 -or-
 The given element id set is empty.
 -or-
 One or more elements in elementIds do not exist in the document.
 -or-
 Not all given elements can be repeated. All elements must be adaptive family instances, have no shape handles, and have at least one placement
 point hosted on a 1D or 2D repeating reference. The remaining placement points must be either unhosted or hosted on another repeating reference.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

