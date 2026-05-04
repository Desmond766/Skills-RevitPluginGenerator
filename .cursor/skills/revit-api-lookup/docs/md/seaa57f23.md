---
kind: type
id: T:Autodesk.Revit.DB.SketchPlane
source: html/ba104029-d175-7e75-caef-667a4281f4af.htm
---
# Autodesk.Revit.DB.SketchPlane

Represents a sketch plane or work plane.

## Syntax (C#)
```csharp
public class SketchPlane : Element
```

## Remarks
A SketchPlane object is used as an input to creation of sketch-referencing elements such as Model Curves or sketch-owning elements such as Generic Forms. The SketchPlane can be obtained from an existing element or created from a geometric plane or planar face. Note that the sketch plane element passed as input to create an element may not be the actual sketch plane assigned to that element; Revit may look for a geometrically equivalent plane to use, or may create a new one if the input plane is already used for other purposes. Some sketch planes (such as those obtained from detail curves) are suitable only for use in creating detail elements; they will be rejected when used for other element types.

