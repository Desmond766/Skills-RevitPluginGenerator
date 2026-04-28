---
kind: property
id: P:Autodesk.Revit.DB.Infrastructure.AlignmentStationLabelSetOptions.TypeId
source: html/5b0dfa5d-bc2f-b097-a8d6-c5e78c569add.htm
---
# Autodesk.Revit.DB.Infrastructure.AlignmentStationLabelSetOptions.TypeId Property

Specifies the ElementId of the labels' type.
 The default value is InvalidElementId. in this case, CreateSet(Alignment, View, AlignmentStationLabelSetOptions) will throw an exception.

## Syntax (C#)
```csharp
public ElementId TypeId { get; set; }
```

## Remarks
Recommended types can be found using IsRecommendedTypeForSet(Element) 
 Other valid types can be found using IsValidType(Element) .

