---
kind: method
id: M:Autodesk.Revit.DB.PartUtils.ArePartsValidForMerge(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/fd03fb06-da32-0e66-2b01-8f3926788162.htm
---
# Autodesk.Revit.DB.PartUtils.ArePartsValidForMerge Method

Identifies whether Part elements may be merged.

## Syntax (C#)
```csharp
public static bool ArePartsValidForMerge(
	Document document,
	ICollection<ElementId> partIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **partIds** (`System.Collections.Generic.ICollection < ElementId >`) - Element ids of Parts.

## Returns
True if all element ids correspond to Part elements,
 none of the parts already has associated parts,
 the parts have contiguous geometry, all report the same materials,
 and all have the same creation and demolition phases.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

