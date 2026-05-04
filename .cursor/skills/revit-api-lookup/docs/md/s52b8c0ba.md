---
kind: property
id: P:Autodesk.Revit.DB.FilledRegionType.BackgroundPatternId
source: html/eec4b9cd-f084-9732-097c-981620303fdd.htm
---
# Autodesk.Revit.DB.FilledRegionType.BackgroundPatternId Property

The background fill pattern Id.

## Syntax (C#)
```csharp
public ElementId BackgroundPatternId { get; set; }
```

## Remarks
The FillPattern used for a background pattern must have a 'Drafting' target.
 This applies to both project and family elements.
 In addition, when the FilledRegionAttributes element is in a family, the pattern
 cannot be the solid fill pattern unless the 'IsMasking' property is set to true.
 InvalidElementId is used when there is no background pattern

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The patternId must either be InvalidElementId or represent a valid FillPatternElement.
 -or-
 When setting this property: The patternId must be a 'Drafting' pattern.
 -or-
 When setting this property: In a family the patternId can not be a solid fill pattern if the 'IsMasking' property is false.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

