---
kind: method
id: M:Autodesk.Revit.DB.GeometryInstance.GetInstanceGeometry
source: html/22d4a5d4-dfc2-7227-2cae-b989729696ec.htm
---
# Autodesk.Revit.DB.GeometryInstance.GetInstanceGeometry Method

Computes the geometric representation of the instance.

## Syntax (C#)
```csharp
public GeometryElement GetInstanceGeometry()
```

## Returns
An element which contains the computed geometry for the instance.

## Remarks
The geometry will be in the coordinate system of the model that owns this instance. 
The context of the instance object (such as effective material) will be applied to the symbol.
Note that this method involves extensive parsing or Revit's data structures, so try to
minimize calls if performance is critical.
Geometry will be parsed with the same options as those used when this object was retrieved.
This method returns a copy of the Revit geometry. It is suitable for use in a tool which extracts
geometry to another format or carries out a geometric analysis; however, because it returns a copy
the references found in the geometry objects contained in this element are not suitable for
creating new Revit elements referencing the original element (for example, dimensioning). 
Only the geometry returned by GetSymbolGeometry() with no transform can be used for that purpose.

