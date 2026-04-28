---
kind: type
id: T:Autodesk.Revit.DB.Electrical.ElectricalAnalyticalNode
source: html/562d1f7d-c9df-bee5-4659-4f8607ee4333.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalAnalyticalNode

Represents an electrical analytical node under the Analytical Power Distribution in the System Browser.

## Syntax (C#)
```csharp
public class ElectricalAnalyticalNode : Element
```

## Remarks
This represents one of any number of types, as specified by the ElectricalAnalyticalNodeType .
 Some of those types will have AnalyticalDistributionNodePropertyData while others will not, and if they do have data they can be downcast to a specific subclass of data to be used.

