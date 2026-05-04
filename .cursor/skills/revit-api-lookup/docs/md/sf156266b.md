---
kind: property
id: P:Autodesk.Revit.DB.Material.CutForegroundPatternId
zh: 材质、材料
source: html/9f03bba4-bdb1-5a2e-065e-c1d6ac04bb95.htm
---
# Autodesk.Revit.DB.Material.CutForegroundPatternId Property

**中文**: 材质、材料

The id of the FillPatternElement used as the foreground pattern of faces with this material in cut views.

## Syntax (C#)
```csharp
public ElementId CutForegroundPatternId { get; set; }
```

## Remarks
The FillPattern used for a cut foreground pattern must have a 'Drafting' target.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The element id must represent a valid FillPatternElement.
 -or-
 When setting this property: The FillPattern target must be a drafting pattern.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

