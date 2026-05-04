---
kind: type
id: T:Autodesk.Revit.DB.Viewport
source: html/5991dc40-234a-4835-cc06-07524d2e61a4.htm
---
# Autodesk.Revit.DB.Viewport

An element that establishes the placement of a view on a sheet.

## Syntax (C#)
```csharp
public class Viewport : Element
```

## Remarks
Viewports are used in Revit for purposes other than placement of
 views on sheets. Thus iteration of viewport elements in the model may
 locate viewports which are not assigned to sheets; you can use the
 SheetId property to filter these out.

