---
kind: property
id: P:Autodesk.Revit.DB.SolidOrShellTessellationControls.Accuracy
source: html/bf865045-141f-8ef2-0d31-a26f488cad1e.htm
---
# Autodesk.Revit.DB.SolidOrShellTessellationControls.Accuracy Property

A positive real number specifying how accurately a triangulation should approximate a solid or shell.

## Syntax (C#)
```csharp
public double Accuracy { get; set; }
```

## Remarks
The maximum distance from a point on the triangulation to the nearest point on the solid or shell should
 be no greater than the specified accuracy. This constraint may be approximately enforced.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for accuracy must be greater than 0 and no more than 30000 feet.

