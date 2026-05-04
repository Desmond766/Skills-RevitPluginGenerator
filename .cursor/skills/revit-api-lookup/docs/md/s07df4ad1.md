---
kind: method
id: M:Autodesk.Revit.DB.RevisionCloud.GetSketchCurves
source: html/f0ee4ae4-ed7a-3071-b0f4-446ad314a5a5.htm
---
# Autodesk.Revit.DB.RevisionCloud.GetSketchCurves Method

Returns copies of the Curves that form this RevisionCloud.

## Syntax (C#)
```csharp
public IList<Curve> GetSketchCurves()
```

## Returns
Copies of the sketched curves that form this RevisionCloud.

## Remarks
Note that there is no requirement that the curves form closed loops or avoid self-intersections. The
 curves may also form multiple closed loops.

