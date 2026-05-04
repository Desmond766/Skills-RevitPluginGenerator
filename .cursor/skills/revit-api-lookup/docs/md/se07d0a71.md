---
kind: property
id: P:Autodesk.Revit.DB.Structure.LineLoad.IsUniform
source: html/e315fe82-508c-b64e-0f9a-4863596544f2.htm
---
# Autodesk.Revit.DB.Structure.LineLoad.IsUniform Property

Indicates if the load is uniform.

## Syntax (C#)
```csharp
public bool IsUniform { get; }
```

## Remarks
Returns true if the line load is uniform, false otherwise.
 Load is uniform when force and moment vectors assigned to the start and the end point of load are equal.

