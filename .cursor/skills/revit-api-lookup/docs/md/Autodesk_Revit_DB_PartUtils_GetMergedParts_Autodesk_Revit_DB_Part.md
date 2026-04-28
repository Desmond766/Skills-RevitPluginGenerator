---
kind: method
id: M:Autodesk.Revit.DB.PartUtils.GetMergedParts(Autodesk.Revit.DB.Part)
source: html/8d2c68f0-386b-75ae-c779-25c7050d4afc.htm
---
# Autodesk.Revit.DB.PartUtils.GetMergedParts Method

Retrieves the element ids of the source elements of a merged part.

## Syntax (C#)
```csharp
public static ICollection<ElementId> GetMergedParts(
	Part part
)
```

## Parameters
- **part** (`Autodesk.Revit.DB.Part`) - A merged part.

## Returns
The element ids of the parts that were merged to create the specified merged part.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The specified Part is not a merged part.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

