---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.OptimizeLengths(Autodesk.Revit.DB.Document,System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
source: html/23222651-0817-d314-cb3e-8dd70a261167.htm
---
# Autodesk.Revit.DB.FabricationPart.OptimizeLengths Method

Optimizes the length fabrication straight parts.

## Syntax (C#)
```csharp
public static ISet<ElementId> OptimizeLengths(
	Document document,
	ISet<ElementId> partIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **partIds** (`System.Collections.Generic.ISet < ElementId >`) - The identifiers of the fabrication parts in a selected fabrication part run.

## Returns
New and modified fabrication part ids in the optimize

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There are no straight parts to optimize, or all parts are locked or locked by group membership.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - this operation failed.

