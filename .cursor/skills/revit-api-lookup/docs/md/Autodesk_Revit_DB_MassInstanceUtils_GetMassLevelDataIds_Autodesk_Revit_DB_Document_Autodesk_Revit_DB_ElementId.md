---
kind: method
id: M:Autodesk.Revit.DB.MassInstanceUtils.GetMassLevelDataIds(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/244c26d6-da7c-c754-3a00-4be63d59a704.htm
---
# Autodesk.Revit.DB.MassInstanceUtils.GetMassLevelDataIds Method

Get the ElementIds of the MassLevelDatas (Mass Floors) associated with a mass instance.

## Syntax (C#)
```csharp
public static IList<ElementId> GetMassLevelDataIds(
	Document document,
	ElementId massInstanceId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document.
- **massInstanceId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the mass instance.

## Returns
The ElementIds of the MassLevelDatas.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId massInstanceId is not a mass instance.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

