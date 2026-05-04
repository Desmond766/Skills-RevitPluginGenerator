---
kind: method
id: M:Autodesk.Revit.DB.Architecture.StairsRun.GetStairsPath
source: html/cb460743-dc63-545e-8d88-45061f2d2abd.htm
---
# Autodesk.Revit.DB.Architecture.StairsRun.GetStairsPath Method

Returns the stairs path curves on the run. The curves are projected on base level of the stairs.

## Syntax (C#)
```csharp
public CurveLoop GetStairsPath()
```

## Returns
The stairs path curves.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The stairs run has no stairs path it probably because the run was not generated yet.

