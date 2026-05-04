---
kind: method
id: M:Autodesk.Revit.DB.Structure.PathReinforcement.IsUnobscuredInView(Autodesk.Revit.DB.View)
source: html/051a0fc5-cd26-7756-1331-d532639d5ac3.htm
---
# Autodesk.Revit.DB.Structure.PathReinforcement.IsUnobscuredInView Method

Checks if Path Reinforcement is shown unobscured in a view.

## Syntax (C#)
```csharp
public bool IsUnobscuredInView(
	View view
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view element

## Returns
True if Path Reinforcement is shown unobscured, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This element doesn't have valid visibility data.

