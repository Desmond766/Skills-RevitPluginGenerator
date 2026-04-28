---
kind: method
id: M:Autodesk.Revit.DB.PolyLine.Create(System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ})
zh: 创建、新建、生成、建立、新增
source: html/539a490d-1c19-e1c9-e9ad-30af0f74285d.htm
---
# Autodesk.Revit.DB.PolyLine.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a polyline with coordinate points provided.

## Syntax (C#)
```csharp
public static PolyLine Create(
	IList<XYZ> coordinates
)
```

## Parameters
- **coordinates** (`System.Collections.Generic.IList < XYZ >`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the count of coordinates is less than 2.

