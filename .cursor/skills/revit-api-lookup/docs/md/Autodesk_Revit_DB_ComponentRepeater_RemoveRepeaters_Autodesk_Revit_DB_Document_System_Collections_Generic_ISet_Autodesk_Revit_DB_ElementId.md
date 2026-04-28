---
kind: method
id: M:Autodesk.Revit.DB.ComponentRepeater.RemoveRepeaters(Autodesk.Revit.DB.Document,System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
source: html/f36b63f5-18dd-9279-7596-99548faf325e.htm
---
# Autodesk.Revit.DB.ComponentRepeater.RemoveRepeaters Method

Removes component repeaters from the document,
 but leaves the individual repeated components in their respective locations and
 hosted on their original hosts.

## Syntax (C#)
```csharp
public static ISet<ElementId> RemoveRepeaters(
	Document document,
	ISet<ElementId> elementIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that contains the component repeaters to remove.
- **elementIds** (`System.Collections.Generic.ISet < ElementId >`) - The set of component repeaters that should be removed.

## Returns
A collection of components that were previously repeated by the component repeater.

## Remarks
In addition to the component repeaters the component repeater slots
 are also removed from the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given element id set is empty.
 -or-
 One or more elements in elementIds do not exist in the document.
 -or-
 Not all given elements are component repeaters.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

