---
kind: property
id: P:Autodesk.Revit.DB.Infrastructure.AlignmentStationLabelOptions.TypeId
source: html/86352cb2-b367-a806-7427-2fb08e50b425.htm
---
# Autodesk.Revit.DB.Infrastructure.AlignmentStationLabelOptions.TypeId Property

Specifies the ElementId of the label type. 
 The default value is InvalidElementId. In this case, the default type id for alignment station labels in the document is used.

## Syntax (C#)
```csharp
public ElementId TypeId { get; set; }
```

## Remarks
Valid types can be found using IsValidType(Element) .

