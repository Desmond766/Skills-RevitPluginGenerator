---
kind: method
id: M:Autodesk.Revit.DB.Electrical.AreaBasedLoadData.AddElectricalLoadArea(Autodesk.Revit.DB.ElementId)
source: html/16569cca-cbd2-40f8-6323-810037f1111b.htm
---
# Autodesk.Revit.DB.Electrical.AreaBasedLoadData.AddElectricalLoadArea Method

Adds electrical load area into the area based load.

## Syntax (C#)
```csharp
public void AddElectricalLoadArea(
	ElementId electricalLoadAreaId
)
```

## Parameters
- **electricalLoadAreaId** (`Autodesk.Revit.DB.ElementId`) - The electrical load area id to add.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The id isn't a valid electrical load area.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

