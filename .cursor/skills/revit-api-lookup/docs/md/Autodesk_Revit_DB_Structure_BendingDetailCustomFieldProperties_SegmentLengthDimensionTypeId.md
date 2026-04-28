---
kind: property
id: P:Autodesk.Revit.DB.Structure.BendingDetailCustomFieldProperties.SegmentLengthDimensionTypeId
source: html/6860f3f3-59b5-74e9-c718-4be700dbe8ac.htm
---
# Autodesk.Revit.DB.Structure.BendingDetailCustomFieldProperties.SegmentLengthDimensionTypeId Property

Identifies the Id of the linear dimension type which is used to show segments length.

## Syntax (C#)
```csharp
public ElementId SegmentLengthDimensionTypeId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The segmentLengthDimensionTypeId should be an id of a linear dimension type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

