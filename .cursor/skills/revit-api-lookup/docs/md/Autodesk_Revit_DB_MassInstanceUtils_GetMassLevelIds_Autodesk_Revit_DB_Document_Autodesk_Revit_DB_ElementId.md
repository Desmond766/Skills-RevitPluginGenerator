---
kind: method
id: M:Autodesk.Revit.DB.MassInstanceUtils.GetMassLevelIds(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/627c83e6-6620-1296-9614-30d62042e062.htm
---
# Autodesk.Revit.DB.MassInstanceUtils.GetMassLevelIds Method

Get the ElementIds of the Levels associated with a mass instance.

## Syntax (C#)
```csharp
public static IList<ElementId> GetMassLevelIds(
	Document document,
	ElementId massInstanceId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document.
- **massInstanceId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the mass instance.

## Returns
The ElementIds of the Levels

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId massInstanceId is not a mass instance.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

