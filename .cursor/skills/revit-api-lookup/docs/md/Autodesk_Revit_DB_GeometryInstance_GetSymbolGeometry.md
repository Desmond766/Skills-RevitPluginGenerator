---
kind: method
id: M:Autodesk.Revit.DB.GeometryInstance.GetSymbolGeometry
source: html/7daa0e66-9921-3214-91f4-028e8cfd2618.htm
---
# Autodesk.Revit.DB.GeometryInstance.GetSymbolGeometry Method

Computes the geometric representation of the symbol which generates this instance.

## Syntax (C#)
```csharp
public GeometryElement GetSymbolGeometry()
```

## Returns
An element which contains the computed geometry for the symbol.

## Remarks
The geometry will be in the local coordinate space of the symbol. 
The context of this instance object (such as effective material) will be applied to the symbol.
Note that this method involves extensive parsing or Revit's data structures, so try to
minimize calls if performance is critical.
Geometry will be parsed with the same options as those used when this object was retrieved.
The results of the method and the value of the SymbolGeometry property are identical.
This method returns the actual Revit geometry. Unlike other methods which extract transformed
copies of the geometry, the return value of this method is suitable for
creating new Revit elements referencing the original element (for example, dimensioning).

