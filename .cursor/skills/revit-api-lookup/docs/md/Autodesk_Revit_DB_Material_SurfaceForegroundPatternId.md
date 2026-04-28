---
kind: property
id: P:Autodesk.Revit.DB.Material.SurfaceForegroundPatternId
zh: 材质、材料
source: html/dc5602cc-54d3-2be0-bd3c-4dd9efc14010.htm
---
# Autodesk.Revit.DB.Material.SurfaceForegroundPatternId Property

**中文**: 材质、材料

The id of the FillPatternElement used as the foreground pattern of faces with this material in normal views.

## Syntax (C#)
```csharp
public ElementId SurfaceForegroundPatternId { get; set; }
```

## Remarks
The FillPattern used for a surface foreground pattern can have a 'Drafting' or a 'Model' target.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The element id must represent a valid FillPatternElement.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

