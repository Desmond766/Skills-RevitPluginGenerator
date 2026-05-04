---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.SetUnobscuredInView(Autodesk.Revit.DB.View,System.Boolean)
zh: 钢筋、配筋
source: html/ab857136-3b6f-5c0e-b28c-5ea5f7c3be79.htm
---
# Autodesk.Revit.DB.Structure.Rebar.SetUnobscuredInView Method

**中文**: 钢筋、配筋

Sets this rebar element to be shown unobscured in a view.

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
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This rebar element doesn't have valid visibility data.

