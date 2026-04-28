---
kind: method
id: M:Autodesk.Revit.DB.NumberSystem.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.LinkElementId,Autodesk.Revit.DB.Reference)
zh: 创建、新建、生成、建立、新增
source: html/6d9a83ed-5aa9-c97f-3932-b74ecd30fa8f.htm
---
# Autodesk.Revit.DB.NumberSystem.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a NumberSystem associated to a host element and a view.

## Syntax (C#)
```csharp
public static NumberSystem Create(
	Document document,
	ElementId viewId,
	LinkElementId numberedElementId,
	Reference referenceCurve
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The view in which the NumberSystem will be created.
- **numberedElementId** (`Autodesk.Revit.DB.LinkElementId`) - The host id on which the NumberSystem will be created.
- **referenceCurve** (`Autodesk.Revit.DB.Reference`) - The reference curve along which the NumberSystem will be created. It is suggested to get the new reference via GetNumberSystemReference() from the host element.

## Returns
The created NumberSystem.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - viewId is not valid for placement of a NumberSystem (only floor plan views and elevation views are permitted).
 -or-
 numberedElementId is not valid as a host for NumberSystem (only StairsRun elements are permitted in this release).
 -or-
 The referenceCurve is not valid for NumberSystem on numberedElementId.
 -or-
 The numberedElementId already has a NumberSystem.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

