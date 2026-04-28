---
kind: method
id: M:Autodesk.Revit.DB.MassInstanceUtils.GetGrossVolume(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/fa70c27b-bd50-07d1-3f57-22f5e245d244.htm
---
# Autodesk.Revit.DB.MassInstanceUtils.GetGrossVolume Method

Get the total building volume represented by a mass instance.

## Syntax (C#)
```csharp
public static double GetGrossVolume(
	Document document,
	ElementId massInstanceId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document.
- **massInstanceId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the mass instance.

## Returns
The gross volume in cubic feet.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId massInstanceId is not a mass instance.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

