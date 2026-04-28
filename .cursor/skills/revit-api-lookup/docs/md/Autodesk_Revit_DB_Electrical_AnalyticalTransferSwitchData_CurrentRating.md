---
kind: property
id: P:Autodesk.Revit.DB.Electrical.AnalyticalTransferSwitchData.CurrentRating
source: html/590a650c-bcc2-004f-485f-f609e6d8187c.htm
---
# Autodesk.Revit.DB.Electrical.AnalyticalTransferSwitchData.CurrentRating Property

The current rating value of the electrical analytical transfer switch.

## Syntax (C#)
```csharp
public double CurrentRating { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for rating is not a number
 -or-
 When setting this property: The given value for rating is not finite
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for rating must be non-negative.

