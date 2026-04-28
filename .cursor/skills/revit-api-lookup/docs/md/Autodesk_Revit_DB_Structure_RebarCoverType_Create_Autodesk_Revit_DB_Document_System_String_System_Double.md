---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarCoverType.Create(Autodesk.Revit.DB.Document,System.String,System.Double)
zh: 创建、新建、生成、建立、新增
source: html/b7419d6c-e30b-47a0-aa37-4e77e5ccac67.htm
---
# Autodesk.Revit.DB.Structure.RebarCoverType.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new CoverType in the document.

## Syntax (C#)
```csharp
public static RebarCoverType Create(
	Document doc,
	string name,
	double coverDistance
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`)
- **name** (`System.String`)
- **coverDistance** (`System.Double`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name is an empty string.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - coverDistance cannot be negative.

