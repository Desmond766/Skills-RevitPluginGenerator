---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaReinforcement.IsUnobscuredInView(Autodesk.Revit.DB.View)
source: html/e68d430f-1cd3-be82-f495-438876dac18b.htm
---
# Autodesk.Revit.DB.Structure.AreaReinforcement.IsUnobscuredInView Method

Checks if Area Reinforcement is shown unobscured in a view.

## Syntax (C#)
```csharp
public bool IsUnobscuredInView(
	View view
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view element

## Returns
True if Area Reinforcement is shown unobscured, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This element doesn't have valid visibility data.

