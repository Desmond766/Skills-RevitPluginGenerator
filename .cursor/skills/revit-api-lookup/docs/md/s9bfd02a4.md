---
kind: property
id: P:Autodesk.Revit.DB.FilledRegionType.ForegroundPatternId
source: html/5ac029c0-7345-16eb-3ea7-8028eff9a121.htm
---
# Autodesk.Revit.DB.FilledRegionType.ForegroundPatternId Property

The foreground fill pattern Id.

## Syntax (C#)
```csharp
public ElementId ForegroundPatternId { get; set; }
```

## Remarks
When the FilledRegionAttributes element is in a family then
 the FillPattern used for a foreground pattern must have a 'Drafting' target.
 In addition, when the FilledRegionAttributes element is in a family, the pattern
 cannot be the solid fill pattern unless the 'IsMasking' property is set to true.
 InvalidElementId is used when there is no foreground pattern

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The patternId must either be InvalidElementId or represent a valid FillPatternElement.
 -or-
 When setting this property: In a family the patternId must be a 'Drafting' pattern.
 -or-
 When setting this property: In a family the patternId can not be a solid fill pattern if the 'IsMasking' property is false.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

