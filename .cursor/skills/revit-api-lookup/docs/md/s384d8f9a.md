---
kind: method
id: M:Autodesk.Revit.DB.Structure.Truss.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Curve)
zh: 创建、新建、生成、建立、新增
source: html/2d6a9c76-9a39-8161-a203-e4f8084495ef.htm
---
# Autodesk.Revit.DB.Structure.Truss.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new Truss.

## Syntax (C#)
```csharp
public static Truss Create(
	Document document,
	ElementId trussTypeId,
	ElementId sketchPlaneId,
	Curve curve
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the new Truss is created.
- **trussTypeId** (`Autodesk.Revit.DB.ElementId`) - Element id of the truss type.
- **sketchPlaneId** (`Autodesk.Revit.DB.ElementId`) - Element id of a SketchPlane.
- **curve** (`Autodesk.Revit.DB.Curve`) - The curve of the truss element.
 It must be a line, must not be a vertical line, and must be within the sketch plane.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input curve points to a helical curve and is not supported for this operation.
 -or-
 The element id should refer to a valid TrussType.
 -or-
 The element id should refer to a valid SketchPlane.
 -or-
 The curve is invalid to be the base curve of a truss.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This function is only enabled in Revit Structure and Revit Architecture.
 -or-
 Failed to create Truss element.

