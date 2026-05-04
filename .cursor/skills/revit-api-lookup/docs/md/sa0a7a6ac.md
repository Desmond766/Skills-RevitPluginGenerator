---
kind: property
id: P:Autodesk.Revit.DB.GeometryInstance.SymbolGeometry
source: html/732dd1ab-0d2b-e2dd-d4e2-94e5bb9f3603.htm
---
# Autodesk.Revit.DB.GeometryInstance.SymbolGeometry Property

The geometric representation of the symbol which generates this instance.

## Syntax (C#)
```csharp
public GeometryElement SymbolGeometry { get; }
```

## Remarks
The geometry will be in the local coordinate space of the symbol. 
The context of this instance object (such as effective material) will be applied to the symbol.
Note that retrieving the value of this property involves extensive parsing or Revit's data 
structures, so try to minimize calls if performance is critical.
Geometry will be parsed with the same options as those used when this object was retrieved.
The value of this property and the results of the method GetSymbolGeometry(void) are identical.

