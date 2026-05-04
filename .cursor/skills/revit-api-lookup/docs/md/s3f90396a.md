---
kind: method
id: M:Autodesk.Revit.DB.Document.IsDefaultFamilyTypeIdValid(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 文档、文件
source: html/5bb8f467-d26c-449d-9031-ba072fcb48b4.htm
---
# Autodesk.Revit.DB.Document.IsDefaultFamilyTypeIdValid Method

**中文**: 文档、文件

Checks whether the family type id is valid for the give family category.

## Syntax (C#)
```csharp
public bool IsDefaultFamilyTypeIdValid(
	ElementId familyCategoryId,
	ElementId familyTypeId
)
```

## Parameters
- **familyCategoryId** (`Autodesk.Revit.DB.ElementId`) - The family category id.
- **familyTypeId** (`Autodesk.Revit.DB.ElementId`) - The default family type id.

## Returns
True if the family type id is valid for the give family category, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

