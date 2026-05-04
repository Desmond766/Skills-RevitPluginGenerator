---
kind: method
id: M:Autodesk.Revit.DB.Viewport.GetBoxCenter
source: html/10a5ede6-0c97-79e0-a31a-2ffd90c7fc97.htm
---
# Autodesk.Revit.DB.Viewport.GetBoxCenter Method

Returns the center of the outline of the viewport on the sheet, excluding the viewport label.

## Syntax (C#)
```csharp
public XYZ GetBoxCenter()
```

## Returns
The center of the outline of the viewport on the sheet.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The viewport is not on a sheet.

