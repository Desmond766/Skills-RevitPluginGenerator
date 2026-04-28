---
kind: property
id: P:Autodesk.Revit.DB.Electrical.AnalyticalEquipmentLoadData.LoadSet
source: html/97e3e11c-6867-0f61-9bd7-e08e04ff1908.htm
---
# Autodesk.Revit.DB.Electrical.AnalyticalEquipmentLoadData.LoadSet Property

The electrical analytical load set of the analytical equipment load.

## Syntax (C#)
```csharp
public ElementId LoadSet { get; set; }
```

## Remarks
invalidElementId if the analytical equipment load does not belong to any analytical load sets.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given element id loadSetId is neither a load set id nor invalidElementId.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

