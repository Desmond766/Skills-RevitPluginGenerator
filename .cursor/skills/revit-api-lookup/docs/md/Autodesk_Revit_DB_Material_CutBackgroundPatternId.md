---
kind: property
id: P:Autodesk.Revit.DB.Material.CutBackgroundPatternId
zh: 材质、材料
source: html/290d0d15-afd4-b333-ff39-8d46481b1b06.htm
---
# Autodesk.Revit.DB.Material.CutBackgroundPatternId Property

**中文**: 材质、材料

The id of the FillPatternElement used as the background pattern of faces with this material in cut views.

## Syntax (C#)
```csharp
public ElementId CutBackgroundPatternId { get; set; }
```

## Remarks
The FillPattern used for a cut pattern must have a 'Drafting' target.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The element id must represent a valid FillPatternElement.
 -or-
 When setting this property: The FillPattern target must be a drafting pattern.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

