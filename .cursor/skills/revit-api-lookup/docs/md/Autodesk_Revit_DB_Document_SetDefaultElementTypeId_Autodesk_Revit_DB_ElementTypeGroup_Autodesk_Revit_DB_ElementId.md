---
kind: method
id: M:Autodesk.Revit.DB.Document.SetDefaultElementTypeId(Autodesk.Revit.DB.ElementTypeGroup,Autodesk.Revit.DB.ElementId)
zh: 文档、文件
source: html/bcd1ffba-2ddf-83b2-a243-fb0cfdba0b7c.htm
---
# Autodesk.Revit.DB.Document.SetDefaultElementTypeId Method

**中文**: 文档、文件

Sets the default element type id of the given DefaultElementType id.

## Syntax (C#)
```csharp
public void SetDefaultElementTypeId(
	ElementTypeGroup defaultTypeId,
	ElementId typeId
)
```

## Parameters
- **defaultTypeId** (`Autodesk.Revit.DB.ElementTypeGroup`) - The default element type id.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - The element type id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element type id typeId is invalid for the give DefaultElementType id defaultTypeId.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

