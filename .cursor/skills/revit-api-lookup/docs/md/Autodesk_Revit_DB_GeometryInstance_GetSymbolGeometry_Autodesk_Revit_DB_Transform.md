---
kind: method
id: M:Autodesk.Revit.DB.GeometryInstance.GetSymbolGeometry(Autodesk.Revit.DB.Transform)
source: html/6de9b5fd-682f-ffa0-5e49-84b1d227d606.htm
---
# Autodesk.Revit.DB.GeometryInstance.GetSymbolGeometry Method

Computes a transformation of the geometric representation of the symbol 
which generates this instance.

## Syntax (C#)
```csharp
public GeometryElement GetSymbolGeometry(
	Transform transform
)
```

## Parameters
- **transform** (`Autodesk.Revit.DB.Transform`) - The transformation to apply to the geometry.

## Returns
An element which contains the computed geometry for the transformed symbol.

## Remarks
The context of this instance object (such as effective material) 
will be applied to the symbol.
Note that this method involves extensive parsing or Revit's data structures, so try to
minimize calls if performance is critical.
Geometry will be parsed with the same options as those used when this object was retrieved.
This method returns a copy of the Revit geometry. It is suitable for use in a tool which extracts
geometry to another format or carries out a geometric analysis; however, because it returns a copy
the references found in the geometry objects contained in this element are not suitable for
creating new Revit elements referencing the original element (for example, dimensioning). 
Only the geometry returned by GetSymbolGeometry() with no transform can be used for that purpose.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Transform is not conformal

