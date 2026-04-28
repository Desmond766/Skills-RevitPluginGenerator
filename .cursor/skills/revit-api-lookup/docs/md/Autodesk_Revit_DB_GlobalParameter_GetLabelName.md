---
kind: method
id: M:Autodesk.Revit.DB.GlobalParameter.GetLabelName
source: html/020d91e9-ebea-2449-a747-72a8613f4765.htm
---
# Autodesk.Revit.DB.GlobalParameter.GetLabelName Method

Returns the name of this parameter's label, which is used to label dimension elements.

## Syntax (C#)
```csharp
public string GetLabelName()
```

## Returns
The name of the parameter's label.

## Remarks
Note that a Label equals a parameter's name if the parameters is non-reporting.
 Reporting parameters, however, have their labels suffixed by a special string
 to make it obvious the parameters is reporting (thus suitable to be driven by
 a dimension.)

