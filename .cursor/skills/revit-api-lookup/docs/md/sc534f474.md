---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalLink.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/eea725bf-30dd-4aaa-5870-9ffa2f0c898c.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalLink.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a AnalyticalLink element between two Hubs.

## Syntax (C#)
```csharp
public static AnalyticalLink Create(
	Document doc,
	ElementId type,
	ElementId startHubId,
	ElementId endHubId
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - Document to which new AnalyticalLink should be added.
- **type** (`Autodesk.Revit.DB.ElementId`) - AnalyticalLinkType for the new AnalyticalLink.
- **startHubId** (`Autodesk.Revit.DB.ElementId`) - Hub at start of AnalyticalLink.
- **endHubId** (`Autodesk.Revit.DB.ElementId`) - Hub at end of AnalyticalLink.

## Returns
The newly created AnalyticalLink instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - startHubId is not a valid Hub ID for an AnalyticalLink element.
 -or-
 endHubId is not a valid Hub ID for an AnalyticalLink element.
 -or-
 Thrown if startHubId or endHubId do not represent ids of Hubs.
 -or-
 Thrown if startHubId == endHubId.
 -or-
 Thrown if type does not represent an id of an AnalyticalLinkType.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

