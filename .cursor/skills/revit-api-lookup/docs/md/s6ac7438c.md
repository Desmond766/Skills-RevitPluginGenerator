---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarCoupler.SetUnobscuredInView(Autodesk.Revit.DB.View,System.Boolean)
source: html/1e883463-46aa-feb3-1660-dc757dc722d3.htm
---
# Autodesk.Revit.DB.Structure.RebarCoupler.SetUnobscuredInView Method

Sets this rebar coupler element to be shown unobscured in a view.

## Syntax (C#)
```csharp
public void SetUnobscuredInView(
	View view,
	bool unobscured
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view element
- **unobscured** (`System.Boolean`) - True if rebar coupler is shown unobscured, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This rebar coupler element doesn't have valid visibility data

