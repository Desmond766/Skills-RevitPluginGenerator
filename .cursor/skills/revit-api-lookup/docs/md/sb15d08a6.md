---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCProductWrapper.Create(Autodesk.Revit.DB.IFC.ExporterIFC,System.Boolean)
zh: 创建、新建、生成、建立、新增
source: html/832e93b2-8a73-c222-6a33-b214f8d84e74.htm
---
# Autodesk.Revit.DB.IFC.IFCProductWrapper.Create Method

**中文**: 创建、新建、生成、建立、新增

Establishes a new baseline product manager for elements and objects.

## Syntax (C#)
```csharp
public static IFCProductWrapper Create(
	ExporterIFC ExporterIFC,
	bool allowRelateToLevel
)
```

## Parameters
- **ExporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`) - The exporter.
- **allowRelateToLevel** (`System.Boolean`) - True to allow associated elements and objects to relate to a level, false to never allow such a
 relationship.

## Returns
The new baseline product manager.

## Remarks
Elements and objects associated to this product manager will be associated to a top-level IfcProduct based on the world coordinate
 system of the output file.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

