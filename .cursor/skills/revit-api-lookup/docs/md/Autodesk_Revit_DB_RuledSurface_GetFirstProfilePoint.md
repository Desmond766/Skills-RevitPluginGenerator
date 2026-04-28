---
kind: method
id: M:Autodesk.Revit.DB.RuledSurface.GetFirstProfilePoint
source: html/5e92662a-714e-c214-dd72-33854724d69d.htm
---
# Autodesk.Revit.DB.RuledSurface.GetFirstProfilePoint Method

If a point was used to define the first profile, returns a copy of that point.

## Syntax (C#)
```csharp
public XYZ GetFirstProfilePoint()
```

## Returns
The first profile point if it was set.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This surface element does not use a point to define the first profile.

