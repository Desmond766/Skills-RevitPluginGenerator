---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewArea(Autodesk.Revit.DB.ViewPlan,Autodesk.Revit.DB.UV)
zh: 文档、文件
source: html/e7aa9e51-49c2-19b0-9a5b-c1f3ae6a9a1b.htm
---
# Autodesk.Revit.Creation.Document.NewArea Method

**中文**: 文档、文件

Creates a new area

## Syntax (C#)
```csharp
public Area NewArea(
	ViewPlan areaView,
	UV point
)
```

## Parameters
- **areaView** (`Autodesk.Revit.DB.ViewPlan`) - The view of area element.
- **point** (`Autodesk.Revit.DB.UV`) - The point which lies in the enclosed region of AreaBoundaryLines to put the new created Area

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the area view does not exist in the given document.

