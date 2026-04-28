---
kind: method
id: M:Autodesk.Revit.DB.Structure.PathReinforcement.SetUnobscuredInView(Autodesk.Revit.DB.View,System.Boolean)
source: html/5533aeb2-dc1f-a329-165e-2107272a0fc3.htm
---
# Autodesk.Revit.DB.Structure.PathReinforcement.SetUnobscuredInView Method

Sets Path Reinforcement to be shown unobscured in a view.

## Syntax (C#)
```csharp
public void SetUnobscuredInView(
	View view,
	bool unobscured
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view element
- **unobscured** (`System.Boolean`) - True if Path Reinforcement is shown unobscured, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This element doesn't have valid visibility data.

