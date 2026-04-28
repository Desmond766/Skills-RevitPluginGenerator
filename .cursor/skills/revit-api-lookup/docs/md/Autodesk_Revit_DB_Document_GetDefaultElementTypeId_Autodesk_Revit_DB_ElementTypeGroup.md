---
kind: method
id: M:Autodesk.Revit.DB.Document.GetDefaultElementTypeId(Autodesk.Revit.DB.ElementTypeGroup)
zh: 文档、文件
source: html/b62f6563-aca4-56dc-4697-7717932187b3.htm
---
# Autodesk.Revit.DB.Document.GetDefaultElementTypeId Method

**中文**: 文档、文件

Gets the default element type id with the given DefaultElementType id.

## Syntax (C#)
```csharp
public ElementId GetDefaultElementTypeId(
	ElementTypeGroup defaultTypeId
)
```

## Parameters
- **defaultTypeId** (`Autodesk.Revit.DB.ElementTypeGroup`) - The default element type id.

## Returns
The element type id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

