---
kind: method
id: M:Autodesk.Revit.DB.MassInstanceUtils.GetJoinedElementIds(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/19706a09-b90f-2078-cd66-488413989b5e.htm
---
# Autodesk.Revit.DB.MassInstanceUtils.GetJoinedElementIds Method

Get the ElementIds of Elements that are joined to a mass instance.

## Syntax (C#)
```csharp
public static IList<ElementId> GetJoinedElementIds(
	Document document,
	ElementId massInstanceId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document.
- **massInstanceId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the mass instance.

## Returns
ElementIds of Elements joined to the mass instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId massInstanceId is not a mass instance.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

