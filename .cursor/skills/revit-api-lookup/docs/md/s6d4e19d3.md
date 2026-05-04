---
kind: method
id: M:Autodesk.Revit.DB.PartUtils.HasAssociatedParts(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.LinkElementId)
source: html/5c9afcd0-f20c-519a-1a8c-938ceafdeb2a.htm
---
# Autodesk.Revit.DB.PartUtils.HasAssociatedParts Method

Checks if an element has associated parts.

## Syntax (C#)
```csharp
public static bool HasAssociatedParts(
	Document hostDocument,
	LinkElementId hostOrLinkElementId
)
```

## Parameters
- **hostDocument** (`Autodesk.Revit.DB.Document`) - The document.
- **hostOrLinkElementId** (`Autodesk.Revit.DB.LinkElementId`) - The element to be checked for associated Parts.

## Returns
True if the element has associated Parts.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

