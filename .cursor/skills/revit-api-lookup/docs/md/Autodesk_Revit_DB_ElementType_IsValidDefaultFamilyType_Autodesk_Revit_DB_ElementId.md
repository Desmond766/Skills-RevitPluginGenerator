---
kind: method
id: M:Autodesk.Revit.DB.ElementType.IsValidDefaultFamilyType(Autodesk.Revit.DB.ElementId)
source: html/db029b02-e415-3807-d724-ec32b505d23a.htm
---
# Autodesk.Revit.DB.ElementType.IsValidDefaultFamilyType Method

Identifies if this type is a valid default family type for the given family category id.

## Syntax (C#)
```csharp
public bool IsValidDefaultFamilyType(
	ElementId familyCategoryId
)
```

## Parameters
- **familyCategoryId** (`Autodesk.Revit.DB.ElementId`) - The family category id.

## Returns
True if this type is a valid default family type for the given family category id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

