---
kind: property
id: P:Autodesk.Revit.DB.NumberingSchema.NumberingParameterId
source: html/94659f29-c7f2-9643-f443-9451a3177cc2.htm
---
# Autodesk.Revit.DB.NumberingSchema.NumberingParameterId Property

Id of the parameter that stores values of the numbers on enumerated elements.

## Syntax (C#)
```csharp
public ElementId NumberingParameterId { get; }
```

## Remarks
Values of numbers can be obtained by querying this parameter for the respective numbered element.
 The value is read-only and thus cannot be set; it is always computed based on the order of created
 elements and the matching policy within each numbering sequence. Note: Although the parameter cannot be changed directly, it can be modified indirectly
 (with restrictions) using the ChangeNumber(String, Int32, Int32) method.

