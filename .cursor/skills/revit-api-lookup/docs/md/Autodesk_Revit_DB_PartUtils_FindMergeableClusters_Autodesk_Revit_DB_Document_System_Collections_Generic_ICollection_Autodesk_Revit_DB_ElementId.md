---
kind: method
id: M:Autodesk.Revit.DB.PartUtils.FindMergeableClusters(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/283fcb8d-2b4b-1d2b-bd02-157ab722f1f8.htm
---
# Autodesk.Revit.DB.PartUtils.FindMergeableClusters Method

Segregates a set of elements into subsets which are
 valid for merge.

## Syntax (C#)
```csharp
public static IList<ICollection<ElementId>> FindMergeableClusters(
	Document doc,
	ICollection<ElementId> partIds
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document.
- **partIds** (`System.Collections.Generic.ICollection < ElementId >`) - A set of element ids.

## Returns
An array of clusters such that all the elements in a single cluster
 are valid for merge. Each cluster will be maximal in that appending
 any of the other Parts specified as input will result in a collection
 that is not valid for merge.

## Remarks
Element ids in the input set that do not correspond to Part
 elements will be ignored, as will element ids corresponding
 to Part elements that already have associated parts.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

