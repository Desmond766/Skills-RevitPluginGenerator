---
kind: property
id: P:Autodesk.Revit.DB.Infrastructure.AlignmentStationLabelSetOptions.Interval
source: html/ea9ccd2c-89fd-0fa1-d179-887a204c78e4.htm
---
# Autodesk.Revit.DB.Infrastructure.AlignmentStationLabelSetOptions.Interval Property

The interval between labels to be created in the set, in Revit internal model units (standard Imperial feet).
 The default value is null.
 When null, a predefined interval value will be used, depending on the unit setting for stationing units in the document.
 For standard imperial, the default is 100 ft.
 For survey imperial, the default is 100 USft (US survey).
 For metric, the default is 1000 m.

## Syntax (C#)
```csharp
public Nullable<double> Interval { get; set; }
```

