---
kind: method
id: M:Autodesk.Revit.DB.Toposolid.Simplify(System.Double)
source: html/dabded04-9e0a-e675-b90e-8b9b0ae7e479.htm
---
# Autodesk.Revit.DB.Toposolid.Simplify Method

Simplifies the toposolid by reducing the number of inner vertices to the given percentage.

## Syntax (C#)
```csharp
public void Simplify(
	double percentage
)
```

## Parameters
- **percentage** (`System.Double`) - The ratio of the number of inner vertices after simplify to the original number.

## Remarks
At low percentages, the inner vertices may not be reduced to the exact percentage to keep a rough semblance of the original shape.
 Call this method again if you want to keep removing inner vertices.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input percentage should be greater than 0 and less than 1.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - this operation failed.

