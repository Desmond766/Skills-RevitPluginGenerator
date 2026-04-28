---
kind: method
id: M:Autodesk.Revit.DB.MassInstanceUtils.GetGrossSurfaceArea(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/e138e150-a22b-c086-fe3c-5b3643389b51.htm
---
# Autodesk.Revit.DB.MassInstanceUtils.GetGrossSurfaceArea Method

Get the total exterior building surface area represented by a mass instance.

## Syntax (C#)
```csharp
public static double GetGrossSurfaceArea(
	Document document,
	ElementId massInstanceId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document.
- **massInstanceId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the mass instance.

## Returns
The gross surface area in square feet.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId massInstanceId is not a mass instance.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

