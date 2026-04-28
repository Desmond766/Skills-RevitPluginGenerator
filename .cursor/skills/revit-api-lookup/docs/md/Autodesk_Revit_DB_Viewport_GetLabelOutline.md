---
kind: method
id: M:Autodesk.Revit.DB.Viewport.GetLabelOutline
source: html/dcc1b956-d611-2554-a040-da9ed1633c06.htm
---
# Autodesk.Revit.DB.Viewport.GetLabelOutline Method

Gets the outline viewport's label on the sheet.

## Syntax (C#)
```csharp
public Outline GetLabelOutline()
```

## Returns
The outline of the viewport's label on the sheet.
 The outline may be empty if there is no label.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The viewport is not on a sheet.

