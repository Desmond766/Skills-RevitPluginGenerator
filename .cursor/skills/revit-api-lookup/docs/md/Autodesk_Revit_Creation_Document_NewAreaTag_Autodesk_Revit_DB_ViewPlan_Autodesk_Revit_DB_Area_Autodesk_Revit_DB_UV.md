---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewAreaTag(Autodesk.Revit.DB.ViewPlan,Autodesk.Revit.DB.Area,Autodesk.Revit.DB.UV)
zh: 文档、文件
source: html/626eda1c-4259-63f6-22b4-c6c234615a61.htm
---
# Autodesk.Revit.Creation.Document.NewAreaTag Method

**中文**: 文档、文件

Creates a new area tag.

## Syntax (C#)
```csharp
public AreaTag NewAreaTag(
	ViewPlan areaView,
	Area room,
	UV point
)
```

## Parameters
- **areaView** (`Autodesk.Revit.DB.ViewPlan`) - The area view
- **room** (`Autodesk.Revit.DB.Area`) - The area to tag
- **point** (`Autodesk.Revit.DB.UV`) - The position of the area tag

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the area view does not exist in the given document.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the area does not exist in the given document.

