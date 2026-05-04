---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaReinforcement.SetUnobscuredInView(Autodesk.Revit.DB.View,System.Boolean)
source: html/53acd3ec-3d4e-ea81-67af-de3512d5d875.htm
---
# Autodesk.Revit.DB.Structure.AreaReinforcement.SetUnobscuredInView Method

Sets Area Reinforcement to be shown unobscured in a view.

## Syntax (C#)
```csharp
public void SetUnobscuredInView(
	View view,
	bool unobscured
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view element
- **unobscured** (`System.Boolean`) - True if Area Reinforcement is shown unobscured, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This element doesn't have valid visibility data.

