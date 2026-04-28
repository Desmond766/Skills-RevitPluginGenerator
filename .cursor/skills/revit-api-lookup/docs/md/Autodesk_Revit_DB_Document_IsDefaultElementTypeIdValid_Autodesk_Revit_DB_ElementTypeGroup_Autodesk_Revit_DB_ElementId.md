---
kind: method
id: M:Autodesk.Revit.DB.Document.IsDefaultElementTypeIdValid(Autodesk.Revit.DB.ElementTypeGroup,Autodesk.Revit.DB.ElementId)
zh: 文档、文件
source: html/a322128b-9244-ce7f-fb5e-06aa50d5dca5.htm
---
# Autodesk.Revit.DB.Document.IsDefaultElementTypeIdValid Method

**中文**: 文档、文件

Checks whether the element type id is valid for the give DefaultElmentType id.

## Syntax (C#)
```csharp
public bool IsDefaultElementTypeIdValid(
	ElementTypeGroup defaultTypeId,
	ElementId typeId
)
```

## Parameters
- **defaultTypeId** (`Autodesk.Revit.DB.ElementTypeGroup`) - The default element type id.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - The element type id.

## Returns
True if the element type id is valid for the give DefaultElmentType id, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

