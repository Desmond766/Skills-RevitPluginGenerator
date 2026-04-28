---
kind: type
id: T:Autodesk.Revit.DB.Structure.RebarTrimExtendData
source: html/980b816d-dc7e-7550-3e37-61482516b5ab.htm
---
# Autodesk.Revit.DB.Structure.RebarTrimExtendData

The class that contains the information needed to calculate and return the curves in a trimmed/extended state, and also find the constraints that trim/extend it.

## Syntax (C#)
```csharp
public class RebarTrimExtendData : IDisposable
```

## Remarks
If new curves will be added by calling addBarGeometry(), the existing curves in Rebar element will be replaced with these curves. It will not add curves to the existing ones.

