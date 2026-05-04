---
kind: method
id: M:Autodesk.Revit.DB.DisplacementElement.GetAbsoluteDisplacement
source: html/0debfbc3-451e-a43a-a1dd-99a25b35da25.htm
---
# Autodesk.Revit.DB.DisplacementElement.GetAbsoluteDisplacement Method

The absolute displacement applied to the displaced elements.

## Syntax (C#)
```csharp
public XYZ GetAbsoluteDisplacement()
```

## Returns
The absolute displacement.

## Remarks
The value is the relative translation of this DisplacementElement
 plus the relative displacements of all of its ancestor DisplacementElements.

