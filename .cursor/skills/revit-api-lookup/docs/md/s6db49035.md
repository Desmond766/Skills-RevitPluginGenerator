---
kind: property
id: P:Autodesk.Revit.DB.Reference.GlobalPoint
source: html/2889cd43-6496-0a64-2b50-3ba76ee4dd74.htm
---
# Autodesk.Revit.DB.Reference.GlobalPoint Property

The position on which the reference is hit.

## Syntax (C#)
```csharp
public XYZ GlobalPoint { get; }
```

## Returns
Nothing nullptr a null reference ( Nothing in Visual Basic) if the reference doesn't have a global point.

## Remarks
When using a plan view, the Z-value of a GlobalPoint is not meaningful.

