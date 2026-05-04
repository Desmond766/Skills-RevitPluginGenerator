---
kind: method
id: M:Autodesk.Revit.DB.RuledSurface.GetSecondProfilePoint
source: html/25c68423-a251-12a4-4094-b69bf2153a61.htm
---
# Autodesk.Revit.DB.RuledSurface.GetSecondProfilePoint Method

If a point was used to define the second profile, returns a copy of that point.

## Syntax (C#)
```csharp
public XYZ GetSecondProfilePoint()
```

## Returns
The second profile point if it was set.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This surface element does not use a point to define the second profile.

