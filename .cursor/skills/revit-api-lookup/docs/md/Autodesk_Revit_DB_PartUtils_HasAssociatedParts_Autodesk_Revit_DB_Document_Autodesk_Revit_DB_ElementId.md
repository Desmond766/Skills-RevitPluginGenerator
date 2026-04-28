---
kind: method
id: M:Autodesk.Revit.DB.PartUtils.HasAssociatedParts(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/085bed8c-760b-dfad-08f6-28fe0db2a272.htm
---
# Autodesk.Revit.DB.PartUtils.HasAssociatedParts Method

Checks if an element has associated parts.

## Syntax (C#)
```csharp
public static bool HasAssociatedParts(
	Document hostDocument,
	ElementId elementId
)
```

## Parameters
- **hostDocument** (`Autodesk.Revit.DB.Document`) - The document.
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The element to be checked for associated Parts

## Returns
True if the element has associated Parts.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

