---
kind: method
id: M:Autodesk.Revit.DB.PartUtils.GetAssociatedParts(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.LinkElementId,System.Boolean,System.Boolean)
source: html/a2eab773-d518-ad13-162c-1f5ff402aeef.htm
---
# Autodesk.Revit.DB.PartUtils.GetAssociatedParts Method

Returns all Parts that are associated with the given element

## Syntax (C#)
```csharp
public static ICollection<ElementId> GetAssociatedParts(
	Document hostDocument,
	LinkElementId hostOrLinkElementId,
	bool includePartsWithAssociatedParts,
	bool includeAllChildren
)
```

## Parameters
- **hostDocument** (`Autodesk.Revit.DB.Document`) - The document of the element
- **hostOrLinkElementId** (`Autodesk.Revit.DB.LinkElementId`) - The element to be checked for associated Parts.
- **includePartsWithAssociatedParts** (`System.Boolean`) - If true, include parts that have associated parts
- **includeAllChildren** (`System.Boolean`) - If true, return all associated Parts recursively for all children
 If false, only return immediate children

## Returns
Parts that are associated to the element

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

