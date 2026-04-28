---
kind: method
id: M:Autodesk.Revit.DB.Document.SetDefaultFamilyTypeId(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 文档、文件
source: html/1f0d5aac-4602-b479-82b4-dc54a030c0a3.htm
---
# Autodesk.Revit.DB.Document.SetDefaultFamilyTypeId Method

**中文**: 文档、文件

Sets the default family type id for the given family category.

## Syntax (C#)
```csharp
public void SetDefaultFamilyTypeId(
	ElementId familyCategoryId,
	ElementId familyTypeId
)
```

## Parameters
- **familyCategoryId** (`Autodesk.Revit.DB.ElementId`) - The family category id.
- **familyTypeId** (`Autodesk.Revit.DB.ElementId`) - The default family type id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The family type id familyTypeId is invalid for the give family category familyCategoryId.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

