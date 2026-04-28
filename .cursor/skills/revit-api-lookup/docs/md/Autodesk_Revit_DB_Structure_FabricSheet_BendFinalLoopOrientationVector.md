---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricSheet.BendFinalLoopOrientationVector
source: html/d2c9263f-1d3d-fae8-6fe7-b4d419faf7e6.htm
---
# Autodesk.Revit.DB.Structure.FabricSheet.BendFinalLoopOrientationVector Property

Direction of local Fabric Sheet Y axis in bending polyline LCS.

## Syntax (C#)
```csharp
public XYZ BendFinalLoopOrientationVector { get; }
```

## Remarks
Note that bending line may be rotated before it is placed in Fabric Sheet local coordinate system.
 This vector allows to calculate rotation angle or Trf.

