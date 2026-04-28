---
kind: property
id: P:Autodesk.Revit.DB.Material.SurfaceBackgroundPatternId
zh: 材质、材料
source: html/6b7f71e4-7d89-ab30-3eda-65ca8bc038e2.htm
---
# Autodesk.Revit.DB.Material.SurfaceBackgroundPatternId Property

**中文**: 材质、材料

The id of the FillPatternElement used as the background pattern of faces with this material in normal views.

## Syntax (C#)
```csharp
public ElementId SurfaceBackgroundPatternId { get; set; }
```

## Remarks
The FillPattern used for a background pattern must have a 'Drafting' target.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The element id must represent a valid FillPatternElement.
 -or-
 When setting this property: The FillPattern target must be a drafting pattern.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

