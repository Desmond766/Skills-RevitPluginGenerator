---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainer.SetUnobscuredInView(Autodesk.Revit.DB.View,System.Boolean)
source: html/484d706c-e0df-473f-5427-f3eeac17eedc.htm
---
# Autodesk.Revit.DB.Structure.RebarContainer.SetUnobscuredInView Method

Sets this rebar container element to be shown unobscured in a view.

## Syntax (C#)
```csharp
public void SetUnobscuredInView(
	View view,
	bool unobscured
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view element
- **unobscured** (`System.Boolean`) - True if rebar is shown unobscured, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This rebar container element doesn't have valid visibility data.

