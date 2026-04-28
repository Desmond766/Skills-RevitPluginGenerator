---
kind: property
id: P:Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.DivisionRuleId
source: html/fd62adc1-005d-59b9-cfde-ab413cc7d0f9.htm
---
# Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.DivisionRuleId Property

Id of the 'DivisionRule' which is used to augment the cutting sketch.

## Syntax (C#)
```csharp
public ElementId DivisionRuleId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The provided element id cannot be assigned as a division rule
 to this PartMakerMethodToDivideVolumes.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

